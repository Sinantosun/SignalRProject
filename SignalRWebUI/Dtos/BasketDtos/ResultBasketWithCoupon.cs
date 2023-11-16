using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketWithCoupon
    {
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
