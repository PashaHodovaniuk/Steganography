using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Steganography
{
    /// <summary>
    /// Логика взаимодействия для Encrypting.xaml
    /// </summary>
    public partial class Encrypting : Window
    {
        public Encrypting()
        {
            InitializeComponent();
        }
        string rFile;

        private void Encrypt_Closed(object sender, EventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            Encrypt.Hide();
        }

        private void MainScreen_Click(object sender, RoutedEventArgs e)
        {
            Encrypt_Closed(sender, e);
        }

        private void Ending_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ClearKey_Click(object sender, RoutedEventArgs e)
        {
            Key.Clear();
        }

        private void OpenImg1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "bmp files (*.bmp)|*.bmp";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Please select an image file to encrypt.";
            Stream myStream = null;
            Nullable<bool> result = dialog.ShowDialog();

            if (result==true)
            {
                try
                {
                    if ((myStream = dialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Img1.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
                            FileInfo file = new FileInfo(dialog.FileName);
                            double size = file.Length / 1024;
                            StartSize.Content = size.ToString()+" KB";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }          
        }

        
    }
}
