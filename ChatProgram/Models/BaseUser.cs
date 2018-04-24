using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] UserIcon { get; set; }
        public string StatusMessage { get; set; }
    }
}
