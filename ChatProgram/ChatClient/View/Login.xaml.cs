using ChatClient.ViewModel;
using ChatClient.WebService;
using System.Windows;
using System.Windows.Controls;

namespace ChatClient.View
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindowVM mainVM;

        public Login(MainWindowVM mainWindowVM)
        {
            InitializeComponent();
            mainVM = mainWindowVM;
        }

        private void Click_Login(object sender, RoutedEventArgs e)
        {
            UserRestClient userRestClient = new UserRestClient();
            if(userRestClient.Login(usernameTextbox.Text, passwordTextbox.Password.ToString()))
            {
                mainVM.CurrentControl = new Chat();
            }
            else
            {
                errorLabel.Content = "Credentials are invalid!";
            }
        }
    }
}
