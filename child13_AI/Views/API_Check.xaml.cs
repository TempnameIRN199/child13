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
using child13_AI.AdditionalStructures.Service;

namespace child13_AI.Views
{
    /// <summary>
    /// Interaction logic for API_Check.xaml
    /// </summary>
    public partial class API_Check : Window
    {
        API api = new API();

        public API_Check()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (api._APIIsNotSet())
            {
                _txtAPICheck.Text = api._APIGet();
                api._APISet("API is set");
                MessageBox.Show("API is set");
            }
            else
            {
                api._APIReset();
                MessageBox.Show("API is reset");
            }
        }
    }
}
