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
using Simple.OData.Client;


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
            var client = new ODataClient(new ODataClientSettings("http://services.odata.org/V4/TripPinServiceRW/")
            {
                IgnoreResourceNotFoundException = true,
                OnTrace = (x, y) => Console.WriteLine(string.Format(x, y)),
            });
            var annotations = new ODataFeedAnnotations();
            var people = await client
                For<Person>();
            FindEntriesAsync(annotations);
                ToList();
            while (annotations.NextPageLink != null)
            {
                people.AddRange(await _client
                    .For<Person>()
                    .FindEntriesAsync(annotations.NextPageLink, annotations));
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

    }
   
}



   