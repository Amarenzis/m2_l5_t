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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_WordLike
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.TextDecorations = null;
        }

        private void ComboBox_SelectionChanged_Font(object sender, SelectionChangedEventArgs e)
        {
            string fontNameCurrent = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (textBox!=null)
            {
                textBox.FontFamily = new FontFamily(fontNameCurrent);
            }
        }

        private void ComboBox_SelectionChanged_Size(object sender, SelectionChangedEventArgs e)
        {
            int sizeFontCurrent = Convert.ToInt32(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (textBox!=null)            
            {                
                textBox.FontSize = sizeFontCurrent;
            }
        }

        private void Button_Click_Bold(object sender, RoutedEventArgs e)
        {
            string weightFontCurrent = (textBox.FontWeight).ToString();
            if (textBox!=null)
            {
                if (weightFontCurrent == "Normal")
                {
                    textBox.FontWeight = System.Windows.FontWeights.Bold;
                }
                else
                {
                    textBox.FontWeight = System.Windows.FontWeights.Normal;
                }
            }
        }

        private void Button_Click_Italic(object sender, RoutedEventArgs e)
        {
            string styleFontCurrent = (textBox.FontStyle).ToString();
            if (textBox != null)
            {
                if (styleFontCurrent == "Normal")
                {
                    textBox.FontStyle = System.Windows.FontStyles.Italic;
                }
                else
                {
                    textBox.FontStyle = System.Windows.FontStyles.Normal;
                }
            }
        }

        private void Button_Click_Underline(object sender, RoutedEventArgs e)
        {
            bool underlineFontCurrent;
            if (textBox.TextDecorations == null)
            {
                underlineFontCurrent = false;
            }
            else
            {
                underlineFontCurrent = true;
            }
            
            if (textBox != null)
            {
                if (!underlineFontCurrent)
                {
                    textBox.TextDecorations = TextDecorations.Underline;
                }
                else
                {
                    textBox.TextDecorations = null;
                }
            }
        }

        private void RadioButton_Checked_Black(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_Checked_Red(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Red;
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    
}
