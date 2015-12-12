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

        private void Encrypt_Closed(object sender, EventArgs e)
        {
            MainWindow temp = new MainWindow();
            temp.Show();
            Encrypt.Hide();
        }
    }
}
