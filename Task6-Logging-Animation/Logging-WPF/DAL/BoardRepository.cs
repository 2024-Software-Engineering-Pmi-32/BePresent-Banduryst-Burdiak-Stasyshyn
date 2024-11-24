namespace bepresent_wpf.DAL
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    public class BoardRepository
    {
        private readonly DataContext Context;

        public BoardRepository(DataContext context)
        {
            Context = context;
        }

        public void AddBoard(Board board)
        {
            Context.Boards.Add(board);
            Context.SaveChanges();
        }

        public List<Board> GetBoardsByUserId(int userId)
        {
            return Context.Boards.FromSqlRaw("SELECT * FROM \"boards\" WHERE user_id = {0}", userId).ToList();
        }
    }
}