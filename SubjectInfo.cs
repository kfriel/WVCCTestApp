using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVCCTestApp {
    class SubjectInfo {

      #region Declarations
        private static int? _CallAttempts, _CallCount;
        private static string _SID, _WVCCID, _FName, _LName, _MName, _MdnName;
        private static string _SSN, _CallProgressStatus, _ContactStatus;
        private static bool _SIDChanged, _WVCCIDChngd, _FNmChngd, _MNmChngd, 
            _LNmChngd, _MdnNmChngd, _SSNChngd, _CPSChngd, _CSChngd, _CDChngd,
            _LCdChngd, _CallAttChngd, _CallCntChngd;
        private static DateTime? _CreationDate, _LastCalled;
        DataTable _myContactList = new DataTable("myContactList");

      #endregion

      #region SubjectInfo data model
        // record row id
        public string SID {
            get { return _SID; }
            set { _SID = SID; SIDChanged = true; }
        }
        private bool SIDChanged {
            get{return _SIDChanged;}
            set{_SIDChanged = SIDChanged;}
        }
        
        //WVCCID
        private static bool WVCCIDChngd {
            get { return _WVCCIDChngd; }
            set { _WVCCIDChngd = value; }
        }
        public static string WVCCID {
            get { return _WVCCID; }
            set { _WVCCID = value; 
                  WVCCIDChngd = true; 
            }
        }

        //First Name
        private bool FNmChngd {
            get { return _FNmChngd; }
            set { _FNmChngd = FNmChngd; }
        }
        public static string FName {
            get { return _FName; }
            set { _FName = value;
                  _FNmChngd = true;
            }
        }
        
        //Last Name
        private bool LNmChngd {
            get { return _LNmChngd; }
            set { _LNmChngd = value; }
        }
        public static string LName {
            get { return _LName; }
            set {
                _LName = value;
                _LNmChngd = true;
            }
        }

        //Middle Name
        private bool MNmChngd {
            get { return _MNmChngd; }
            set { _MNmChngd = value; }
        }
        public static string MName {
            get { return _MName; }
            set { _MName = value;
                  _MNmChngd = true; }
        }
        
        //Maden Name
        public bool MdnNmChngd {
            get { return _MdnNmChngd; }
            set { _MdnNmChngd = value;
            }
        }
        public static string MdnName {
            get { return _MdnName; }
            set { _MdnName = value;
                  _MdnNmChngd = true; }
        }

        //SSN
        public static string SSN {
            get { return _SSN; }
            set { _SSN = value; 
                  _SSNChngd = true; }
        }
        private bool SSNChngd {
            get { return _SSNChngd; }
            set { _SSNChngd = value; }
        }

        //Call Progress Status
        public static string CallProgressStatus {
            get { return _CallProgressStatus; }
            set { _CallProgressStatus = value; 
                  _CPSChngd = true; }
        }
        private bool CPSChngd {
            get { return _CPSChngd;}
            set { _CPSChngd = value; }
        }

        //Contact Status
        public static string ContactStatus {
            get { return _ContactStatus; }
            set { _ContactStatus = value; 
                  _CSChngd = true; }
        }
        private bool CSChngd {
            get { return _CSChngd; }
            set { _CSChngd = value; }
        }

        //Creation Date
        public static DateTime? CreationDate {
            get { return _CreationDate; }
            set { _CreationDate = value; 
                  _CDChngd = true; }
        }
        private bool CDChngd {
            get { return _CDChngd; }
            set { _CDChngd = value; }
        }

        // date Last Called
        public static DateTime? LastCalled {
            get { return _LastCalled; }
            set { _LastCalled = value; 
                  _LCdChngd = true; }
        }
        private bool LCdChngd {
            get { return _LCdChngd; }
            set { _LCdChngd = value; }
        }

        //Call Attempts
        public static int? CallAttempts {
            get { return _CallAttempts; }
            set { _CallAttempts = value;
                  _CallAttChngd = true;
            }
        }
        private bool CallAttChngd {
            get { return _CallAttChngd; }
            set { _CallAttChngd = value; }
        }

        //Call Count
        public static int? CallCount {
            get { return _CallCount; }
            set { _CallCount = value;
                  _CallCntChngd = true;
            }
        }
        private bool CallCntChngd {
            get { return _CallCntChngd; }
            set { _CallCntChngd = value; }
        }

        // Subject contact information
        public DataTable ContactList {
            get { return _myContactList; }
            set { _myContactList = ContactList; }
        }
      #endregion

      #region Subjectinfo functions
        //Method for creating subjectInfo
        //https://msdn.microsoft.com/en-us/library/system.data.dataset%28v=vs.110%29.aspx
        //http://stackoverflow.com/questions/8983277/how-to-convert-dataset-to-datatable
        //ToDo: Finish changing over from using SqlDataReader to SqlDataAdapter
        public void GetSubInfo(SQLServer MySession, string WVCCID) {
            if (WVCCID != null | MySession != null) {
                try {
                  //Build
                    //sql cmd build
                    string tempsql = "EXEC dbo.GetSubjectInfo '" + WVCCID + "','[id]' , '[SessionKey]';";
                    tempsql = MySession.secureQuery(tempsql);
                    //Intialize adapter and DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter();          
                    DataTable SubjectInfoTB = new DataTable("SubjectInfoTB");
                    DataTable ContactInfoTB = new DataTable("ContactInfoTB");
                 //Get Data
                    SqlCommand command = new SqlCommand(tempsql, MySession.wvccConnection);
                    adapter.SelectCommand = command;
                    adapter.Fill(SubjectInfoTB);
                 //Use
                    ContactInfoTB = SubjectInfoTB.Copy(); //Duplicate
                    if (SubjectInfoTB.Rows.Count > 0) {
                        loadSubjectInfo(SubjectInfoTB);     //Parse subject information into data model
                        loadSubjectInfo(ContactInfoTB);     //Parse contact information into data model

                    }
                  // Clean up
                    SubjectInfoTB.Dispose();
                    ContactInfoTB.Dispose();
                }
                catch (Exception e) {
                    //ToDo: Handle errors
                    Console.WriteLine("Error: " + e);
                }
            }
            else {
                //ToDo: Error handeling here
                Console.WriteLine("Error: WVCCID and/or MySession are/is null");
            }
        }

        //load recordset into classes
        public static void loadSubjectInfo(DataTable DataToParse) {
            //Pass pSubjectInfo values to subjectinfo fields
            WVCCID = DataToParse.Rows[0].Field<string>("WVCCID");
            FName = DataToParse.Rows[0].Field<string>("FName");
            LName = DataToParse.Rows[0].Field<string>("LName");
            //MdnName = DataToParse.Rows[0].Field<string>("MdnName");
            //MName = DataToParse.Rows[0].Field<string>("MName");
            SSN = DataToParse.Rows[0].Field<string>("SSN");
            LastCalled = DataToParse.Rows[0].Field<DateTime?>("LastCalled");
            ContactStatus = DataToParse.Rows[0].Field<string>("LName");
            CallProgressStatus = DataToParse.Rows[0].Field<string>("CallProcessStatus");
            ContactStatus = DataToParse.Rows[0].Field<string>("ContactStatus");
            CallAttempts = DataToParse.Rows[0].Field<int?>("CallAttempts");
            CallCount = DataToParse.Rows[0].Field<int?>("CallCount");
        }

        //ToDo:Generate dbase update sql
        public void GenerateUpdateSQL() {

        }

        //Reset Subject Info Class
        private void ResetSubinfo() {
            _SID = null;
            _WVCCID = null;
            _FName = null;
            _LName = null;
            _SSN = null;
            _CallProgressStatus = null;
            _ContactStatus = null;
            _CreationDate = null;
            _LastCalled = null;
            ResetChngFlags();
        }

        //Reset Subject Info change flags
        private void ResetChngFlags() {
            _SIDChanged = false;
            _WVCCIDChngd = false;
            _FNmChngd = false;
            _SSNChngd = false;
            _LNmChngd = false;
            _CPSChngd = false;
            _CSChngd = false;
            _CDChngd = false;
            _LCdChngd = false;
        }
      #endregion

      #region Class Error Handler
        //ToDo:
      #endregion
    }
}
