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
        private UserRestClient userRestClient;

        public Login(MainWindowVM mainWindowVM, UserRestClient userRest)
        {
            InitializeComponent();
            mainVM = mainWindowVM;
            userRestClient = userRest;
            mainVM.ShowButtons();
        }

        private void Click_Login(object sender, RoutedEventArgs e)
        {
            if(userRestClient.Login(usernameTextbox.Text, passwordTextbox.Password.ToString()))
            {
               
               mainVM.CurrentControl = new Chat(mainVM, userRestClient);
               mainVM.HideButtons();
            }
            else
            {
                errorLabel.Content = "Credentials are invalid!";
            }
        }

        private void Login_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Click_Login(sender, e);
            }
            else
            {
                return;
            }
        }
    }
}
