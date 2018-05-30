
using Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    public class ChatListVM : BindableBase
    {
        private List<Chat> currentChats;

        public ChatListVM()
        {

        }

        public List<Chat> CurrentChats
        {
            get => currentChats;
            set { SetProperty(ref currentChats, value); }
        }
    }
}
