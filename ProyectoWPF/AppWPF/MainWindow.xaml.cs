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
            
        }

        public IEnumerable<object> Airlines { get; private set; }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
             {
           

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new DefaultContainer(new Uri("http://services.odata.org/v4/(S(34wtn2c0hkuk5ekg0pjr513b))/TripPinServiceRW/"));
            var trip = context.People.ByKey(userName: "russellwhyte").Trips.ByKey(tripId: 0).GetValue();
            var people = trip.GetInvolvedPeople().Execute();
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable<Airline> airlines1 = null;
            IEnumerable<Airline> airlines2 = null;
            < p > var batch = new ODataBatch(client);
            batch += async c => airlines1 = await c
                .For<Airline>()
                .FindEntriesAsync();
            batch += c => c
            .For<Airline>()
            .Set(new Airline() { AirlineCode = 'TT', Name = 'Test Airline' })
            .InsertEntryAsync(false);
            batch += async c => airlines2 = await c
                .For<Airline>()
                .FindEntriesAsync();
            await batch.ExecuteAsync();
        }
    }
   
}



   