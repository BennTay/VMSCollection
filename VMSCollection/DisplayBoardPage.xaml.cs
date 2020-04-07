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
using System.Windows.Threading;

namespace VMSCollection {
    /// <summary>
    /// Interaction logic for DisplayBoardPage.xaml
    /// </summary>
    public partial class DisplayBoardPage : Page {
        private int numVisitors = -1;

        public DisplayBoardPage() {
            InitializeComponent();
            SetWidth();
            this.SetupInfo(new object(), new EventArgs());
            SetImages();
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(SetupInfo);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void SetImages() {
            BitmapImage coy_icon = new BitmapImage();
            coy_icon.BeginInit();
            coy_icon.UriSource = new Uri("pack://application:,,,/Resources/se_icon.png");
            coy_icon.EndInit();
            se_icon.Source = coy_icon;

            BitmapImage c_icon = new BitmapImage();
            c_icon.BeginInit();
            c_icon.UriSource = new Uri("pack://application:,,,/Resources/cust_icon.png");
            c_icon.EndInit();
            cust_icon.Source = c_icon;

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/Resources/se_lio.png");
            logo.EndInit();
            se_logo.Source = logo;
        }
        
        private void SetWidth() {
            double w = Commons.Instance.mainNavWindow.ActualWidth;
            double width = (w - 80) / 5;
            codeHeader.Width = width;
            nameHeader.Width = width;
            checkinHeader.Width = width;
            etaHeader.Width = width;
            statHeader.Width = width;
            se_icon.Width = w/20;
            cust_icon.Width = w/20;
            se_logo.Width = w/5;
        }

        private void SetupInfo(object sender, EventArgs e) {
            try {
                Commons.Instance.RetrieveVisitsFromDB(Commons.Records);
                liveStatusList.Children.Clear();
                foreach (VisitInfo info in Commons.Instance.listOfVisits) {
                    StackPanel newRow = info.GetStatusRow();
                    liveStatusList.Children.Add(newRow);
                }

                int currNum = Commons.Instance.listOfVisits.Count();
                if (currNum > this.numVisitors && this.numVisitors != -1) {
                    Commons.Instance.PlayNewVisitorAlert();
                }
                this.numVisitors = currNum;

                CommandManager.InvalidateRequerySuggested();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }
    }
}
