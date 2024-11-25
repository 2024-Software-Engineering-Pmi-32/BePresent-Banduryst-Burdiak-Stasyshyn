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

         public virtual List<Board> GetBoardsByUserId(int userId)
        {
            return Context.Boards.Where(b => b.user_id == userId).ToList();  
        }

    }
}