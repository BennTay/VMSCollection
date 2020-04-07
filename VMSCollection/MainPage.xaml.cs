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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page {
        public MainPage() {
            InitializeComponent();
            BitmapImage se_logo = new BitmapImage();
            se_logo.BeginInit();
            se_logo.UriSource = new Uri("pack://application:,,,/Resources/se_logo.png");
            se_logo.EndInit();
            logo.Source = se_logo;
        }

        private void OnNewVisitClicked(object sender, RoutedEventArgs e) {
            VisitFormPage newPage = new VisitFormPage();
            this.NavigationService.Navigate(newPage);
        }

        private void OnViewRecordsClicked(object sender, RoutedEventArgs e) {
            RecordsPage newPage = new RecordsPage();
            this.NavigationService.Navigate(newPage);
        }

        private void OnDisplayBoardClicked(object sender, RoutedEventArgs e) {
            DisplayBoardPage newPage = new DisplayBoardPage();
            this.NavigationService.Navigate(newPage);
        }

        private void OnCheckOutPgClicked(object sender, RoutedEventArgs e) {
            CheckoutPage newPage = new CheckoutPage();
            this.NavigationService.Navigate(newPage);
        }

        private void OnLogoutClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }

        private void OnUserMngClicked(object sender, RoutedEventArgs e) {
            UserManagementPage newPage = new UserManagementPage();
            this.NavigationService.Navigate(newPage);
        }

        private void OnExportPgClicked(object sender, RoutedEventArgs e) {
            ExportPage newPage = new ExportPage();
            this.NavigationService.Navigate(newPage);
        }

        public void SetMode(string role) {
            buttonPanel.Children.Clear();

            Button createVisitButton = new Button();
            createVisitButton.Content = "Create a Visit";
            createVisitButton.Margin = new Thickness(5);
            createVisitButton.Width = 100;
            createVisitButton.Height = 25;
            createVisitButton.Click += OnNewVisitClicked;

            Button viewRecordsButton = new Button();
            viewRecordsButton.Content = "View Records";
            viewRecordsButton.Margin = new Thickness(5);
            viewRecordsButton.Width = 100;
            viewRecordsButton.Height = 25;
            viewRecordsButton.Click += OnViewRecordsClicked;

            Button displayBoardButton = new Button();
            displayBoardButton.Content = "Display Board";
            displayBoardButton.Margin = new Thickness(5);
            displayBoardButton.Width = 100;
            displayBoardButton.Height = 25;
            displayBoardButton.Click += OnDisplayBoardClicked;

            Button checkOutButton = new Button();
            checkOutButton.Content = "Check Out";
            checkOutButton.Margin = new Thickness(5);
            checkOutButton.Width = 100;
            checkOutButton.Height = 25;
            checkOutButton.Click += OnCheckOutPgClicked;

            Button userMngButton = new Button();
            userMngButton.Content = "Accounts";
            userMngButton.Margin = new Thickness(5);
            userMngButton.Width = 100;
            userMngButton.Height = 25;
            userMngButton.Click += OnUserMngClicked;

            Button exportButton = new Button();
            exportButton.Content = "Export";
            exportButton.Margin = new Thickness(5);
            exportButton.Width = 100;
            exportButton.Height = 25;
            exportButton.Click += OnExportPgClicked;

            if (role == Commons.Root) {
                buttonPanel.Children.Add(createVisitButton);
                buttonPanel.Children.Add(viewRecordsButton);
                buttonPanel.Children.Add(displayBoardButton);
                buttonPanel.Children.Add(checkOutButton);
                buttonPanel.Children.Add(userMngButton);
                //buttonPanel.Children.Add(exportButton);
            }
            else if (role == Commons.Guard) {
                buttonPanel.Children.Add(createVisitButton);
                buttonPanel.Children.Add(checkOutButton);
            } else if (role == Commons.Releasing) {
                buttonPanel.Children.Add(viewRecordsButton);
                buttonPanel.Children.Add(displayBoardButton);
                //buttonPanel.Children.Add(exportButton);
            } else if (role == Commons.Admin) {
                buttonPanel.Children.Add(userMngButton);
            }
        }
    }
}
