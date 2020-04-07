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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page {
        public LoginPage() {
            InitializeComponent();
            BitmapImage se_logo = new BitmapImage();
            se_logo.BeginInit();
            se_logo.UriSource = new Uri("pack://application:,,,/Resources/se_logo.png");
            se_logo.EndInit();
            logo.Source = se_logo;
            user_textBox.AddHandler(FrameworkElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(TextBox_MouseLeftButtonUp), true);
            user_textBox.AddHandler(FrameworkElement.LostFocusEvent, new RoutedEventHandler(TextBox_LostFocus), true);
            pw_textBox.AddHandler(FrameworkElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(TextBox_MouseLeftButtonUp), true);
            pw_textBox.AddHandler(FrameworkElement.LostFocusEvent, new RoutedEventHandler(TextBox_LostFocus), true);
            pw_textBox.AddHandler(FrameworkElement.GotFocusEvent, new RoutedEventHandler(TextBox_MouseLeftButtonUp), true);
        }

        private void TextBox_MouseLeftButtonUp(object sender, RoutedEventArgs e) {
            if (sender is TextBox sesa) {
                if (sesa.Text == "USER ID") {
                    sesa.Clear();
                }
            }
            else if (sender is PasswordBox pw) {
                if (pw.Password == "PASSWORD") {
                    pw.Clear();
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) {
            Control target = (Control)sender;
            if (target.Name == "user_textBox") {
                if (((TextBox)target).Text == String.Empty) {
                    ((TextBox)target).Text = "USER ID";
                }
            }
            else if (target.Name == "pw_textBox") {
                if (((PasswordBox)target).Password == String.Empty)
                    ((PasswordBox)target).Password = "PASSWORD";
            }
        }

        private void OnPw_EnterPressed(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                OnLogin_Clicked(new Object(), new RoutedEventArgs());
            }
        }

        private void OnLogin_Clicked(object sender, RoutedEventArgs e) {
            
            try {
                User user = ValidateLogin();
                Commons.Instance.currUser = user;
                MainPage newPage = new MainPage();
                newPage.SetMode(user.role);
                user_textBox.Text = "USER ID";
                pw_textBox.Password = "PASSWORD";
                this.NavigationService.Navigate(newPage);
            }
            catch (CustomExceptions.UserNotFoundException ex) {
                MessageBox.Show("User does not exist in database. Please try again.");
                user_textBox.Text = "USER ID";
                pw_textBox.Password = "PASSWORD";
                Console.WriteLine(ex);

            }
            catch (CustomExceptions.WrongPasswordException ex) {
                MessageBox.Show("Wrong password. Please try again.");
                pw_textBox.Password = String.Empty;
                Console.WriteLine(ex);

            }
        }

        private void OnExitClicked(object sender, RoutedEventArgs e) {
            if (System.Windows.MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private User ValidateLogin() {
            string idInput = user_textBox.Text.ToLower();
            string pwInput = pw_textBox.Password;

            if (Commons.Instance.userDict.ContainsKey(idInput)) {
                if (pwInput != Commons.Instance.userDict[idInput].password) {
                    throw new CustomExceptions.WrongPasswordException();
                }
            }
            else {
                throw new CustomExceptions.UserNotFoundException();
            }

            return Commons.Instance.userDict[idInput];
        }

        private void OnFullScreenClicked(object sender, RoutedEventArgs e) {
            Commons.Instance.ToggleFullScreen();
        }
    }
}
