using ChatClient.ViewModel;
using System;
using System.Windows.Controls;

namespace ChatClient.View
{
    /// <summary>
    /// Interaktionslogik für ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : UserControl
    {
        private Models.Chat chat;
        private ChatWindowVM chatWindowVM;

        public ChatWindow(Models.Chat chat)
        {
            InitializeComponent();
            chatWindowVM = new ChatWindowVM(chat);
            this.DataContext = chatWindowVM;
            this.chat = chat;

        }
    }
}
