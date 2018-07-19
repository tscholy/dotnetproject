using Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatClient.ViewModel
{
    public class MainWindowVM : BindableBase
    {
        private UserControl currentControl;
        private Bitmap currentBackground;
        private MainWindow mainWindow;

        public MainWindowVM(MainWindow main)
        {
            mainWindow = main;

            CurrentBackground = Properties.Resources.back;
            
        }

        internal void ShowButtons()
        {
            mainWindow.ShowButtons();
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

        internal void HideButtons()
        {
            mainWindow.HideButtons();
        }

        internal void ChangeBackground(MemoryStream memoryStreamFile)
        {
            
            CurrentBackground = new Bitmap(memoryStreamFile);
            /*
            string dir = Directory.GetCurrentDirectory();
            string filePath = @"back.jpg";

            if (System.IO.File.Exists("\\back.jpg"))
            {
                try
                { 
                    File.Delete("\\back.jpg");
                    System.Drawing.Image img = System.Drawing.Image.FromStream(memoryStreamFile);
                    img.Save(System.IO.Path.GetTempPath() + "\\back.jpg", ImageFormat.Jpeg);

                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;

                }
                

            }*/
        }
    }
}
