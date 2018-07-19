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
        private MainWindowVM mainWindowVM;

        internal void ShowButtons()
        {
            loginButton.Visibility = Visibility.Visible;
            registerButton.Visibility = Visibility.Visible;
            logoutButton.Visibility = Visibility.Hidden;
        }

        public MainWindow()
        {
            userRestClient = new UserRestClient();            
            InitializeComponent();
            mainWindowVM = new MainWindowVM(this);
            Login login = new Login(mainWindowVM, userRestClient);
            mainWindowVM.CurrentControl = login;            
            this.DataContext = mainWindowVM;

        }

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            Register register = new Register(mainWindowVM, userRestClient);
            mainWindowVM.CurrentControl = register;
        }

        internal void HideButtons()
        {
            loginButton.Visibility = Visibility.Hidden;
            registerButton.Visibility = Visibility.Hidden;
            logoutButton.Visibility = Visibility.Visible;
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            Login login = new Login(mainWindowVM, userRestClient);
            mainWindowVM.CurrentControl = login;
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            userRestClient.CurrentUser = new Models.User();
            Login login = new Login(mainWindowVM, userRestClient);
            mainWindowVM.CurrentControl = login;
            ShowButtons();
        }
    }
}
