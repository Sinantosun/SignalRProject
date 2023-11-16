using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDto
{
    public class ResultBasketListDto
    {
        public int BasketID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductID { get; set; }

        public int MenuTableID { get; set; }

        public decimal CouponAmount { get; set; }

        public string ProductName { get; set; }
    }
}
