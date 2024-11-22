using bepresent_wpf.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace bepresent_wpf.DAL
{
    public class BoardRepository
    {
        private readonly DataContext _context;

        public BoardRepository(DataContext context)
        {
            _context = context;
        }

        public void AddBoard(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
        }

        public List<Board> GetBoardsByUserId(int userId)
        {
            return _context.Boards.FromSqlRaw("SELECT * FROM \"Boards\" WHERE user_id = {0}", userId).ToList();
        }

    }
}