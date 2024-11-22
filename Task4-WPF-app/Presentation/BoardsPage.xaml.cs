using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using bepresent_wpf.BLL;
using bepresent_wpf.DAL;
using System.Linq;
using System;

namespace bepresent_wpf.Presentation
{
    public partial class BoardsPage : Page
    {
        private readonly IBoardService _boardService;
        private readonly int _userId;

        public BoardsPage(int userId)
        {
            InitializeComponent();
            _userId = userId;
            var dataContext = new DataContext();
            var boardRepository = new BoardRepository(dataContext);
            var giftRepository = new GiftRepository(dataContext);

            _boardService = new BoardService(boardRepository, giftRepository);

            LoadBoards();
        }

        private void LoadBoards()
        {
            var boards = _boardService.GetUserBoards(_userId);
            BoardsListView.ItemsSource = boards;
        }

        private void BoardsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BoardsListView.SelectedItem is BoardDTO selectedBoard)
            {

                BoardNameTextBlock.Text = selectedBoard.name;
                BoardDescriptionTextBlock.Text = selectedBoard.description;
                BoardCelebrationDateTextBlock.Text = selectedBoard.celebration_date?.ToString("yyyy-MM-dd") ?? "No Date";
                BoardAccessLevelTextBlock.Text = selectedBoard.access_level;
                BoardCreatedAtTextBlock.Text = selectedBoard.created_at.ToString("yyyy-MM-dd");

                LoadGifts(selectedBoard.board_id);
            }
            else
            {
                ClearBoardDetails();
            }
        }

        private void LoadGifts(int boardId)
        {

            var gifts = _boardService.GetBoardGifts(boardId); 
            GiftsListView.ItemsSource = gifts;
        }

        private void ClearBoardDetails()
        {

            BoardNameTextBlock.Text = string.Empty;
            BoardDescriptionTextBlock.Text = string.Empty;
            BoardCelebrationDateTextBlock.Text = string.Empty;
            BoardAccessLevelTextBlock.Text = string.Empty;
            BoardCreatedAtTextBlock.Text = string.Empty;
            GiftsListView.ItemsSource = null;
        }

        private void AddBoardButton_Click(object sender, RoutedEventArgs e)
        {
            var boardName = Microsoft.VisualBasic.Interaction.InputBox("Enter board name:", "New Board");

            if (!string.IsNullOrEmpty(boardName))
            {
                var celebrationDateInput = Microsoft.VisualBasic.Interaction.InputBox("Enter celebration date (yyyy-mm-dd):", "Celebration Date");
                DateTime? celebrationDate = null;
                if (DateTime.TryParse(celebrationDateInput, out DateTime parsedDate))
                {
                    celebrationDate = parsedDate;
                }

                var collaboratorsInput = Microsoft.VisualBasic.Interaction.InputBox("Enter collaborators (comma-separated user IDs):", "Collaborators");
                List<int> collaborators = new List<int>();
                if (!string.IsNullOrEmpty(collaboratorsInput))
                {
                    collaborators = collaboratorsInput.Split(',')
                        .Select(id => int.TryParse(id.Trim(), out int userId) ? userId : 0)
                        .Where(id => id > 0)
                        .ToList();
                }

                int[] collaboratorsArray = collaborators.ToArray();

                var accessLevel = Microsoft.VisualBasic.Interaction.InputBox("Enter access level (public, friends_only, private):", "Access Level");

                var description = Microsoft.VisualBasic.Interaction.InputBox("Enter description:", "Description");

                _boardService.CreateBoard(boardName, _userId, celebrationDate, collaboratorsArray, accessLevel, description);
                LoadBoards();
            }
        }

        private void AddGiftButton_Click(object sender, RoutedEventArgs e)
        {
            if (BoardsListView.SelectedItem is BoardDTO selectedBoard)
            {
                var giftName = Microsoft.VisualBasic.Interaction.InputBox("Enter gift name:", "New Gift");
                if (string.IsNullOrEmpty(giftName)) return;

                var giftDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter gift description:", "Gift Description");
                var giftLink = Microsoft.VisualBasic.Interaction.InputBox("Enter gift link (optional):", "Gift Link");
                var giftImageUrl = Microsoft.VisualBasic.Interaction.InputBox("Enter gift image URL (optional):", "Gift Image URL");

                _boardService.AddGiftToBoard(giftName, giftDescription, selectedBoard.board_id, giftLink, giftImageUrl);

                LoadGifts(selectedBoard.board_id);
            }
            else
            {
                MessageBox.Show("Please select a board.");
            }
        }
    }
}
