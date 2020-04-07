using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCollection {
    class ConnParams {
        public string target_host { get; set; }
        public string target_user { get; set; }
        public string target_password { get; set; }
        public string target_db { get; set; }
        public string vms_table { get; set; }
        public string vms_users { get; set; }
    }
}
