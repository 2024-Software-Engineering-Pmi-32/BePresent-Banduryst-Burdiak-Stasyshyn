using bepresent_wpf.BLL;
using bepresent_wpf.DAL;
using System.Collections.Generic;
using System.Linq;

namespace bepresent_wpf.DAL
{
    public class GiftRepository
    {
        private readonly DataContext _context;

        public GiftRepository(DataContext context)
        {
            _context = context;
        }

        public void AddGift(Gift gift)
        {
            _context.Gifts.Add(gift);
            _context.SaveChanges();
        }

        public List<Gift> GetGiftsByBoardId(int boardId)
        {
            return _context.Gifts.Where(g => g.board_id == boardId).ToList();
        }

        public Gift GetGiftById(int giftId)
        {
            return _context.Gifts.FirstOrDefault(g => g.gift_id == giftId);
        }

        public List<GiftDTO> GetBoardGifts(int boardId)
        {

            var gifts = _context.Gifts
                .Where(g => g.board_id == boardId) 
                .Select(g => new GiftDTO
                {
                    gift_id = g.gift_id,
                    name = g.name,
                    description = g.description,
                    link = g.link,
                    image_url = g.image_url,
                    is_reserved = g.is_reserved,
                    created_at = g.created_at
                })
                .ToList();

            return gifts;
        }
    }
}