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
    /// Interaction logic for VisitFormPage.xaml
    /// </summary>
    public partial class VisitFormPage : Page {
        public VisitFormPage() {
            InitializeComponent();
        }

        private void OnSaveClicked(object sender, RoutedEventArgs e) {
            try {
                CheckCriticalFields();

                string visitCode = Commons.Instance.GetNextVisitNum();
                DateTime visitDate = (DateTime)entry_visitDate.Value;
                string visitorNameStr = entry_visitorName.Text;
                string visitorEmailStr = entry_visitorEmail.Text;
                string visitorCoyStr = entry_visitorCompany.Text;
                string visitorJobTitleStr = entry_visitorJobTitle.Text;
                string visitorCountryStr = entry_visitorCountry.Text;
                string visitorPhoneNumStr = entry_visitorPhoneNum.Text;
                string personToVisitStr = entry_personToVisit.Text;
                string personToVisitEmailStr = entry_personToVisitEmail.Text;

                VisitInfo newVisit = new VisitInfo(visitCode, visitDate, visitorNameStr,
                    visitorEmailStr, visitorCoyStr, visitorJobTitleStr, visitorCountryStr,
                    visitorPhoneNumStr, personToVisitStr, personToVisitEmailStr);

                Commons.Instance.SaveVisit(newVisit);
                MessageBox.Show(String.Format("Your Visit Code is: {0}\nPlease record it down for reference later.", visitCode), "Visit Code", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.GoBack();

            } catch (CustomExceptions.MissingCriticalFieldException ex) {
                MessageBox.Show("Missing compulsory data. Please fill in all compulsory fields.");
                Console.WriteLine(ex);
            }
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }

        private void CheckCriticalFields() {
            if (entry_visitDate.Value == null ||
                entry_visitorName.Text == String.Empty ||
                entry_visitorCompany.Text == String.Empty ||
                entry_personToVisit.Text == String.Empty) {
                throw new CustomExceptions.MissingCriticalFieldException();
            }
        }
    }
}
