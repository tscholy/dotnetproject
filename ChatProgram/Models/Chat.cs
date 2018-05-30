using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AdminID { get; set; }                
        public List<BaseUser> Members { get; set; }
        public List<ChatMessage> Messages { get; set; }
        
    }
}
