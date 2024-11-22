using bepresent_wpf.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace bepresent_wpf.BLL
{
    public interface IUserService
    {
        void Register(string username, string password);
        User GetUser(string username);
    }



    public interface IBoardService
    {
        void CreateBoard(string name, int userId, DateTime? celebrationDate, int[] collaborators, string accessLevel, string description);
        List<BoardDTO> GetUserBoards(int userId);
        List<GiftDTO> GetBoardGifts(int boardId);

        void AddGiftToBoard(string name, string description, int boardId, string link = null, string imageUrl = null, int? reservedBy = null);

    }


    public interface IGiftService
    {
        void AddGift(string name, string description, int boardId, string link = null, string imageUrl = null, int? reservedBy = null);
    }



}