using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCollection {
    public partial class Commons {

        public List<VisitInfo> listOfVisits;
        public Dictionary<string, User> userDict;
        public List<User> userList;
        public User currUser;
        private bool fullscreen = false;
        
        public void SaveVisit(VisitInfo info) {
            this.SaveVisitInfoToDB(info);
            //this.RetrieveVisitsFromDB();
        }

        public string GetNextVisitNum() {
            string num = (this.GetVisitCount() % Overflow).ToString();
            string visitNum = "CC";
            int iter = 3 - num.Length;
            for (int i = 0; i < iter; i++) {
                num = "0" + num;
            }
            visitNum += num;
            return visitNum;
        }

        public void ToggleFullScreen() {
            if (fullscreen) {
                this.mainNavWindow.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
                this.mainNavWindow.WindowState = System.Windows.WindowState.Normal;
                fullscreen = false;
            }
            else {
                this.mainNavWindow.WindowStyle = System.Windows.WindowStyle.None;
                this.mainNavWindow.WindowState = System.Windows.WindowState.Maximized;
                fullscreen = true;
            }
        }
    }
}
