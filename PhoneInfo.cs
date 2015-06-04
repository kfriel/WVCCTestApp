using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WVCCTestApp {
    class PhoneRec {
      #region Field Declarations
        DataTable _PhoneList = new DataTable("_PhoneList");
        private static string _PhoneNum;
        private static int _PID, _PRecPtr, _PRecMax;
        private static int? _TZ;
        private static bool _PhoneChngd, _MainNum, _ArchiveIt, _DeleteIt, 
                            _MainNumChngd, _TZChngd, _ArchiveItChngd, 
                            _DeleteItChngd;
      #endregion

      #region PhoneRec Properties
        //Phone Number List {DataTable}
        public DataTable PhoneList {
            get { return _PhoneList; }
            set { _PhoneList = value; }
        }

        //PRecPtr
        public int PRecPtr {
            get { return _PRecPtr; }
            set { _PRecPtr = value; }
        }

        //PRecMax
        public int PRecMax {
            get { return _PRecMax; }
            set { _PRecMax = value; }
        }

        //PID
        public static int PID {
            get { return _PID; }
            set { _PID = value; }
        }

        //Phone Number
        public static bool PhoneChngd {
            get { return _PhoneChngd; }
            set { _PhoneChngd = value; }
        }
        public static string PhoneNum {
            get { return _PhoneNum; }
            set { _PhoneNum = value; }
        }

        //Main Number Flag
        public static bool MainNumChngd {
            get { return _MainNumChngd; }
            set { _MainNumChngd = value; }
        }
        public static bool MainNum {
            get { return _MainNum; }
            set { _MainNum = value; }
        }

        //Time Zone
        public static bool TZChngd {
            get { return _TZChngd; }
            set { _TZChngd = value; }
        }
        public static int? TZ {
            get { return _TZ; }
            set { _TZ = value; }
        }

        //Archive It Flag
        public static bool ArchiveItChngd {
            get { return _ArchiveItChngd; }
            set { _ArchiveItChngd = value; }
        }
        public static bool ArchiveIt {
            get { return _ArchiveIt; }
            set { _ArchiveIt = value; }
        }

        //Delete It Flag
        public static bool DeleteItChngd {
            get { return _DeleteItChngd; }
            set { _DeleteItChngd = value; }
        }
        public static bool DeleteIt {
            get { return _DeleteIt; }
            set { _DeleteIt = value; }
        }
      #endregion

      #region Class Error Handler
        //ToDo:
      #endregion
    }
}
