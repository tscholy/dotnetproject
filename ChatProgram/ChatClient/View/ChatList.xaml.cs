using ChatClient.ViewModel;
using ChatClient.WebService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatClient.View
{
    /// <summary>
    /// Interaktionslogik für ChatList.xaml
    /// </summary>
    public partial class ChatList : UserControl
    {
        private ChatRestClient chatRestClient = new ChatRestClient();
        private ChatVM chatVM;

        public ChatList(User user, ChatVM chatVM)
        {
            InitializeComponent();
            ChatListVM chatListVM = new ChatListVM();
            this.DataContext = chatListVM;
            chatListVM.CurrentChats = chatRestClient.GetAllChatsforUser(user.Id);
            foreach(Models.Chat chat in chatListVM.CurrentChats)
            {
                chat.Members = chatRestClient.GetAllMembersToChat(chat.Id);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Models.Chat chat = (Models.Chat)item.Content;
                chatVM.CurrentView = new ChatWindow(chat);
            }          
        }
    }
}
