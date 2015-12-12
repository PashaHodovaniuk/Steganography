﻿using System;
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

namespace Steganography
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypting1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Encrypting encr = new Encrypting();
            encr.Show();
            Win.Hide();
        }

        private void Decrypting1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Decrypting dencr = new Decrypting();
            dencr.Show();
            Win.Hide();
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        

    }
}
