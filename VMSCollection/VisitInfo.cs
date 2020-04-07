using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace VMSCollection {
    public class VisitInfo {
        public string visitCode;
        public DateTime visitDate;
        public DateTime? checkOut;
        public string visitorName;
        public string visitorEmail;
        public string company;
        public string jobTitle;
        public string country;
        public string phoneNum;
        public string visiteeName;
        public string visiteeEmail;
        public DateTime? eta;
        public string status;
        public DateTime? pendingTime;
        public DateTime? inProgressTime;
        public DateTime? readyTime;
        public DateTime? completedTime;

        // Controls
        public DateTimePicker etaCtrl;
        public ComboBox statusCtrl;
        public Button checkOutButtonCtrl;
        public TextBox checkOutTextCtrl;

        public VisitInfo(string vCode, DateTime start, string vName, string vEmail, string coy,
            string job, string cty, string num, string pName, string pEmail) {
            this.visitCode = vCode;
            this.visitDate = start;
            this.visitorName = vName;
            this.visitorEmail = vEmail;
            this.company = coy;
            this.jobTitle = job;
            this.country = cty;
            this.phoneNum = num;
            this.visiteeName = pName;
            this.visiteeEmail = pEmail;
            this.checkOut = null;
            this.eta = null;
            this.status = Commons.Pending;
            this.pendingTime = start;
            this.inProgressTime = null;
            this.readyTime = null;
            this.completedTime = null;
        }

        public VisitInfo(string vCode, DateTime start, string vName, string vEmail, string coy,
            string job, string cty, string num, string pName, string pEmail, DateTime? end,
            DateTime? est, string stat, DateTime? pend, DateTime? inProg, DateTime? ready, DateTime? comp) {
            this.visitCode = vCode;
            this.visitDate = start;
            this.visitorName = vName;
            this.visitorEmail = vEmail;
            this.company = coy;
            this.jobTitle = job;
            this.country = cty;
            this.phoneNum = num;
            this.visiteeName = pName;
            this.visiteeEmail = pEmail;
            this.checkOut = end;
            this.eta = est;
            this.status = stat;
            this.pendingTime = pend;
            this.inProgressTime = inProg;
            this.readyTime = ready;
            this.completedTime = comp;
        }

        public StackPanel GetRecordsRow() {
            StackPanel row = new StackPanel();
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 140) / 9;

            row.Orientation = Orientation.Horizontal;

            TextBox vCode = new TextBox();
            vCode.Width = width;
            vCode.Height = 25;
            vCode.Text = this.visitCode;
            vCode.IsReadOnly = true;
            row.Children.Add(vCode);

            TextBox vName = new TextBox();
            vName.Width = width;
            vName.Height = 25;
            vName.Text = this.visitorName;
            vName.IsReadOnly = true;
            row.Children.Add(vName);

            TextBox coy = new TextBox();
            coy.Width = width;
            coy.Height = 25;
            coy.Text = this.company;
            coy.IsReadOnly = true;
            row.Children.Add(coy);

            TextBox pName = new TextBox();
            pName.Width = width;
            pName.Height = 25;
            pName.Text = this.visiteeName;
            pName.IsReadOnly = true;
            row.Children.Add(pName);

            TextBox pEmail = new TextBox();
            pEmail.Width = width;
            pEmail.Height = 25;
            pEmail.Text = this.visiteeEmail;
            pEmail.IsReadOnly = true;
            row.Children.Add(pEmail);

            TextBox start = new TextBox();
            start.Width = width;
            start.Height = 25;
            start.Text = this.visitDate.ToString("yyyy-MM-dd HH:mm:ss");
            start.IsReadOnly = true;
            row.Children.Add(start);

            this.checkOutTextCtrl = new TextBox();
            this.checkOutTextCtrl.Width = width;
            this.checkOutTextCtrl.Height = 25;
            this.checkOutTextCtrl.Text = (this.checkOut != null) ? ((DateTime)this.checkOut).ToString("yyyy-MM-dd HH:mm:ss") : String.Empty;
            this.checkOutTextCtrl.IsReadOnly = true;
            row.Children.Add(this.checkOutTextCtrl);

            this.etaCtrl = new DateTimePicker();
            this.etaCtrl.Value = this.eta;
            this.etaCtrl.Width = width;
            this.etaCtrl.Height = 25;
            this.etaCtrl.Format = DateTimeFormat.Custom;
            this.etaCtrl.FormatString = "hh:mm tt";
            this.etaCtrl.ShowDropDownButton = false;
            row.Children.Add(this.etaCtrl);

            this.statusCtrl = new ComboBox();
            this.statusCtrl.Width = width;
            this.statusCtrl.Height = 25;
            ComboBoxItem pending = new ComboBoxItem();
            pending.Content = Commons.Pending;
            this.statusCtrl.Items.Add(pending);
            ComboBoxItem inProgress = new ComboBoxItem();
            inProgress.Content = Commons.InProgress;
            this.statusCtrl.Items.Add(inProgress);
            ComboBoxItem ready = new ComboBoxItem();
            ready.Content = Commons.Ready;
            this.statusCtrl.Items.Add(ready);
            this.statusCtrl.SelectedIndex = Commons.statToIndex[this.status];
            row.Children.Add(this.statusCtrl);

            this.checkOutButtonCtrl = new Button();
            this.checkOutButtonCtrl.Content = "Check out";
            this.checkOutButtonCtrl.Height = 25;
            this.checkOutButtonCtrl.Width = 11 * width / 24;
            DateTime now = DateTime.Now;
            if ((now - this.visitDate).TotalHours < 5) {
                this.checkOutButtonCtrl.IsEnabled = false;
            }
            row.Children.Add(this.checkOutButtonCtrl);

            return row;
        }

        public StackPanel GetStatusRow() {
            StackPanel row = new StackPanel();
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 80) / 5;

            row.Orientation = Orientation.Horizontal;

            TextBox vCode = new TextBox();
            vCode.Text = this.visitCode;
            vCode.Width = width;
            vCode.Height = 50;
            vCode.FontSize = 22;
            vCode.TextAlignment = TextAlignment.Center;
            vCode.VerticalContentAlignment = VerticalAlignment.Center;
            vCode.Background = Brushes.Black;// (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9B9595"));
            vCode.Foreground = Brushes.White;
            vCode.IsReadOnly = true;
            row.Children.Add(vCode);

            TextBox vName = new TextBox();
            vName.Text = this.visitorName;
            vName.Width = width;
            vName.Height = 50;
            vName.FontSize = 22;
            vName.TextAlignment = TextAlignment.Center;
            vName.VerticalContentAlignment = VerticalAlignment.Center;
            vName.Background = Brushes.Black;// (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9B9595"));
            vName.Foreground = Brushes.White;
            vName.IsReadOnly = true;
            row.Children.Add(vName);

            TextBox checkIn = new TextBox();
            checkIn.Text = this.visitDate.ToString("h:mm tt");
            checkIn.Width = width;
            checkIn.Height = 50;
            checkIn.FontSize = 22;
            checkIn.TextAlignment = TextAlignment.Center;
            checkIn.VerticalContentAlignment = VerticalAlignment.Center;
            checkIn.Background = Brushes.Black;// (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9B9595"));
            checkIn.Foreground = Brushes.White;
            checkIn.IsReadOnly = true;
            row.Children.Add(checkIn);

            TextBox est = new TextBox();
            est.Text = (this.eta != null) ? ((DateTime)this.eta).ToString("h:mm tt") : "To be confirmed";
            if (this.status == Commons.Ready || this.status == Commons.Completed) {
                est.Text = "Completed";
            }
            est.Width = width;
            est.Height = 50;
            est.FontSize = 22;
            est.TextAlignment = TextAlignment.Center;
            est.VerticalContentAlignment = VerticalAlignment.Center;
            est.Background = Brushes.Black;// (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF9B9595"));
            est.Foreground = Brushes.White;
            est.IsReadOnly = true;
            row.Children.Add(est);

            TextBox stat = new TextBox();
            stat.Text = this.status;
            stat.Width = width;
            stat.Height = 50;
            stat.FontSize = 22;
            stat.TextAlignment = TextAlignment.Center;
            stat.VerticalContentAlignment = VerticalAlignment.Center;
            stat.Foreground = Brushes.White;
            if (this.status == Commons.Pending) {
                stat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fa5c1e"));
            } else if (this.status == Commons.InProgress) {
                stat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#fcdb03"));
                //stat.Foreground = Brushes.Black;
            } else if (this.status == Commons.Ready) {
                stat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008800"));
            } else if (this.status == Commons.Completed) {
                stat.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#008800"));
                stat.Text = "Collected";
            }
            stat.IsReadOnly = true;
            row.Children.Add(stat);

            return row;
        }

        public StackPanel GetCheckoutRow() {
            StackPanel row = new StackPanel();
            double width = (Commons.Instance.mainNavWindow.ActualWidth - 200) / 4;

            row.Orientation = Orientation.Horizontal;

            TextBox vCode = new TextBox();
            vCode.Width = width;
            vCode.Height = 50;
            vCode.FontSize = 22;
            vCode.Text = this.visitCode;
            vCode.IsReadOnly = true;
            row.Children.Add(vCode);

            TextBox vName = new TextBox();
            vName.Width = width;
            vName.Height = 50;
            vName.FontSize = 22;
            vName.Text = this.visitorName;
            vName.IsReadOnly = true;
            row.Children.Add(vName);

            TextBox coy = new TextBox();
            coy.Width = width;
            coy.Height = 50;
            coy.FontSize = 22;
            coy.Text = this.company;
            coy.IsReadOnly = true;
            row.Children.Add(coy);

            TextBox pName = new TextBox();
            pName.Width = width;
            pName.Height = 50;
            pName.FontSize = 22;
            pName.Text = this.visiteeName;
            pName.IsReadOnly = true;
            row.Children.Add(pName);

            this.checkOutButtonCtrl = new Button();
            this.checkOutButtonCtrl.Content = "Check out";
            this.checkOutButtonCtrl.Height = 50;
            this.checkOutButtonCtrl.FontSize = 20;
            this.checkOutButtonCtrl.Width = 5*width/12;
            row.Children.Add(this.checkOutButtonCtrl);

            return row;
        }
    }
}
