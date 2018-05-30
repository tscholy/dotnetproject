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
    /// Interaktionslogik für Chat.xaml
    /// </summary>
    public partial class Chat : UserControl
    {
        private MainWindowVM mainWindowVM;
        private UserRestClient restClient;
        private ChatVM chatVM;

        public Chat(MainWindowVM mainWindow, UserRestClient userRestClient)
        {
            InitializeComponent();
            chatVM = new ChatVM(userRestClient.CurrentUser);
            this.DataContext = chatVM;
            restClient = userRestClient;
            chatVM.CurrentContacts = userRestClient.GetAllContacts(userRestClient.CurrentUser.Id);
            chatVM.CurrentView = new ChatList(userRestClient.CurrentUser, chatVM);
            this.mainWindowVM = mainWindow;
        }

        private void SelectionChanged_ListView(object sender, SelectionChangedEventArgs e)
        {
            //selectedContent.Content = new ChatWindow(null);
        }

        private void OpenChats_Button(object sender, RoutedEventArgs e)
        {
            chatVM.CurrentView = new ChatList(restClient.CurrentUser, chatVM);
        }
    }
}
