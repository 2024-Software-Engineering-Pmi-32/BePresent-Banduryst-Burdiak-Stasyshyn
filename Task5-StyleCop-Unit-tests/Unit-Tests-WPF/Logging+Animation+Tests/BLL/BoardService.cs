namespace bepresent_wpf.BLL
{
    using bepresent_wpf.DAL;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BoardService : IBoardService
    {
        private readonly BoardRepository BoardRepository;
        private readonly GiftRepository GiftRepository;

        public BoardService(BoardRepository boardRepository, GiftRepository giftRepository)
        {
            BoardRepository = boardRepository;
            GiftRepository = giftRepository;
        }

        public void CreateBoard(string name, int userId, DateTime? celebrationDate, int[] collaborators, string accessLevel, string description)
        {
            var board = new Board
            {
                name = name,
                user_id = userId,
                celebration_date = celebrationDate,
                collaborators = collaborators,
                access_level = accessLevel,
                description = description,
            };
            BoardRepository.AddBoard(board);
        }

        public List<BoardDTO> GetUserBoards(int userId)
        {
            var boards = BoardRepository.GetBoardsByUserId(userId);
            return boards.Select(b => new BoardDTO
            {
                user_id = b.user_id,
                board_id = b.board_id,
                name = b.name,
                celebration_date = b.celebration_date,
                collaborators = b.collaborators,
                access_level = b.access_level,
                description = b.description,
                created_at = b.created_at,
            }).ToList();
        }

        public List<GiftDTO> GetBoardGifts(int boardId)
        {
            return GiftRepository.GetBoardGifts(boardId);
        }

        public void AddGiftToBoard(string name, string description, int boardId, string link = null, string imageUrl = null, int? reservedBy = null)
        {
            var gift = new Gift
            {
                name = name,
                description = description,
                board_id = boardId,
                link = link,
                image_url = imageUrl,
                reserved_by = reservedBy,
            };

             GiftRepository.AddGift(gift);
        }
    }
}
