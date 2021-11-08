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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2_PaintLike
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


        private void PencilButton_Click(object sender, RoutedEventArgs e)
        {
            if (Canvas.EditingMode != InkCanvasEditingMode.Ink)
            {
                Canvas.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            if (Canvas.EditingMode != InkCanvasEditingMode.EraseByPoint)
            {
                Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }

        private void PaletteButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes newDrawing = new DrawingAttributes();

            Random random = new Random();
            byte red = Convert.ToByte(random.Next(0, 255));
            byte green = Convert.ToByte(random.Next(0, 255));
            byte blue = Convert.ToByte(random.Next(0, 255));

            newDrawing.Color = new Color() { R = red, G = green, B = blue, A = (byte)255 };

            Canvas.DefaultDrawingAttributes = newDrawing;


        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображение (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                Canvas.Background = imageBrush;
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Изображение (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    Size sizeCanvas = new Size(Canvas.ActualWidth, Canvas.ActualHeight);
                    Canvas.Margin = new Thickness(0, 0, 0, 0);

                    Canvas.Measure(sizeCanvas);
                    Canvas.Arrange(new Rect(sizeCanvas));


                    string fileName = saveFileDialog.FileName;
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)sizeCanvas.Width, (int)sizeCanvas.Height, 96d, 96d, PixelFormats.Default);
                    rtb.Render(Canvas);

                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        JpegBitmapEncoder encoderJpeg = new JpegBitmapEncoder();
                        encoderJpeg.Frames.Add(BitmapFrame.Create(rtb));
                        encoderJpeg.Save(fileStream);
                    }
                }
            }
        }
    }
}
