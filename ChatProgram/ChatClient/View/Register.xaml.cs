﻿using System;
using System.Collections.Generic;
using System.IO;
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

        private MemoryStream memoryStreamFile;

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
            if(memoryStreamFile != null)
            {
                user.UserIcon = memoryStreamFile.ToArray();
            }

            if(userRestClient.Register(user))
            {

            }
            else
            {

            }
        }

        private void Button_Click_ChooseFile(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {

                memoryStreamFile = new MemoryStream();
                using (FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open))
                {
                    fileStream.CopyTo(memoryStreamFile);
                }
                string filename = dlg.FileName;
                iconTextbox.Text = filename;
            }
            else
            {
                MessageBox.Show("File is too big. Choose a smaller one");
            }
        }
    }
}
