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

namespace VMSCollection {
    /// <summary>
    /// Interaction logic for ExportPage.xaml
    /// </summary>
    public partial class ExportPage : Page {
        public ExportPage() {
            InitializeComponent();
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }

        private void OnExportClicked(object sender, RoutedEventArgs e) {
            try {
                SelectedDatesCollection dates = calendar.SelectedDates;
                DateTime start = dates.First();
                DateTime end = dates.Last();

                //List<VisitInfo> visitList = Commons.Instance.RetrievePastRecords(start, end);

            } catch (System.InvalidOperationException ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Please select a date/a range of dates.");
            }
            
        }
    }
}
