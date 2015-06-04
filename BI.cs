using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WVCCTestApp {

    public class BI {
        #region Declarations

        // private int _baseline, _followup;
        //private SqlConnection _MySession;
        private static string _unused;
        private static string _baseline;
        private static string _followup;
        // Intialize Variables to hold counts for login screen
        //private SqlConnection wvccconnection;

        #endregion
        //newCount
        public string unused {
            get { return _unused; }
            set { _unused = value; }
        }

        // baselineCount
        public string baseline {
            get { return _baseline; }
            set { _baseline = value; }
        }

        // followCount
        public string followup {
            get { return _followup; }
            set { _followup = value; }
        }


        #region functions

        // Method for creating call list data collection
        public void GetCounts(SQLServer MySession) 
        
        {
            string tempsql = "EXEC dbo.GetCount '[id]', '[SessionKey]';";
            tempsql = MySession.secureQuery(tempsql);
            //Get Data
            SqlCommand startSessionCmd = new SqlCommand(tempsql, MySession.wvccConnection);
            SqlDataReader myReader = startSessionCmd.ExecuteReader();
            while (myReader.Read()) {
                _unused = (myReader.GetInt32(0).ToString());
                _baseline = (myReader.GetInt32(1).ToString());
                _followup = (myReader.GetInt32(2).ToString());

                Console.WriteLine("Unused = {0}, Baseline = {1}, Followup = {2}", unused, baseline, followup);
           }
            myReader.Dispose();

        }
        #region Configuration data




        #endregion


        
    }
        #endregion

}
            
            //MySession.killSession();
            //MySession.disconnectDB();

          //  string tempsql = "EXEC dbo.GetCount '[id]', '[SessionKey]';";
          //  tempsql = MySession.secureQuery(tempsql);
          //  //SqlDataReader ListRecordSet = tempsql.ExecuteReader();    //Get Record Set
          //  SqlDataReader ListRecordSet = MySession.queryDB(tempsql);        //Get Record Set
         




    


