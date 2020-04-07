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
using Xceed.Wpf.Toolkit;

namespace VMSCollection {
    /// <summary>
    /// Interaction logic for RecordsPage.xaml
    /// </summary>
    public partial class RecordsPage : Page {

        Dictionary<Button, VisitInfo> coButtonToInfo = new Dictionary<Button, VisitInfo>();
        Dictionary<DateTimePicker, VisitInfo> etaToInfo = new Dictionary<DateTimePicker, VisitInfo>();
        Dictionary<ComboBox, VisitInfo> statToInfo = new Dictionary<ComboBox, VisitInfo>();

        public RecordsPage() {
            InitializeComponent();
            SetHeaderWidths();
            SetupVisitList();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(RefreshPage);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void SetHeaderWidths() {
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 140) / 9;
            vCodeHeader.Width = width;
            vNameHeader.Width = width;
            coyHeader.Width = width;
            pNameHeader.Width = width;
            pEmailHeader.Width = width;
            checkinHeader.Width = width;
            checkoutHeader.Width = width;
            statHeader.Width = width;
            etaHeader.Width = width;
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }

        private void SetupVisitList() {
            Commons.Instance.RetrieveVisitsFromDB(Commons.Checkout);
            foreach (VisitInfo info in Commons.Instance.listOfVisits) {
                StackPanel newRow = info.GetRecordsRow();
                visitList.Children.Add(newRow);

                info.etaCtrl.LostFocus += new RoutedEventHandler(UpdateEta);
                info.etaCtrl.KeyDown += UpdateEta;
                etaToInfo[info.etaCtrl] = info;

                info.statusCtrl.SelectionChanged += UpdateStatus;
                statToInfo[info.statusCtrl] = info;

                info.checkOutButtonCtrl.Click += OnCheckOutClicked;
                coButtonToInfo[info.checkOutButtonCtrl] = info;
            }
        }

        private void RefreshPage(object sender, EventArgs e) {
            visitList.Children.Clear();
            SetupVisitList();
        }

        private void UpdateEta(object sender, RoutedEventArgs e) {
            DateTimePicker etaCtrl = (DateTimePicker)sender;
            DateTime? eta = etaCtrl.Value;
            VisitInfo targetInfo = etaToInfo[etaCtrl];
            targetInfo.eta = eta;
            if (eta != null) {
                Commons.Instance.UpdateChangeToDB(targetInfo, eta);
            }
        }

        private void UpdateStatus(object sender, RoutedEventArgs e) {
            DateTime now = DateTime.Now;
            ComboBox statCtrl = (ComboBox)sender;
            ComboBoxItem statusItem = (ComboBoxItem)statCtrl.SelectedItem;
            string status = (string)statusItem.Content;
            VisitInfo targetInfo = statToInfo[statCtrl];
            targetInfo.status = status;
            if (status == Commons.Pending) {
                targetInfo.pendingTime = now;
            } else if (status == Commons.InProgress) {
                targetInfo.inProgressTime = now;
            } else if (status == Commons.Ready) {
                targetInfo.readyTime = now;
            }
            Commons.Instance.UpdateChangeToDB(targetInfo, status, now);
        }


        private void OnCheckOutClicked(object sender, RoutedEventArgs e) {
            VisitInfo targetInfo = coButtonToInfo[(Button)sender];
            if (System.Windows.MessageBox.Show(String.Format("Confirm checkout for {0}?", targetInfo.visitorName), "Checkout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                targetInfo.status = Commons.Completed;
                targetInfo.eta = null;
                ComboBoxItem completed = new ComboBoxItem();
                completed.Content = Commons.Completed;
                targetInfo.statusCtrl.Items.Add(completed);
                targetInfo.statusCtrl.SelectedIndex = Commons.statToIndex[Commons.Completed];
                DateTime checkout = DateTime.Now;
                targetInfo.checkOutTextCtrl.Text = checkout.ToString("yyyy-MM-dd HH:mm:ss");
                targetInfo.statusCtrl.IsEnabled = false;
                targetInfo.etaCtrl.IsEnabled = false;
                targetInfo.checkOutButtonCtrl.IsEnabled = false;
                Commons.Instance.UpdateChangeToDB(checkout, targetInfo);
            }
        }

    }
}
