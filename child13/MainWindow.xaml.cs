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
using OpenCvSharp;
using System.Drawing;
using System.Security.Policy;
using System.Diagnostics;
using child13.Views;
using child13.Models;


namespace child13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public int x1, x2, y1, y2;
        MemoryStream memoryStream = new MemoryStream();
        Coordinate coordinate = new Coordinate();

        private void Tompost_mode_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }

        public MainWindow()
        {
            InitializeComponent();
            TranslateButton_Click(null, null);
            RunPythonScript("./python/main.py");
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
                x1 = coordinate.GetX1();
                y1 = coordinate.GetY1();
                x2 = coordinate.GetX2();
                y2 = coordinate.GetY2();
                string coord = $"X1: {x1}, Y1: {y1}, X2: {x2}, Y2: {y2}";
                MessageBox.Show(coord);
            }
        }

        // Метод для запуска .py файла
        private void RunPythonScript(string scriptPath)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "python", // или "python3", в зависимости от вашей установки
                    Arguments = scriptPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true // Если хотите запустить без консольного окна
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    // Чтение вывода скрипта (опционально)
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Обработка вывода и ошибок
                    if (!string.IsNullOrEmpty(output))
                    {
                        MessageBox.Show($"Output: {output}");
                    }

                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Error: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


    }
}
