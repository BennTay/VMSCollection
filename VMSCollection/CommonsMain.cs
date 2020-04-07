using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace VMSCollection {
    public partial class Commons {
        // Singleton pattern
        private static Commons instance = null;
        private static readonly object padlock = new object();

        // Class attributes
        private static bool productionMode = false;
        public NavigationWindow mainNavWindow;

        // Instance attributes
        private static string[] boxPaths = { @"C:\Users", Environment.UserName, "Box", "VMSCollectionApp", "app" };
        private string boxDirectory = Path.Combine(boxPaths);
        private const string prodConnParamsFile = "conn_params_viralcom.json";
        private const string testConnParamsFile = "conn_params_viralcomtest.json";
        public readonly string connParamsFilePath;

        // Common strings
        public const string Pending = "Pending";
        public const string InProgress = "In progress";
        public const string Ready = "Ready for handover";
        public const string Completed = "Completed";
        // Stat to Index map
        public static Dictionary<string, int> statToIndex = new Dictionary<string, int>();

        // User roles
        public const string Guard = "Guard";
        public const string Releasing = "Releasing";
        public const string Admin = "Admin";
        public const string CCC = "CCC";
        public const string Root = "root";

        // Visitor Number overflow
        public const int Overflow = 1000;

        // Sound effects
        private static string soundPath = "pingalert.wav";
        private SoundPlayer player = new SoundPlayer();

        // Other
        public const int Records = 1;
        public const int Checkout = 2;

        private Commons() {
            // Initialize
            if (productionMode) {
                this.connParamsFilePath = Path.Combine(boxDirectory, prodConnParamsFile);
                soundPath = Path.Combine(boxDirectory, soundPath);
            }
            else {
                this.connParamsFilePath = testConnParamsFile;
            }

            statToIndex[Pending] = 0;
            statToIndex[InProgress] = 1;
            statToIndex[Ready] = 2;
            statToIndex[Completed] = 3;

            this.ConnectToDB();
            //this.RetrieveVisitsFromDB();
            this.RetrieveUserList();

            this.player.SoundLocation = soundPath;
            player.Load();
        }

        public static Commons Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new Commons();
                    }
                    return instance;
                }
            }
        }

        public void PlayNewVisitorAlert() {
            this.player.Play();
        }
    }
}
