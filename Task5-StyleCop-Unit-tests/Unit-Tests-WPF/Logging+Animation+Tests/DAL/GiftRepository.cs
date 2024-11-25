namespace bepresent_wpf.DAL
{
    using bepresent_wpf.BLL;
    using System.Collections.Generic;
    using System.Linq;

    public class GiftRepository
    {
        private readonly DataContext Context;

        public GiftRepository(DataContext context)
        {
            Context = context;
        }

        public void AddGift(Gift gift)
        {
            Context.Gifts.Add(gift);
            Context.SaveChanges();
        }

        public List<Gift> GetGiftsByBoardId(int boardId)
        {
            return Context.Gifts.Where(g => g.board_id == boardId).ToList();
        }

        public Gift GetGiftById(int giftId)
        {
            return Context.Gifts.FirstOrDefault(g => g.gift_id == giftId);
        }

        public List<GiftDTO> GetBoardGifts(int boardId)
        {
            var gifts = Context.Gifts
                .Where(g => g.board_id == boardId)
                .Select(g => new GiftDTO
                {
                    gift_id = g.gift_id,
                    name = g.name,
                    description = g.description,
                    link = g.link,
                    image_url = g.image_url,
                    is_reserved = g.is_reserved,
                    created_at = g.created_at,
                })
                .ToList();

            return gifts;
        }
    }
}