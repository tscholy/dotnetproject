using ChatClient.WebService;
using Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.ViewModel
{
    public class ChatWindowVM : BindableBase
    {
        private Chat currentChat;
        private ChatRestClient chatRestClient;

        public ChatWindowVM(Chat chat)
        {
            chatRestClient = new ChatRestClient();
            CurrentChat = chat;
            CurrentChat.Messages = chatRestClient.GetMessegesToChat(chat.Id);
        }

        public Chat CurrentChat
        {
            get
            {
                return currentChat;
            }
            set
            {
                SetProperty(ref currentChat, value);
            }
        }
    }
}
