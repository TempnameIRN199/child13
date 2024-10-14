using child13_AI.AdditionalStructures.Service;
using child13_AI.ViewModels;
using child13_AI.Views;
using OpenCvSharp;
using System;
using System.IO;
using System.Windows;
using Tesseract;

namespace child13_AI.Views
{
    internal partial class MainWindow : System.Windows.Window
    {
        public string _API;
        public int x1, x2, y1, y2;
        public API api = new API();
        //----------------------------------------------------------
        // прочитати за цей клас
        MemoryStream memoryStream = new MemoryStream();
        //----------------------------------------------------------
        Coordinate coordinate = new Coordinate();

        private MainWindow()
        {
            InitializeComponent();
            TranslateButton_Click(null, null);
        }

        public MainWindow(in ViewModelOfMainWindow inViewModel) : this()
        {
            DataContext = inViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            API_Check aPI_Check = new API_Check();
            aPI_Check.Show();
            if (aPI_Check.IsActive == false)
            {
                api._APISet(_API);
            }
            MessageBox.Show(_API);
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            using (var img = Pix.LoadFromFile("./img/ocr-image.png"))
            {
                using (var engine = new TesseractEngine(@"./tessdata_fast", "eng", EngineMode.Default))
                {
                    var customConfig = @"--psm 7 --oem 3";
                    using (var page = engine.Process(img, customConfig))
                    {
                        var text = page.GetText();

                        File.WriteAllText(@"./text/output.txt", text);
                        text_to_textbox();
                    }
                }
            }
        }

        public static void PreprocessImage(string inputhPath, string outputPath,
            int x1, int y1, int x2, int y2)
        {
            var image = new Mat(inputhPath, ImreadModes.Grayscale);
            var croppedImage = image[new OpenCvSharp.Rect(x1, y1, x2 - x1, y2 - y1)];
            croppedImage.SaveImage(outputPath);
        }

        public void text_to_textbox()
        {
            string text = File.ReadAllText(@"./text/output.txt");
            _txtOriginal.Text = text;
        }

        private void OpenCoordinateWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CoordinateRecorder coordinateWindow = new CoordinateRecorder();
            coordinateWindow.ShowDialog();
            if (coordinateWindow.DialogResult != true)
            {
                x1 = coordinate._GetX1();
                y1 = coordinate._GetY1();
                x2 = coordinate._GetX2();
                y2 = coordinate._GetY2();
                string coord = $"X1: {x1}, Y1: {y1}, X2: {x2}, Y2: {y2}";
                MessageBox.Show(coord);
            }
        }


        //----------------------------------------------------------

        private void Tompost_mode_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }
    }
}
