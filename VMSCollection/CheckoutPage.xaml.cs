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
    /// Interaction logic for CheckoutPage.xaml
    /// </summary>
    public partial class CheckoutPage : Page {

        Dictionary<Button, VisitInfo> coButtonToInfo = new Dictionary<Button, VisitInfo>();

        public CheckoutPage() {
            InitializeComponent();
            SetHeaderWidths();
            SetupCheckoutList();
        }

        private void SetHeaderWidths() {
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 200) / 4;
            codeHeader.Width = width;
            nameHeader.Width = width;
            coyHeader.Width = width;
            visiteeHeader.Width = width;
        }

        private void SetupCheckoutList() {
            checkoutList.Children.Clear();
            Commons.Instance.RetrieveVisitsFromDB(Commons.Checkout);
            foreach (VisitInfo info in Commons.Instance.listOfVisits) {
                StackPanel newRow = info.GetCheckoutRow();
                checkoutList.Children.Add(newRow);

                info.checkOutButtonCtrl.Click += OnCheckOutClicked;
                coButtonToInfo[info.checkOutButtonCtrl] = info;
            }
        }

        private void OnCheckOutClicked(object sender, RoutedEventArgs e) {
            VisitInfo targetInfo = coButtonToInfo[(Button)sender];
            if (MessageBox.Show(String.Format("Confirm checkout for {0}?", targetInfo.visitorName), "Checkout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                targetInfo.status = Commons.Completed;
                targetInfo.eta = null;
                DateTime checkout = DateTime.Now;
                Commons.Instance.UpdateChangeToDB(checkout, targetInfo);
                SetupCheckoutList();
            }
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
