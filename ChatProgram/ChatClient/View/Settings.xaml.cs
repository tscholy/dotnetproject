using ChatClient.ViewModel;
using System;
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

namespace ChatClient.View
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        private ChatVM chatVm;
        private MemoryStream memoryStreamFile;

        public Settings(ChatVM chatVM)
        {
            InitializeComponent();
            chatVm = chatVM;
        }

        private void ApplyBackground_OnClick(object sender, RoutedEventArgs e)
        {
            if(memoryStreamFile != null)
            {
                chatVm.ChangeBackground(memoryStreamFile);
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
                textboxFilename.Text = filename;
            }         
            else
            {
                MessageBox.Show("File is too big. Choose a smaller one");
            }
        }
    }
}
