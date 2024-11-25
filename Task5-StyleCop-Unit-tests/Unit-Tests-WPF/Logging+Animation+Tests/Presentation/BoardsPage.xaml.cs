namespace bepresent_wpf.Presentation
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using bepresent_wpf.BLL;
    using bepresent_wpf.DAL;
    using System.Linq;
    using System;
    using Serilog;
    using System.Windows.Media.Animation;


    public partial class BoardsPage : Page
    {
        private readonly IBoardService BoardService;
        private readonly int UserId;

        public BoardsPage(int userId)
        {
            InitializeComponent();
            UserId = userId;

            Log.Information("Initializing BoardsPage for UserId {UserId}", userId);

            var dataContext = new DataContext();
            var boardRepository = new BoardRepository(dataContext);
            var giftRepository = new GiftRepository(dataContext);

            BoardService = new BoardService(boardRepository, giftRepository);

            try
            {
                LoadBoards();
                Log.Information("Boards loaded successfully for UserId {UserId}", userId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error loading boards for UserId {UserId}", userId);
            }
        }

        private void LoadBoards()
        {
            try
            {
                var boards = BoardService.GetUserBoards(UserId);
                BoardsListView.ItemsSource = boards;
                Log.Information("Loaded {Count} boards for UserId {UserId}", boards.Count(), UserId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error loading boards for UserId {UserId}", UserId);
                MessageBox.Show("An error occurred while loading boards.");
            }
        }

        private void BoardsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BoardsListView.SelectedItem is BoardDTO selectedBoard)
                {
                    var selectedItem = BoardsListView.ItemContainerGenerator.ContainerFromItem(BoardsListView.SelectedItem) as ListViewItem;

                    if (selectedItem != null)
                    {
                        Storyboard selectionAnimation = (Storyboard)Resources["BoardSelectionAnimation"];
                        selectionAnimation.Begin(selectedItem);
                    }

                    Log.Information("Board selected: {BoardId} - {BoardName}", selectedBoard.board_id, selectedBoard.name);

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
                    Log.Information("Board selection cleared.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error handling board selection.");
            }
        }


        private void LoadGifts(int boardId)
        {
            try
            {
                var gifts = BoardService.GetBoardGifts(boardId);
                GiftsListView.ItemsSource = gifts;

                Log.Information("Loaded {Count} gifts for BoardId {BoardId}", gifts.Count(), boardId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error loading gifts for BoardId {BoardId}", boardId);
                MessageBox.Show("An error occurred while loading gifts.");
            }
        }

        private void ClearBoardDetails()
        {
            try
            {
                BoardNameTextBlock.Text = string.Empty;
                BoardDescriptionTextBlock.Text = string.Empty;
                BoardCelebrationDateTextBlock.Text = string.Empty;
                BoardAccessLevelTextBlock.Text = string.Empty;
                BoardCreatedAtTextBlock.Text = string.Empty;
                GiftsListView.ItemsSource = null;

                Log.Information("Cleared board details.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error clearing board details.");
            }
        }

        private void AddBoardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Storyboard buttonAnimation = (Storyboard)Resources["ButtonClickAnimation"];
                buttonAnimation.Begin(AddBoardButton);

                var boardName = Microsoft.VisualBasic.Interaction.InputBox("Enter board name:", "New Board");

                if (!string.IsNullOrEmpty(boardName))
                {
                    Log.Information("Attempting to add new board with name: {BoardName} for UserId {UserId}", boardName, UserId);

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
                        collaborators = collaboratorsInput.Split(',').Select(id => int.TryParse(id.Trim(), out int userId) ? userId : 0)
                                                         .Where(id => id > 0).ToList();
                    }

                    int[] collaboratorsArray = collaborators.ToArray();

                    var accessLevel = Microsoft.VisualBasic.Interaction.InputBox("Enter access level (public, friends_only, private):", "Access Level");

                    var description = Microsoft.VisualBasic.Interaction.InputBox("Enter description:", "Description");

                    BoardService.CreateBoard(boardName, UserId, celebrationDate, collaboratorsArray, accessLevel, description);
                    Log.Information("Board created successfully: {BoardName} for UserId {UserId}", boardName, UserId);

                    LoadBoards();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding new board for UserId {UserId}", UserId);
                MessageBox.Show("An error occurred while adding the board.");
            }
        }


        private void AddGiftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Storyboard buttonAnimation = (Storyboard)Resources["ButtonClickAnimation"];
                buttonAnimation.Begin(AddGiftButton);

                if (BoardsListView.SelectedItem is BoardDTO selectedBoard)
                {
                    var giftName = Microsoft.VisualBasic.Interaction.InputBox("Enter gift name:", "New Gift");
                    if (string.IsNullOrEmpty(giftName))
                    {
                        Log.Warning("Attempted to add a gift with an empty name to BoardId {BoardId}", selectedBoard.board_id);
                        return;
                    }

                    Log.Information("Attempting to add gift to BoardId {BoardId}: {GiftName}", selectedBoard.board_id, giftName);

                    var giftDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter gift description:", "Gift Description");
                    var giftLink = Microsoft.VisualBasic.Interaction.InputBox("Enter gift link (optional):", "Gift Link");
                    var giftImageUrl = Microsoft.VisualBasic.Interaction.InputBox("Enter gift image URL (optional):", "Gift Image URL");

                    BoardService.AddGiftToBoard(giftName, giftDescription, selectedBoard.board_id, giftLink, giftImageUrl);
                    Log.Information("Gift added successfully: {GiftName} to BoardId {BoardId}", giftName, selectedBoard.board_id);

                    LoadGifts(selectedBoard.board_id);
                }
                else
                {
                    MessageBox.Show("Please select a board.");
                    Log.Warning("Attempted to add a gift without selecting a board.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding gift to selected board.");
                MessageBox.Show("An error occurred while adding the gift.");
            }
        }


    }
}
