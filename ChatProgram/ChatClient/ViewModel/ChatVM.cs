using Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatClient.ViewModel
{
    public class ChatVM : BindableBase
    {
        private UserControl currentView;

        private List<BaseUser> currentContacts;

        private User currentLoggedInUser;
        private string currentLoggedInUsername;
        private Bitmap currentLoggedInUsericon;

        public ChatVM(User user)
        {
            CurrentLoggedInUser = user;
        }

        public UserControl CurrentView
        {
          get
          {
            return currentView;
          }
          set
          {
            SetProperty(ref currentView, value);
          }
        }

        public User CurrentLoggedInUser
        {
            get { return currentLoggedInUser; }
            set
            {
                CurrentLoggedInUsername = value.Username;
                if (value.UserIcon != null)
                {
                    CurrentLoggedInUsericon = new Bitmap(new MemoryStream(value.UserIcon));
                }
                else
                {
                    CurrentLoggedInUsericon = Properties.Resources.back;
                }
                currentLoggedInUser = value;
            }
        }

        public string CurrentLoggedInUsername
        {
            get { return currentLoggedInUsername; }
            set
            {
                SetProperty(ref currentLoggedInUsername, value);
            }
        }

        public Bitmap CurrentLoggedInUsericon
        {
            get { return currentLoggedInUsericon; }
            set { SetProperty(ref currentLoggedInUsericon, value); }
        }

        public List<BaseUser> CurrentContacts
        {
            get { return currentContacts; }
            set
            {
                foreach(BaseUser user in value)
                {
                    if(user.UserIcon == null)
                    {
                        Bitmap icon = new Bitmap(Properties.Resources.back);
                        using(var stream = new MemoryStream())
                        {
                            icon.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            user.UserIcon = stream.ToArray();
                        }
                    }
                }
                SetProperty(ref currentContacts, value);
            }
        }
    }
}
