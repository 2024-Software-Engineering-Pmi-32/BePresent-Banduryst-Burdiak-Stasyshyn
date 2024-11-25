namespace bepresent_wpf.BLL
{
    using bepresent_wpf.DAL;

    public class GiftService : IGiftService
    {
        private readonly GiftRepository GiftRepository;

        public GiftService(GiftRepository giftRepository)
        {
            GiftRepository = giftRepository;
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
                reserved_by = reservedBy,
            };
            GiftRepository.AddGift(gift);
        }
    }
}