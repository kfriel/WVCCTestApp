using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WVCCTestApp {
    class ContactInfoMgr {
      #region Declarations
        ContactRec myContactRec = new ContactRec();     //Setup Contact Info instance
        PhoneRec myPhoneList = new PhoneRec();          //Set up Phone List instance
        private static int _PIndex;
        private SQLServer _MySession;

      #endregion

      #region Data Management Fields
        //Session contaner
        public SQLServer MySession {
            get { return _MySession; }
            set { _MySession = value; }
        }

      #endregion

      #region Phone Number functions
        //ToDo:Add new phone number
        public void AddNewNumber() { }

        //ToDo:Flag Main Phone Number
        public void FlagMainNumber() { }

        //ToDo:Flag phonenumber as archived
        public void ArchivePhoneNum() { }
      #endregion

      #region Address functions
        //ToDo:Add new Address
        public void AddNewAddress() { }

        //ToDo:Flag Main Address
        public void FlagMainAddress() { }

        //ToDo:Flag contact as archived
        public void ArchiveAddress() { }
      #endregion

      #region General Contact Information Management functions
        //ToDo:Contact Information Collection manager
        public string ContactRecMgr(string cmd, ContactRec CRec) {
            switch (cmd) {
                case "Get":
                //ToDo:Get Contact Info collection
                case "Add":
                //ToDo:Add Record to collection
                case "Delete":
                //ToDo:Delete record from collection
                case "Update":
                //ToDo:Update record
                default:
                    return "Invalid"; 
            }

        }

        //ToDo:Phone Information Collection manager
        public string PhoneInfoMgr(string cmd, PhoneRec PRec) {
            switch (cmd) {
                case "Create Collection":
                //ToDo:Create Contact Info collection
                case "Add":
                //ToDo:Add Record to collection
                case "Delete":
                //ToDo:Delete record from collection
                case "Update":
                //ToDo:Update record
                default:
                    return "Invalid"; 
            }
        }

        //DataTable Parser
        public void parseContactInfo(SqlDataReader DataToParse) {
            DataTable _DataToParse = new DataTable("_DataToParse");
            //ToDo: add MdnName and MName to stored procedure and parser
            string[] selectedSubjectInfoCols = new[] { "WVCCID","FName","LName","SSN",
                                                       "CallProcessStatus",
                                                       "ContactStatus","LastCalled",
                                                       "CallAttempts","CallCount" };
            string[] selectedContactInfoCols = new[] { "CIID", "AddressLine1",
                                                       "AddressLine2","Apt","City",
                                                       "State","Zip","CRank",
                                                       "MainAddress","MailingAdrs" };
            string[] selectedPhoneInfoCols = new[] { "TID", "PhoneNumber",
                                                     "MainNumber","PRank" };

            _DataToParse.Load(DataToParse);        //Put record set in Datatable

            DataTable pSubjectInfo = new DataView(_DataToParse).ToTable(false, selectedSubjectInfoCols);
            DataTable pContactList = new DataView(_DataToParse).ToTable(false, selectedContactInfoCols);
            DataTable pPhoneList = new DataView(_DataToParse).ToTable(false, selectedPhoneInfoCols);

            //Pass temp datatables to respective DataTable fields
            WVCCTestApp.SubjectInfo.loadSubjectInfo(pSubjectInfo);   //Send data to parser
            myContactRec.ContactList = pContactList;            //Pass data table
            myContactRec.CRecPtr = 0;                           //Set initial record pointer
            myContactRec.CRecMax = pContactList.Rows.Count;     //Set max number of records
            myContactRec.LoadRec();                             //Load first record to GUI

            //Load first record to GUI
            myPhoneList.PhoneList = pPhoneList;                 //Pass data table
            myPhoneList.PRecPtr = 0;                            //Set initial record pointer
            myPhoneList.PRecMax = pSubjectInfo.Rows.Count;      //Set max number of records
            //Todo:Load first record to GUI

            //Clean-up
            pSubjectInfo.Dispose();
            pContactList.Dispose();
            pPhoneList.Dispose();
        }

        //ToDo:Get Contact Information  hold:
        public void GetContactInfo(SQLServer MySession , string WVCCID) {
            SqlDataReader ContactInfoRecSet;
            string tempsql = "EXEC dbo.GetSubjectInfo '[WVCCID]', '[id]', '[SessionKey]';";
            tempsql = tempsql.Replace("[WVCCID]", WVCCID);  //Replace ID
            ContactInfoRecSet = MySession.queryDB(tempsql); //Get Record Set
            if (ContactInfoRecSet != null) {
                parseContactInfo(ContactInfoRecSet);        //Load data into contact table
                ContactInfoRecSet.Dispose();
            }
        }

        //Display Contact Info record
        public void DisplayContactInfo(int Dindex = 0) {
            if (Dindex == 0) {
                //ToDo:Get Cindex and increment it
            }
            else {
                //ToDo:Set Cindex to Dindex
            }
        }
      #endregion

      #region Class Error Handler
        //ToDo:
      #endregion
    }
}
