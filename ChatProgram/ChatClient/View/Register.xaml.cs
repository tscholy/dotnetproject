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
using ChatClient.ViewModel;
using ChatClient.WebService;
using Models;

namespace ChatClient.View
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private MainWindowVM mainWindowVM;
        private UserRestClient userRestClient;

        public Register(MainWindowVM mainWindowVM, UserRestClient userRestClient)
        {
            InitializeComponent();
            this.mainWindowVM = mainWindowVM;
            this.userRestClient = userRestClient;
        }

        private void Button_Register(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Firstname = firstnameTextbox.Text;
            user.Lastname = lastnameTextbox.Text;
            user.Username = usernameTextbox.Text;
            user.Password = passwordTextbox.Password.ToString();
            user.StatusMessage = stateMessageTextbox.Text;

            if(userRestClient.Register(user))
            {

            }
            else
            {

            }
        }
    }
}
