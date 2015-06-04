using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WVCCTestApp {
    class ContactRec {
      #region Declarations
        DataTable _ContactList = new DataTable("_ContactList");
        private static string _Address1, _Address2, _Apt, _City, _State, _Zip;
        private static int _CID, _CRecPtr, _CRecMax, _CRank;
        private static bool _Address1Chngd, _Address2Chngd, _AptChngd, 
                            _CityChngd, _StateChngd, _ZipChngd, _CRankChngd,
                            _MainAddress, _MainAddChangd, _MailingAdsChng,
                            _MailingAdrs, _ArchiveIt, _ArchiveItChngd, 
                            _DeleteIt, _DeleteItChngd;
      #endregion

      #region ContactRec Properties
        //Contact List {Datatable}
        public DataTable ContactList {
            get { return _ContactList; }
            set { _ContactList = value; }
        }

        //CIndex, current contact index
        public int CRecPtr {
            get { return _CRecPtr; }
            set { _CRecPtr = value; }
        }

        //CRecMax. Number of records
        public int CRecMax {
            get { return _CRecMax; }
            set { _CRecMax = value; }
        }

        //CID
        public static int CID {
            get { return _CID; }
            set { _CID = value; }
        }

        //Address1
        public static bool Address1Chngd {
            get { return _Address1Chngd; }
            set { _Address1Chngd = value; }
        }
        public static string Address1 {
            get { return _Address1; }
            set { _Address1 = value;
                  Address1Chngd = true;
            }
        }

        //ToDo impliment in GUI:Address2
        public static bool Address2Chngd {
            get { return _Address2Chngd; }
            set { _Address2Chngd = value; }
        }
        public static string Address2 {
            get { return _Address2; }
            set { _Address2 = value;
                  Address2Chngd = true;
            }
        }
        
        //ToDo impliment in GUI:Apt
        public static bool AptChngd {
            get { return _AptChngd; }
            set { _AptChngd = value; }
        }
        public static string Apt {
            get { return _Apt; }
            set { _Apt = value;
                  AptChngd = true;
            }
        }

        //City
        public static bool CityChngd {
            get { return _CityChngd; }
            set { _CityChngd = value; }
        }
        public static string City {
            get { return _City; }
            set { _City = value;
                  CityChngd = true;
            }
        }

        //State
        public static bool StateChngd {
            get { return _StateChngd; }
            set { _StateChngd = value; }
        }
        public static string State {
            get { return _State; }
            set { _State = value;
                  StateChngd = true;
            }
        }

        //Zip
        public static bool ZipChngd {
            get { return _ZipChngd; }
            set { _ZipChngd = value; }
        }
        public static string Zip {
            get { return _Zip;}
            set { _Zip = value;
                  ZipChngd = true;
            }
        }

        //ToDo impliment in GUI:CRank
        public static bool CRankChngd {
            get { return _CRankChngd; }
            set { _CRankChngd = value; }
        }
        public static int CRank {
            get { return _CRank; }
            set { _CRank = value;
                  CRankChngd = true;
            }
        }
        
        //ToDo impliment in GUI:MainAddress
        public static bool MainAddChngd {
            get { return _MainAddChangd; }
            set { _MainAddChangd = value; }
        }
        public static bool MainAddress {
            get { return _MainAddress; }
            set { _MainAddress = value;
                  MainAddChngd = true;
            }
        }

        //ToDo impliment in GUI:MailingAdrs
        public static bool MailingAdsChng {
            get { return _MailingAdsChng; }
            set { _MailingAdsChng = value; }
        }
        public static bool MailingAdrs {
            get { return _MailingAdrs; }
            set { _MailingAdrs = value;
                  MailingAdsChng = true;
            }
        }

        //Archiveit
        public static bool ArchiveItChngd {
            get { return _ArchiveItChngd; }
            set { _ArchiveItChngd = value; }
        }
        public static bool ArchiveIt {
            get { return _ArchiveIt; }
            set { _ArchiveIt = value;
                  ArchiveItChngd = true;
            }
        }

        //DeleteIt
        public static bool DeleteItChngd {
            get { return _DeleteItChngd; }
            set { _DeleteItChngd = value; }
        }
        public static bool DeleteIt {
            get { return _DeleteIt; }
            set { _DeleteIt = value;
                  DeleteItChngd = true;
            }
        }
      #endregion
        
      #region Contact Infomation Functions
        public void RoleContactList(string cmd) {
            switch (cmd) {
                case "Next":
                    if (CRecPtr == CRecMax) { CRecPtr = 1; }
                    else { CRecPtr = CRecPtr + 1; }
                    break;
                case "Prev":
                    if (CRecPtr == 0) { CRecPtr = CRecMax; }
                    else { CRecPtr = CRecPtr - 1; }
                    break;
                default:
                    break;
            }
            LoadRec();
            ResetChangeIndicators();
        }

        public void LoadRec() {
            Address1 = ContactList.Rows[CRecPtr].Field<string>("AddressLine1");
            Address2 = ContactList.Rows[CRecPtr].Field<string>("AddressLine2");
            Apt = ContactList.Rows[CRecPtr].Field<string>("Apt");
            City = ContactList.Rows[CRecPtr].Field<string>("City");
            State = ContactList.Rows[CRecPtr].Field<string>("State");
            Zip = ContactList.Rows[CRecPtr].Field<string>("Zip");
            CRank = ContactList.Rows[CRecPtr].Field<int>("CRank");
            MainAddress = ContactList.Rows[CRecPtr].Field<bool>("MainAddress");
            MailingAdrs = ContactList.Rows[CRecPtr].Field<bool>("MailingAdrs");

            ResetChangeIndicators();
        }

        private void ResetChangeIndicators() {
            Address1Chngd = false;
            Address2Chngd = false;
            AptChngd = false;
            CityChngd = false;
            StateChngd = false;
            ZipChngd = false;
            CRankChngd = false;
            MainAddChngd = false;
            MailingAdsChng = false;
            ArchiveItChngd = false;
            DeleteItChngd = false;
        }
      #endregion
        
        #region Class Error Handler
        //ToDo:
      #endregion
    }
}
