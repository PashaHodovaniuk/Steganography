using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using System.Windows.Interop;

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

        string aText = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя+-*/.,?!()\" :;=0123456789";
        Stream myStream = null;
        string imgfile;

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
            
            Nullable<bool> result = dialog.ShowDialog();

            if (result==true)
            {
                try
                {
                    if ((myStream = dialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            imgfile = dialog.FileName;
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

        private void AutoKey_Click(object sender, RoutedEventArgs e)
        {
            var temp = new vernama(aText);
            Key.Text = temp.Gener(TextEncr1.Text);
        }

        private void SaveKey_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "Key (*.key)|*.key";
            if (saveFile1.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.OpenFile(), System.Text.Encoding.Default))
                {
                    sw.Write(Key.Text);
                    sw.Close();
                }
            }
        }

        private void SaveImg_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap image|*.bmp";
            if (sfd.ShowDialog() == true && Img1.Source != null)
            {
                FileInfo finf = new FileInfo(sfd.FileName);
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                string ext = finf.Extension.ToLower();
                BitmapEncoder bmpEncoder = null;                
                bmpEncoder = new BmpBitmapEncoder();
                bmpEncoder.Frames.Add(BitmapFrame.Create(Img1.Source as BitmapSource));
                bmpEncoder.Save(fs);
                fs.Close();
            }
        }

        private void Encrpting_Click(object sender, RoutedEventArgs e)
        {
            string text = TextEncr1.Text;
            string key = Key.Text;

            var pad = new vernama(aText);
            string encrypt = pad.Crypt(text, key, true);

            Steganograf1(encrypt);
        }

        private BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            bool st = false;
            for (int i = 0; i < 8; i++)
            {
                if ((src >> i & 1) == 1)
                {
                    st = true;
                }
                else st = false;
                bitArray[i] = st;
            }
            return bitArray;
        }

        private byte BitToByte(BitArray scr)
        {
            byte num = 0;
            for (int i = 0; i < scr.Count; i++)
                if (scr[i] == true)
                    num += (byte)Math.Pow(2, i);
            return num;
        } 
        
         private bool isEncryption(WriteableBitmap scr)
         {
            
             byte[] rez = new byte[1];
             Color color = scr.GetPixel(0, 0);
             BitArray colorArray = ByteToBit(color.R); //получаем байт цвета и преобразуем в массив бит
             BitArray messageArray = ByteToBit(color.R); ;//инициализируем результирующий массив бит
             messageArray[0] = colorArray[0];
             messageArray[1] = colorArray[1];

             colorArray = ByteToBit(color.G);//получаем байт цвета и преобразуем в массив бит
             messageArray[2] = colorArray[0];
             messageArray[3] = colorArray[1];
             messageArray[4] = colorArray[2];

             colorArray = ByteToBit(color.B);//получаем байт цвета и преобразуем в массив бит
             messageArray[5] = colorArray[0];
             messageArray[6] = colorArray[1];
             messageArray[7] = colorArray[2];
             rez[0] = BitToByte(messageArray); //получаем байт символа, записанного в 1 пикселе
             string m = Encoding.GetEncoding(1251).GetString(rez);
             if (m == "/")
             {
                 return true;
             }
             else return false;
         }

         private void WriteCountText(int count, WriteableBitmap src)
         {
             byte[] CountSymbols;
             if (count < 100)
             {
                 CountSymbols = Encoding.GetEncoding(1251).GetBytes("0" + count.ToString());
             }
             else
             {
                 CountSymbols = Encoding.GetEncoding(1251).GetBytes(count.ToString());
             }
             for (int i = 0; i < 3; i++)
             {
                 BitArray bitCount = ByteToBit(CountSymbols[i]); //биты количества символов
                 Color pColor = src.GetPixel(0, i + 1); //1, 2, 3 пикселы
                 BitArray bitsCurColor = ByteToBit(pColor.R); //бит цветов текущего пикселя
                 bitsCurColor[0] = bitCount[0];
                 bitsCurColor[1] = bitCount[1];
                 byte nR = BitToByte(bitsCurColor); //новый бит цвета пиксея

                 bitsCurColor = ByteToBit(pColor.G);//бит бит цветов текущего пикселя
                 bitsCurColor[0] = bitCount[2];
                 bitsCurColor[1] = bitCount[3];
                 bitsCurColor[2] = bitCount[4];
                 byte nG = BitToByte(bitsCurColor);//новый цвет пиксея

                 bitsCurColor = ByteToBit(pColor.B);//бит бит цветов текущего пикселя
                 bitsCurColor[0] = bitCount[5];
                 bitsCurColor[1] = bitCount[6];
                 bitsCurColor[2] = bitCount[7];
                 byte nB = BitToByte(bitsCurColor);//новый цвет пиксея

                 Color nColor = Color.FromRgb(nR, nG, nB); //новый цвет из полученных битов
                 src.SetPixel(0, i + 1, nColor); //записали полученный цвет в картинку
             }
         }

         private int ReadCountText(WriteableBitmap src)
         {
             byte[] rez = new byte[3]; //массив на 3 элемента, т.е. максимум 999 символов шифруется
             for (int i = 0; i < 3; i++)
             {
                 Color color = src.GetPixel(0, i + 1); //цвет 1, 2, 3 пикселей 
                 BitArray colorArray = ByteToBit(color.R); //биты цвета
                 BitArray bitCount = ByteToBit(color.R); ; //инициализация результирующего массива бит
                 bitCount[0] = colorArray[0];
                 bitCount[1] = colorArray[1];

                 colorArray = ByteToBit(color.G);
                 bitCount[2] = colorArray[0];
                 bitCount[3] = colorArray[1];
                 bitCount[4] = colorArray[2];

                 colorArray = ByteToBit(color.B);
                 bitCount[5] = colorArray[0];
                 bitCount[6] = colorArray[1];
                 bitCount[7] = colorArray[2];
                 rez[i] = BitToByte(bitCount);
             }

             string m = Encoding.GetEncoding(1251).GetString(rez);
             return Convert.ToInt32(m, 10);
         }


         private void Steganograf1(string rText)
         {
             byte[] bText = Encoding.Unicode.GetBytes(rText);

             List<byte> bList = new List<byte>();
             //Img1.Source.GetValue             
             WriteableBitmap bPic = new WriteableBitmap(
                 (int)Img1.ActualWidth,
                 (int)Img1.ActualHeight,
                 96,
                 96,
                 PixelFormats.Bgra32,null);
             Img1.Source = bPic;
             //bPic = Img1.Source as WriteableBitmap;

             bList = bText.ToList();
             int CountText = bList.Count;

             if (CountText > ((Img1.Source.Width * Img1.Source.Height)) - 4)
             {
                 MessageBox.Show("Выбранная картинка мала для размещения выбранного текста", "Информация", MessageBoxButton.OK);
                 return;
             }

             if (isEncryption(bPic))
             {
                 MessageBox.Show("Файл уже зашифрован", "Информация", MessageBoxButton.OK);
                 return;
             }

             byte[] Symbol = Encoding.GetEncoding(1251).GetBytes("/");
             BitArray ArrBeginSymbol = ByteToBit(Symbol[0]);
             Color curColor = bPic.GetPixel(0, 0);
             BitArray tempArray = ByteToBit(curColor.R);
             tempArray[0] = ArrBeginSymbol[0];
             tempArray[1] = ArrBeginSymbol[1];
             byte nR = BitToByte(tempArray);

             tempArray = ByteToBit(curColor.G);
             tempArray[0] = ArrBeginSymbol[2];
             tempArray[1] = ArrBeginSymbol[3];
             tempArray[2] = ArrBeginSymbol[4];
             byte nG = BitToByte(tempArray);

             tempArray = ByteToBit(curColor.B);
             tempArray[0] = ArrBeginSymbol[5];
             tempArray[1] = ArrBeginSymbol[6];
             tempArray[2] = ArrBeginSymbol[7];
             byte nB = BitToByte(tempArray);

             Color nColor = Color.FromRgb(nR, nG, nB);
             bPic.SetPixel(0, 0, nColor);

             WriteCountText(CountText, bPic); //записываем количество символов исходного текста

             int index = 0;
             bool st = false;
             for (int i = 4; i < bPic.Width; i++)
             {
                 for (int j = 0; j < bPic.Height; j++)
                 {
                     Color pixelColor = bPic.GetPixel(i, j);
                     if (index == bList.Count)
                     {
                         st = true;
                         break;
                     }
                     BitArray colorArray = ByteToBit(pixelColor.R);
                     BitArray messageArray = ByteToBit(bList[index]);
                     colorArray[0] = messageArray[0]; //меняем
                     colorArray[1] = messageArray[1]; // в нашем цвете биты
                     byte newR = BitToByte(colorArray);

                     colorArray = ByteToBit(pixelColor.G);
                     colorArray[0] = messageArray[2];
                     colorArray[1] = messageArray[3];
                     colorArray[2] = messageArray[4];
                     byte newG = BitToByte(colorArray);

                     colorArray = ByteToBit(pixelColor.B);
                     colorArray[0] = messageArray[5];
                     colorArray[1] = messageArray[6];
                     colorArray[2] = messageArray[7];
                     byte newB = BitToByte(colorArray);

                     Color newColor = Color.FromRgb(newR, newG, newB);
                     bPic.SetPixel(i, j, newColor);
                     index++;
                 }
                 if (st)
                 {
                     break;
                 }
             }
         }
    }


    class vernama
    {
        Dictionary<char, int> alph = new Dictionary<char, int>();
        Dictionary<int, char> alph_r = new Dictionary<int, char>();

        public vernama(IEnumerable<char> Alphabet)
        {
            int i = 0;
            foreach (char c in Alphabet)
            {
                alph.Add(c, i);
                alph_r.Add(i++, c);
            }
        }
        
        public string Crypt(string Text, string Key, bool Crypt)
        {
            char[] key = Key.ToCharArray();
            char[] text = Text.ToCharArray();
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int idx;
                if (alph.TryGetValue(text[i], out idx))
                {
                    int r = alph.Count + idx;
                    r += (Crypt ? 1 : -1) * alph[key[i % key.Length]];
                    sb.Append(alph_r[r % alph.Count]);
                }
            }

            return sb.ToString();
        }
        
        public string Gener(string Text)
        {
            Random temp = new Random();
            int len = Text.Length;
            string Textkey = "";
            char[] m = new char[len];
            
            for (int i = 0; i < len; i++)
            {
                m[i] = alph_r[temp.Next(0, 58)];
                Textkey += m[i];
            }
            return Textkey;
        }

    }
}
