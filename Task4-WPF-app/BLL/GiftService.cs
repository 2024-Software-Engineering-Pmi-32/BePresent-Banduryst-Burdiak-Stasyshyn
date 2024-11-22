using bepresent_wpf.DAL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace bepresent_wpf.BLL
{
    public class GiftService : IGiftService
    {
        private readonly GiftRepository _giftRepository;

        public GiftService(GiftRepository giftRepository)
        {
            _giftRepository = giftRepository;
        }

        public void AddGift(string name, string description, int boardId, string link = null, string imageUrl = null, int? reservedBy = null)
        {
            var gift = new Gift
            {
                name = name,
                description = description,
                board_id = boardId,
                link = link,
                image_url = imageUrl,
                reserved_by = reservedBy
            };
            _giftRepository.AddGift(gift);
        }


        
    }
}