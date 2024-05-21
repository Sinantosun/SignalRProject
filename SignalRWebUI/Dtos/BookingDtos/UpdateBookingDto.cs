using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public int BookingID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }

        public void HtmlDecodeProperties()
        {
            this.Name = System.Web.HttpUtility.HtmlDecode(this.Name);
            this.Phone = System.Web.HttpUtility.HtmlDecode(this.Phone);
            this.Description = System.Web.HttpUtility.HtmlDecode(this.Description);
            this.Mail = System.Web.HttpUtility.HtmlDecode(this.Mail);
        }

    }
}
