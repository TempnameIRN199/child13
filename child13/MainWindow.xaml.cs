using child13.Views;
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
using Tesseract;

using _crd = child13.Models;

namespace child13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int x1, x2, y1, y2;
        MemoryStream memoryStream = new MemoryStream();

        public _crd.Coordinate coordinate = new _crd.Coordinate();

        private void Tompost_mode_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }

        public MainWindow()
        {
            InitializeComponent();
            var engine = new TesseractEngine(@"./tessdata_fast", "eng");
            var image = Pix.LoadFromFile(@"./img/ocr-image.png");
            var page = engine.Process(image);

            var text = page.GetText();

            File.WriteAllText(@"./text/output.txt", text);
            text_to_textbox();
        }

        public void text_to_textbox()
        {
            string text = File.ReadAllText(@"./text/output.txt");
            //textbox.Text = text;
        }

        private void OpenCoordinateWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CoordinateRecorder coordinateWindow = new CoordinateRecorder(coordinate);
            coordinateWindow.ShowDialog();
            if (coordinateWindow.DialogResult != true)
            {
                int[] coordinates = coordinate.SetCoordinates();
                x1 = coordinates[0];
                y1 = coordinates[1];
                x2 = coordinates[2];
                y2 = coordinates[3];
                string result = $"Координаты: x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2}";
                MessageBox.Show(result);
                text_to_textbox();
            }
        }
    }
}
