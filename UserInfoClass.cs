using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVCCTestApp {
    
    
    // Handles all user information

    public class UserInfo {

      #region Declarations
        private string _UserID, _UserFName, _UserLName, _MachineName, _SessionID;
        private static int _UserShift, _UserAssignment;
        private bool _LogedIn;
      #endregion

       
        #region Pull Fields from Login Window Entries (shift and assignment)
             
       // LoginWindow lw = new LoginWindow();
        
        #endregion


        #region User information fields
        // Creates field holding user login id
        public string UserID {
            get { return _UserID != null ? _UserID : Environment.UserName; }
            set { _UserID = Environment.UserName; }
        }

        // Creates field holding user's machine name
        public string MachineName 
        {
            get { return _MachineName != null ? _MachineName : Environment.MachineName; }
            set { _MachineName = Environment.MachineName; }
        }

        // Field to get and hold session id from sql server
        public string SessionID 
        {
            get { return _SessionID != null ? _SessionID : "run method to get session id"; }
            set { _SessionID = value; }
        }

        // Field to handle user's shift
        public int UserShift
        {
            get { return _UserShift != 0 ? _UserShift : LoginWindow._shifty; }
            set { _UserShift = value; }
        }

        // Field to handle assignment
        public int UserAssignment
        {
            get { return _UserAssignment != 0 ? _UserAssignment : LoginWindow._assign; }
            set { _UserAssignment = value; }
        }

        // Function to print shift and assignment values (testing purposes only)
        public void PrintData()
        {
            Console.WriteLine(UserShift);
            Console.WriteLine(UserAssignment);
        }

        // Field for obtaining and holding the user's first name
        public string UserFName 
        {
            get { return _UserFName != null ? _UserFName : "run method to get user's first name"; } // ToDo: defalut to method to get shift
            set { _UserFName = value; }
        }

        // Field for obtaining and holding the user's last name
        public string UserLName 
        {
            get { return _UserLName != null ? _UserLName : "run method to get user's last name"; } // ToDo: defalut to method to get shift
            set { _UserLName = value; 
        }
     }

        // Field to indicate login status in sql server - this means the program has a live session id
        public bool LogedIn {
            get { return _LogedIn; }
            set { _LogedIn = value; }
        }

      #endregion

      #region User Info Functions
        

      #endregion



      #region Contact List Functions
        // Method for creating contact list
        public void GetContactList(SQLServer MySession,String SubID) { }

        //Load recordset into datatable
        public void loadCList(SqlDataReader ListRecSet) { }

        //Flag contact phone number as main
        public void PhoneNumMain() { }

        //Falg contact address as main
        public void AddressMain() { }

        // Dispose of contact list object
        public void Dispose() {
            GC.SuppressFinalize(this);
        }
      #endregion

      #region Class Error Handler

      #endregion

    }

      
}


// Datatable: http://msdn.microsoft.com/en-us/library/system.data.datatable%28v=vs.110%29.aspx
