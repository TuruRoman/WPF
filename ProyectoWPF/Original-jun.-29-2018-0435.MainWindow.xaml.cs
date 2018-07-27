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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.OData;


namespace AppWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var client = new ODataClient(new ODataClientSettings('http://services.odata.org/V4/TripPinServiceRW/')
            {
                IgnoreResourceNotFoundException = true,
                OnTrace = (x, y) => Console.WriteLine(string.Format(x, y)),
            });
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
   
}



   