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
    /// Interaction logic for UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : Page {
        private Dictionary<Button, User> delBtnToUser = new Dictionary<Button, User>();
        //private Dictionary<Button, User> editBtnToUser = new Dictionary<Button, User>();

        public UserManagementPage() {
            InitializeComponent();
            SetHeaderWidth();
            SetupUserList();
        }

        private void SetHeaderWidth() {
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 250)/3;
            uNameHeader.Width = width;
            pwHeader.Width = width;
            roleHeader.Width = width;
        }

        private void SetupUserList() {
            Commons.Instance.RetrieveUserList();
            userListView.Children.Clear();
            foreach (User user in Commons.Instance.userList) {
                if (user.role != Commons.Root) {
                    StackPanel newRow = user.GetUserRow();
                    userListView.Children.Add(newRow);

                    user.delBtnCtrl.Click += OnDeleteClicked;
                    this.delBtnToUser[user.delBtnCtrl] = user;

                    //user.editBtnCtrl.Click += OnEditClicked;
                    //this.editBtnToUser[user.editBtnCtrl] = user;
                }
            }
        }

        private void OnGoBackClicked(object sender, RoutedEventArgs e) {
            this.NavigationService.GoBack();
        }

        private void OnAddClicked(object sender, RoutedEventArgs e) {
            try {
                if (uNameEntry.Text == String.Empty ||
                    pwEntry.Text == string.Empty ||
                    roleEntry.SelectedIndex == -1) {
                    throw new CustomExceptions.MissingCriticalFieldException();
                }

                string uName = uNameEntry.Text.ToLower();
                string password = pwEntry.Text;
                string role = (string)((ComboBoxItem)roleEntry.SelectedItem).Content;

                if (Commons.Instance.userDict.ContainsKey(uName)) {
                    throw new CustomExceptions.DuplicateUserException();
                }

                User newUser = new User(uName, password, role);

                Commons.Instance.AddUserToDB(newUser);
                SetupUserList();
                uNameEntry.Clear();
                pwEntry.Clear();
                roleEntry.SelectedIndex = -1;
            } catch (CustomExceptions.MissingCriticalFieldException ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Please fill in all the fields.", "Add failed: Missing Field");
            } catch (CustomExceptions.DuplicateUserException ex) {
                Console.WriteLine(ex);
                MessageBox.Show("User already exists in the database.", "Add failed: Duplicate User");
                uNameEntry.Clear();
                pwEntry.Clear();
                roleEntry.SelectedIndex = -1;
            }
        }

        private void OnDeleteClicked(object sender, RoutedEventArgs e) {
            User targetUser = this.delBtnToUser[(Button)sender];
            if (MessageBox.Show(String.Format("Confirm deletion of {0}?", targetUser.id), "Delete user", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                Commons.Instance.DeleteUserFromDB(targetUser);
                SetupUserList();
            }   
        }

        //private void OnEditClicked(object sender, RoutedEventArgs e) {
        //    Button targetButton = (Button)sender;
        //    targetButton.Content = "Confirm change";
        //    User targetUser = this.editBtnToUser[targetButton];

        //}
    }
}
