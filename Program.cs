using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Windows.Forms;

namespace WVCCTestApp {

#region Main Method
    class Program {
      #region Declarations
       
      #endregion

        [STAThread]
        static void Main() {
          #region Program Startup
            //Program objects initialized

            MainWindow MyMainWindow = new MainWindow();             // Iniate VM and form
            errHandler MyErrors = new errHandler();                 // central error handler            
            SQLServer MySession = new SQLServer();                  // SQLServer com class
            UserInfo MyUser = new UserInfo();                       // UserInfo class and data model
            BI MyCountClass = new BI();                             // BI Class Initialize for login screen to get Counts       

            OutboundSurvey OutSurvey = new OutboundSurvey();        // Initiate OutboundSurvey Screen
            
            CallListManager MyCallListMgr = new CallListManager();  // Call list class and data model
            ContactInfoMgr MyContactInfoMgr = new ContactInfoMgr(); // Contact information manager class
            
            //Set up DB session
            MakeConnection(MySession, MyUser);                      // Connect to SQL Server and get Session Key
            MyCountClass.GetCounts(MySession);                      // Get Intial Counts for Login Screen 
            // Distribute session object
            MyMainWindow.MySession = MySession;
            MyCallListMgr.MySession = MySession;
            // Distribute session object
            MyMainWindow.MySession = MySession;
            MyCallListMgr.MySession = MySession;
            MyCountClass.GetCounts(MySession);                      // Get Intial Counts for Login Screen       
            LoginWindow MyLoginWindow = new LoginWindow();          // Initiate Login Screen

          #endregion


            MyLoginWindow.Activate();                               // Activate Login Screen
            MyLoginWindow.ShowDialog();                             // Open Login Screen
            MyUser.PrintData();
           // MyCallListMgr.GetCList(MySession);                    // Get inital Call list
            OutSurvey.GetXAMLCode(MySession);                       // Get all xaml from db to populate windows
            OutSurvey.GetQuestions(MySession);                      // Get all questions from db to populate surveys
            OutSurvey.GetAnswers(MySession);                        // Get all questions from db to populate surveys           
            OutSurvey.Activate();                                   // Activate Login Screen
            OutSurvey.ShowDialog();                                 // Open Login Screen
          

          #region Main Program

            
            if (MySession.IsConnectionOpen()) {

                MyMainWindow.Online = true;

                MyUser.PrintData();
                MyCallListMgr.GetCList();                      // Get inital Call list
                MyMainWindow.CallList(MyCallListMgr.CallList.Copy());   //ToDo: (Test) Prime MyMainWindow CallList with data

                MyMainWindow.ShowDialog();
                OutSurvey.Activate(); 


                // ToDo: Individual testing enviornments - remove on build
                if (Control.ModifierKeys == Keys.Shift) {
                    // Intended program code
                    MyMainWindow.Online = true;
                    MyLoginWindow.ShowDialog();         // Open Login Screen
                    MyCallListMgr.GetCList();           // Get inital Call list
                    MyMainWindow.CallList(MyCallListMgr.CallList.Copy());   //ToDo: (Test) Prime MyMainWindow CallList with data
                    MyMainWindow.ShowDialog();
                }
                else {
                    switch (Environment.UserName.ToString()) {
                        case "VHACANSILVEE":
                            MyMainWindow.Online = true;
                            MyLoginWindow.ShowDialog();         // Open Login Screen
                            MyCallListMgr.GetCList();           // Get inital Call list
                            MyMainWindow.CallList(MyCallListMgr.CallList.Copy());   //ToDo: (Test) Prime MyMainWindow CallList with data
                            MyMainWindow.ShowDialog();
                            break;
                        case "VHACANFRIELK":
                            OutSurvey.GetQuestions(MySession);  // Get all questions from db to populate surveys
                            OutSurvey.GetAnswers(MySession);    // Get all questions from db to populate surveys
                            MyLoginWindow.ShowDialog();         // Open Login Screen
                            MyUser.PrintData();
                            OutSurvey.Activate();               // Activate Login Screen
                            OutSurvey.ShowDialog();             // Open Login Screen
                            break;
                    }
                }

            }
            else {
                //Handle errors
                System.Windows.MessageBox.Show("Error not yet handled.");
            }
          #endregion

            #region Testing
            // debug:Reading config file
            //Console.WriteLine("\n");
            //Console.WriteLine(MySession.serverPath);
            //Console.WriteLine(MySession.serverUserID);
            //Console.WriteLine(MySession.serverUserPW);
            //Console.WriteLine(MySession.wvccDatabase);
            //Console.WriteLine(MySession.NumRecsInList);
            //Console.WriteLine(MyUser.LogedIn);
            //Console.WriteLine("\n");
            //Console.WriteLine(MySession.SessionKey);
            //Console.WriteLine("\n");
            //Console.WriteLine("Call List");
            //Console.WriteLine(MyCallListMgr.CallList);
            //foreach (DataRow row in MyCallListMgr.CallList.Rows) {
            //    Console.WriteLine("--- Row ---"); // Print separator.
            //    foreach (var item in row.ItemArray) {
            //        Console.Write("Item: ");
            //        Console.WriteLine(item);
            //    }
            //}

            // ToDo: test of Subject info class - will be triggered by GUI
            //MySubjectInfo.GetSubInfo(MySession, "WVCC-0000001");

            //Console.ReadLine();                     // debug:Pause Console so feedback can be reviewed
            
            //MainWindow MyMainWindow = new MainWindow();  // Initialize GUI Main Window
          #endregion

          #region End Program
            System.Windows.MessageBox.Show("Shutting down the application.");

            MyMainWindow.Hide();                //ToDo: Kill the GUI thread

            MySession.killSession();            // Logout of the database nicely
                                                // ToDo: Provide successful logout message
            MySession.disconnectDB();           // Kill SQL Server Connection
                                                // ToDo: Provide successful disconnect message
            Console.ReadLine();                 // debug:Pause Console so feedback can be reviewed
            //MySubjectInfo = null;               // null objects for close
            MyCallListMgr.Dispose();           
            MyUser.Dispose();
            MySession = null;
            MyErrors = null;
          #endregion


        }
        //Server Connection
        private static void MakeConnection(SQLServer MySession, UserInfo MyUser) {
            int i = 0;
            while (MyUser.LogedIn == false) {
                MySession.wvccConnection = null;          // Setup sql server connection string
                MySession.connectDB();                    // Connect to database
                MySession.startSession();                 // Start session (get session key)
                if (String.IsNullOrEmpty(MySession.SessionKey)) {
                    MyUser.LogedIn = false;
                    i = i + 1;
                    // ToDo: add error handeling process here
                    if (i == 3) { Console.WriteLine("Throw connection error"); }
                }
                else { MyUser.LogedIn = true; }
            }
        }

        public void EventReceiver(string eventCtrl, string eventData) {
           
            //Send event date to Event manager in origional thread
           // MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
        }
    }
#endregion

}


// http://www.codeproject.com/?cat=3
// http://www.codeproject.com/Articles/4416/Beginners-guide-to-accessing-SQL-Server-through-C
// http://aspalliance.com/625
// http://msdn.microsoft.com/en-us/library/67ef8sbd.aspx
// http://msdn.microsoft.com/en-us/library/w86s7x04.aspx
// http://msdn.microsoft.com/en-us/library/aa664653(v=vs.71).aspx