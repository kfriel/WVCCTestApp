using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WVCCTestApp 
{
    class CallListManager 
    {
      #region Declarations
        //SQLServer MySession = new SQLServer();
        UserInfo UI = new UserInfo();
        System.Data.DataTable _myCallList = new System.Data.DataTable("_myCallList");
        public int _UserAssignment;
        private SQLServer _MySession;
        //CallListCL MyCallList = new CallListCL();          // Create collection object
        //CallListDM MyCallList = new CallListDM();          // Data Model Properties for call list data
      #endregion

        #region  Dependency Properties
        //Session information
        public SQLServer MySession {
            get { return _MySession; }
            set { _MySession = value; }
        }

        // Call List object
        public DataTable CallList 
        {
            get { return _myCallList; }
            set { _myCallList = value; }
        }

        // Field for UserAssignment
        public int UserAssignment
        {
            get { return UI.UserAssignment; }
            set { _UserAssignment = value; }
        }
      #endregion


      #region functions 
        // Method for creating call list data collection
        public void GetCList() 
        {
            if ((UserAssignment == 1) || (UserAssignment == 2) || (UserAssignment == 3)) 
            {
                SqlDataReader ListRecSet;

                string tempsql = "EXEC dbo.allocateSubjects '[NumToAlocate]', '[id]', '[SessionKey]', '[UserAssignment]';";
                tempsql = tempsql.Replace("[UserAssignment]", UserAssignment.ToString()); // Configuration for getting vets by bucket (allocate subjects stored proc)
                ListRecSet = MySession.queryDB(tempsql);        //Get Record Set
                load(ListRecSet);                               //Pass record set to datatable
               // Console.WriteLine(UserAssignment);
               // Console.WriteLine(NumToAlocate);
            }
        }

        //Load recordset into data table
        public void load(SqlDataReader ListRecSet) 
        {
            if (ListRecSet != null) 
            {
                CallList.Load(ListRecSet);            // Load record set into datatable
                ListRecSet.Dispose();                 // Clear container

                if (!_myCallList.Columns.Contains("Used")) 
                {
                    CallList.Columns.Add("Used", typeof(System.Boolean));     // Add data used column
                    CallList.Columns.Add("Delete", typeof(System.Boolean));   // Add delete flag column
                    CallList.Columns.Add("New", typeof(System.Boolean));      // Add new data flag colum
                    foreach (DataRow rec in _myCallList.Rows) {                  // Set initial value for new columns
                        rec["Used"] = 0;
                        rec["Delete"] = 0;
                        rec["New"] = 0;
                    }
                }
                CallList.AcceptChanges();                                 // Commit changes to the datatable
            }
            else { // ToDo:ListRecSet is null - handle error
                Console.WriteLine("Error:ListRecSet is null");
            }
        }

        //Remove call list entry by index
        public void RemoveRecByIndex(int tdIndex) 
        {
            CallList.Rows[tdIndex].Delete();
        }

        //Remove call list entry by WVCCID
        public void RemoveRecByID(string wvccid) 
        {

        }

        //Empty call list
        public void Empty() 
        {
            CallList.Clear();
        }

        // Method to Dispose of MyCallList object
        public void Dispose() 
        {
            CallList.Dispose();
            GC.SuppressFinalize(this);
        }
      #endregion
    }
}

//DbDataAdapter.fill method http://msdn.microsoft.com/en-us/library/905keexk%28v=vs.110%29.aspx
