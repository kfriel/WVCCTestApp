using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WVCCTestApp {
    // Handles communication with sql server
    public class SQLServer {
     #region Declarations
	    private const string filepath = "T:\\WVCC-Admin\\Eric\\WVCCconfig.txt";
        private string serverpath, serveruserid, serveruserpw, wvccdatabase, sessionkey;
        private int numrecsinlist;
       
        private SqlConnection wvccconnection;
        //private SQLServer _MySession;
     #endregion

     #region Configuration data
        //Server path object
        public string serverPath {
            get { return serverpath; }
            set { serverpath = serverPath; }
        }

        // Server user id object
        public string serverUserID {
            get { return serveruserid; }
            set { serveruserid = serverUserID; }
        }

        // Server user pw object
        public string serverUserPW {
            get { return serveruserpw; }
            set { serveruserpw = serverUserPW; }
        }

        // Server database name object
        public string wvccDatabase {
            get { return wvccdatabase; }
            set { wvccdatabase = wvccDatabase; }
        }

        // Field for number of records to hold in call list
        public int NumRecsInList {
            get { return numrecsinlist; }
            set { numrecsinlist = NumRecsInList; }
        }



        // Session key
        public string SessionKey {
            get { return sessionkey; }
        }
      #endregion

      #region configuration file reader
        // Load config data from file
        private void LoadConfig() {
            try {
                using (StreamReader sr = new StreamReader(filepath)) {
                    String line = sr.ReadToEnd();
                    serverpath = line.Split(new char[] { ':', '\n' })[1];
                    serveruserid = line.Split(new char[] { ':', '\n' })[3];
                    serveruserpw = line.Split(new char[] { ':', '\n' })[5];
                    wvccdatabase = line.Split(new char[] { ':', '\n' })[7];
                    numrecsinlist = Convert.ToInt32(line.Split(new char[] { ':', '\n' })[9]);

                    //Todo: Remove these debugging and logic check elements
                    Console.WriteLine("LoadConfig");
                    Console.WriteLine(serverpath);
                    Console.WriteLine(serveruserid);
                    Console.WriteLine(serveruserpw);
                    Console.WriteLine(wvccdatabase);
                    Console.WriteLine(numrecsinlist);
                    //Console.WriteLine(UserAssignment);
                    Console.WriteLine("\n");

                }
            }
            catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
     #endregion

     #region sql server connection
        public SqlConnection wvccConnection {
            set {
                LoadConfig();
                wvccconnection = new SqlConnection("password=" + serveruserpw + ";server=" + serverpath +
                                         ";" + "Initial Catalog=WVCCDev;" + "Integrated Security=True");
            }
            get { return wvccconnection; }
        }
     #endregion

     #region Connection Manager
        // Connect to SQL server
        public string connectDB() {
            try {
                wvccconnection.Open();
                Console.WriteLine("Connection Opened");
                return "Connected";
            }
            catch (Exception e) {
                return e.ToString();    //ToDo: handle this error
            }
        }

        // Disconnect from sql server
        public string disconnectDB() {
            try {
                wvccconnection.Close();
                Console.WriteLine("Connection Closed");
                return "Disconnected";
            }
            catch (Exception e) {
                return e.ToString();    //ToDo: handle this error
            }
        }

        // Get session key - creates dbase session (login)
        public void startSession() {
            string tempsql = "EXEC dbo.logIN 'LogIN', '[id]', '[mName]', '[shift]';";
            tempsql = tempsql.Replace("[id]", Environment.UserName);
            tempsql = tempsql.Replace("[mName]", Environment.MachineName);
            tempsql = tempsql.Replace("[shift]", "1");  //Todo: make this value a user input
            //ToDo: add Assignment to sql
            Console.WriteLine(tempsql);    // debug:
            try {
                SqlDataReader mySessionRead = null;
                SqlCommand startSessionCmd = new SqlCommand(tempsql, wvccconnection);
                mySessionRead = startSessionCmd.ExecuteReader();
                while (mySessionRead.Read()) 
                {
                    sessionkey = mySessionRead["SessionKey"].ToString();
                }
                mySessionRead.Dispose();
            }

            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());        //Todo: link to central error handeling function
            }
        }

        // kill sessionid - close dbase session (logout)
        public string killSession() {
            string SesKey = null;
            string tempsql = "EXEC dbo.logIN 'LogOUT', '[id]', '[mName]', '[shift]';";
            tempsql = tempsql.Replace("[id]", Environment.UserName);
            tempsql = tempsql.Replace("[mName]", Environment.MachineName);
            tempsql = tempsql.Replace("[shift]", "1");  //Todo: make this value a user input
            Console.WriteLine(tempsql);
            try {
                SqlDataReader mySessionRead = null;
                SqlCommand startSessionCmd = new SqlCommand(tempsql, wvccconnection);
                mySessionRead = startSessionCmd.ExecuteReader();
                while (mySessionRead.Read()) {
                    SesKey = mySessionRead["SessionKey"].ToString();
                }
                return SesKey;
            }

            catch (Exception e) {
                Console.WriteLine(e.ToString());        //Todo: link to central error handeling function
                return "Error";
            }
        }

        // Query the database
        public SqlDataReader queryDB(string sqlCommand) {           // ToDo: run arbatraury query

            // Load Query with configuration and Session details as needed
            string tempsql = sqlCommand;
            tempsql = secureQuery(tempsql);     //Secure sql statment with id and session key
            tempsql = tempsql.Replace("[NumToAlocate]", numrecsinlist.ToString());    // Configuration for some queries
           
            try {
                // Fire query and return dataset
                SqlDataReader mySessionRead = null;
                SqlCommand arbitraryQuery = new SqlCommand(tempsql, wvccconnection);
                mySessionRead = arbitraryQuery.ExecuteReader();
                    
                return mySessionRead;
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());    //ToDo: handle this error
                return null;
            }
        }

        //Handle adding id and session key to queries
        public string secureQuery(string sqlString){
            if (!String.IsNullOrEmpty(sqlString)) {
                sqlString = sqlString.Replace("[id]", Environment.UserName);                // Security for all queries
                sqlString = sqlString.Replace("[SessionKey]", sessionkey);
                return (sqlString);
            }
            else {
                return null;
            }
        }

        // test sql data base connection
        public bool IsConnectionOpen(bool reconnect = false ) {
            try {
                if (wvccconnection.State == ConnectionState.Open) {
                    return true;
                }
                else {
                    if(reconnect==true) {
                        wvccconnection.Open();
                        return true;
                    } else {
                        return false;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());    //ToDo: handle this error
                return false;
            }
        }
     #endregion

     #region Class Error Handler

     #endregion
    }
}
