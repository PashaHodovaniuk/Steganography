using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Steganography
{
    /// <summary>
    /// Логика взаимодействия для Decrypting.xaml
    /// </summary>
    public partial class Decrypting : Window
    {
        public Decrypting()
        {
            InitializeComponent();
        }

        private void Decrypt_Closed(object sender, EventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            Decrypt.Hide();
        }

        private void OpenImg1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "bmp files (*.bmp)|*.bmp";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "Please select an image file to encrypt.";
            Stream myStream = null;
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                try
                {
                    if ((myStream = dialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Img1.Source = new BitmapImage(new Uri(dialog.FileName, UriKind.Absolute));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void MainScreen_Click(object sender, RoutedEventArgs e)
        {
            Decrypt_Closed(sender, e);
        }

        private void Ending_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
