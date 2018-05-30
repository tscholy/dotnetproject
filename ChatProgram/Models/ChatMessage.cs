using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public DateTime SendDate { get; set; }
        public string Message { get; set; }
        public int SenderID { get; set; }
        public int ChatID { get; set; }

    }
}
