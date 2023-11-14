using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.MessagesDto
{
    public class ResultMesaggesDto
    {
        public int MessagesID { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public bool status { get; set; }
    }
}
