using ChatClient.View;
using ChatClient.ViewModel;
using ChatClient.WebService;
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

namespace ChatClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserRestClient userRestClient;

        public MainWindow()
        {
            userRestClient = new UserRestClient();
            InitializeComponent();
            MainWindowVM mainWindowVM = new MainWindowVM();
            Login login = new Login(mainWindowVM, userRestClient);
            mainWindowVM.CurrentControl = login;            
            this.DataContext = mainWindowVM;

        }


    }
}
