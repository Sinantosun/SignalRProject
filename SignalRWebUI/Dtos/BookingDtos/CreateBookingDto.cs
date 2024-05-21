namespace SignalRWebUI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }

        public void HtmlEncodeProperties()
        {
            this.Name = System.Web.HttpUtility.HtmlEncode(this.Name);
            this.Phone = System.Web.HttpUtility.HtmlEncode(this.Phone);
            this.Description = System.Web.HttpUtility.HtmlEncode(this.Description);
            this.Mail = System.Web.HttpUtility.HtmlEncode(this.Mail);
        }

        public void HtmlDecodeProperties()
        {
            this.Name = System.Web.HttpUtility.HtmlDecode(this.Name);
            this.Phone = System.Web.HttpUtility.HtmlDecode(this.Phone);
            this.Description = System.Web.HttpUtility.HtmlDecode(this.Description);
            this.Mail = System.Web.HttpUtility.HtmlDecode(this.Mail);
        }

    }
}
