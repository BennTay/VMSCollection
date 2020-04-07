using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VMSCollection {
    public class User {
        public string id;
        public string password;
        public string role;

        public TextBox idCtrl;
        public TextBox passwordCtrl;
        public TextBox roleCtrl;
        public Button delBtnCtrl;
        //public Button editBtnCtrl;

        public User(string uid, string pw, string r) {
            this.id = uid;
            this.password = pw;
            this.role = r;
        }

        public StackPanel GetUserRow() {
            StackPanel row = new StackPanel();
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 250) / 3;

            row.Orientation = Orientation.Horizontal;

            this.idCtrl = new TextBox();
            this.idCtrl.Width = width;
            this.idCtrl.Height = 25;
            this.idCtrl.Text = this.id;
            this.idCtrl.IsReadOnly = true;
            row.Children.Add(this.idCtrl);

            this.passwordCtrl = new TextBox();
            this.passwordCtrl.Width = width;
            this.passwordCtrl.Height = 25;
            this.passwordCtrl.Text = this.password;
            this.passwordCtrl.IsReadOnly = true;
            row.Children.Add(this.passwordCtrl);

            this.roleCtrl = new TextBox();
            this.roleCtrl.Width = width;
            this.roleCtrl.Height = 25;
            this.roleCtrl.Text = this.role;
            this.roleCtrl.IsReadOnly = true;
            row.Children.Add(this.roleCtrl);

            this.delBtnCtrl = new Button();
            this.delBtnCtrl.Width = width / 3;
            this.delBtnCtrl.Height = 25;
            this.delBtnCtrl.Content = "Delete";
            row.Children.Add(this.delBtnCtrl);

            //this.editBtnCtrl = new Button();
            //this.editBtnCtrl.Width = width / 5;
            //this.editBtnCtrl.Height = 25;
            //this.editBtnCtrl.Content = "Edit";
            //row.Children.Add(this.editBtnCtrl);

            return row;
        }
    }
}
