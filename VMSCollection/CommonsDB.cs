using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCollection {
    public partial class Commons {
        private ConnParams connParameters;
        private MySqlConnection conn;

        public void ConnectToDB() {
            string json = System.IO.File.ReadAllText(this.connParamsFilePath);
            this.connParameters = JsonConvert.DeserializeObject<ConnParams>(json);

            string connString = String.Format("server={0};userid={1};password={2};database={3}", this.connParameters.target_host, this.connParameters.target_user, this.connParameters.target_password, this.connParameters.target_db);
            this.conn = new MySqlConnection(connString);
            Console.WriteLine("Connected to {0} at {1}", this.connParameters.target_db, this.connParameters.target_host);
        }

        public void RetrieveUserList() {
            try {
                this.userDict = new Dictionary<string, User>();
                this.userList = new List<User>();
                this.conn.Open();
                string stm = String.Format("select * from {0}", this.connParameters.vms_users);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read()) {
                    string userName = result.GetString(0).ToLower();
                    string pw = result.GetString(1);
                    string role = result.GetString(2);
                    User newUser = new User(userName, pw, role);
                    this.userDict[userName] = newUser;
                    this.userList.Add(newUser);
                }
            }
            finally {
                this.conn.Close();
            }
        }

        private int GetVisitCount() {
            try {
                this.conn.Open();
                string stm = String.Format("select count(*) from {0}", this.connParameters.vms_table);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                MySqlDataReader result = cmd.ExecuteReader();
                int count = 0;
                while (result.Read()) {
                    count = (int)result.GetUInt32(0);
                }
                return count;
            }
            finally {
                this.conn.Close();
            }
        }

        public void SaveVisitInfoToDB(VisitInfo info) {
            try {
                this.conn.Open();
                string stm = String.Format("insert into {0} values (\"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", " +
                    "\"{6}\", \"{7}\", \"{8}\", \"{9}\", \"{10}\", NULL, NULL, \"{11}\", \"{12}\", NULL, NULL, NULL)",
                    connParameters.vms_table, info.visitCode, info.visitDate.ToString("yyyy-MM-dd HH:mm:ss"), info.visitorName, info.visitorEmail,
                    info.company, info.jobTitle, info.country, info.phoneNum, info.visiteeName,
                    info.visiteeEmail, info.status, info.visitDate.ToString("yyyy-MM-dd HH:mm:ss"));
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }

        public void RetrieveVisitsFromDB(int mode) {
            try {
                List<VisitInfo> visitList = new List<VisitInfo>();

                this.conn.Open();
                string stm = string.Empty;
                if (mode == Commons.Records) {
                    stm = String.Format("select * from {0} where cast(`Visit Date` as Date)=\"{1}\" or Status<>\"{2}\"", this.connParameters.vms_table, DateTime.Now.ToString("yyyy-MM-dd"), Commons.Completed);
                } else if (mode == Commons.Checkout) {
                    stm = String.Format("select * from {0} where Status<>\"{1}\"", this.connParameters.vms_table, Commons.Completed);
                }
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                MySqlDataReader result = cmd.ExecuteReader();
                while (result.Read()) {
                    var checkOutVar = result.GetValue(10);
                    var etaVar = result.GetValue(11);
                    DateTime? checkOut = null;
                    DateTime? eta = null;

                    if (checkOutVar.GetType() != typeof(System.DBNull) && etaVar.GetType() == typeof(System.DBNull)) {
                        checkOut = result.GetDateTime(10);
                    }
                    else if (checkOutVar.GetType() == typeof(System.DBNull) && etaVar.GetType() != typeof(System.DBNull)) {
                        eta = result.GetDateTime(11);
                    }

                    var inProgVar = result.GetValue(14);
                    var readyVar = result.GetValue(15);
                    var compVar = result.GetValue(16);
                    DateTime? inProg = null;
                    DateTime? ready = null;
                    DateTime? comp = null;

                    if (inProgVar.GetType() != typeof(System.DBNull)) {
                        inProg = result.GetDateTime(14);
                    }

                    if (readyVar.GetType() != typeof(System.DBNull)) {
                        ready = result.GetDateTime(15);
                    }

                    if (compVar.GetType() != typeof(System.DBNull)) {
                        comp = result.GetDateTime(16);
                    }

                    string visitCode = result.GetString(0);
                    DateTime visitDate = result.GetDateTime(1);
                    string visitorName = result.GetString(2);
                    string visitorEmail = result.GetString(3);
                    string company = result.GetString(4);
                    string jobTitle = result.GetString(5);
                    string country = result.GetString(6);
                    string phoneNum = result.GetString(7);
                    string visiteeName = result.GetString(8);
                    string visiteeEmail = result.GetString(9);
                    string status = result.GetString(12);
                    DateTime pend = result.GetDateTime(13);

                    VisitInfo newVisit = new VisitInfo(visitCode, visitDate, visitorName, visitorEmail, company,
                        jobTitle, country, phoneNum, visiteeName, visiteeEmail, checkOut, eta, status,
                        pend, inProg, ready, comp);

                    visitList.Add(newVisit);
                }

                this.listOfVisits = visitList;
            }
            finally {
                this.conn.Close();
            }
        }

        //public List<VisitInfo> RetrievePastRecords(DateTime start, DateTime end) {
        //    try {
        //        List<VisitInfo> visitList = new List<VisitInfo>();
        //        this.conn.Open();
        //        string stm = String.Format("select * from {0} where cast(`Visit Date` as Date)>=\"{1}\" and cast(`Visit Date` as Date)<=\"{2}\"", this.connParameters.vms_table, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
        //        MySqlCommand cmd = new MySqlCommand(stm, this.conn);
        //        MySqlDataReader result = cmd.ExecuteReader();

        //        while (result.Read()) {
                    
        //        }

        //        return visitList;
        //    }
        //    finally {
        //        this.conn.Close();
        //    }
        //}

        public void AddUserToDB(User user) {
            try {
                this.conn.Open();
                string stm = String.Format("insert into {0} values (\"{1}\", \"{2}\", \"{3}\")", this.connParameters.vms_users, user.id, user.password, user.role);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }

        public void DeleteUserFromDB(User user) {
            try {
                this.conn.Open();
                string stm = String.Format("delete from {0} where user=\"{1}\" and password=\"{2}\" and role=\"{3}\"", this.connParameters.vms_users, user.id, user.password, user.role);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }

        public void UpdateChangeToDB(VisitInfo info, DateTime? newEta) {
            try {
                this.conn.Open();
                string stm = String.Format("update {0} set ETA=\"{1}\" where `Visit Date`=\"{2}\" and `Visitor Name`=\"{3}\"",
                    this.connParameters.vms_table, ((DateTime)newEta).ToString("yyyy-MM-dd HH:mm:ss"), info.visitDate.ToString("yyyy-MM-dd HH:mm:ss"), info.visitorName);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }

        public void UpdateChangeToDB(VisitInfo info, string newStat, DateTime time) {
            try {
                this.conn.Open();
                string stm = String.Format("update {0} set Status=\"{1}\", `{2}`=\"{3}\" where `Visit Date`=\"{4}\" and `Visitor Name`=\"{5}\"",
                    this.connParameters.vms_table, newStat, newStat, time.ToString("yyyy-MM-dd HH:mm:ss"), info.visitDate.ToString("yyyy-MM-dd HH:mm:ss"), info.visitorName);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }

        public void UpdateChangeToDB(DateTime checkout, VisitInfo info) {
            try {
                this.conn.Open();
                string stm = String.Format("update {0} set Status=\"{1}\", ETA=NULL, Checkout=\"{2}\" where `Visit Date`=\"{3}\" and `Visitor Name`=\"{4}\"",
                    this.connParameters.vms_table, Commons.Completed, checkout.ToString("yyyy-MM-dd HH:mm:ss"), info.visitDate.ToString("yyyy-MM-dd HH:mm:ss"), info.visitorName);
                MySqlCommand cmd = new MySqlCommand(stm, this.conn);
                cmd.ExecuteNonQuery();
            }
            finally {
                this.conn.Close();
            }
        }
    }
}
