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

        public Chat(MainWindowVM mainWindow, UserRestClient userRestClient)
        {
            InitializeComponent();
            ChatVM chatVM = new ChatVM(userRestClient.CurrentUser);
            this.DataContext = chatVM;
            chatVM.CurrentContacts = userRestClient.GetAllContracts(userRestClient.CurrentUser.Id);          
            this.mainWindowVM = mainWindow;
        }
    }
}
