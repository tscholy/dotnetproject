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
    public class MainWindowVM : BindableBase
    {
        private UserControl currentControl;
        private Bitmap currentBackground;

        public MainWindowVM()
        {
           CurrentBackground = new Bitmap(Properties.Resources.back);
        }
   

        public UserControl CurrentControl
        {
            get { return currentControl; }
            set
            {
                SetProperty(ref currentControl, value);
            }
        }

        public Bitmap CurrentBackground
        {
            get { return currentBackground; }
            set { SetProperty(ref currentBackground, value); }
        }

      

    }
}
