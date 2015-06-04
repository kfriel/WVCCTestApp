using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WVCCTestApp {
    //Implementing an interface to handle data binding for the GUI
    public class GUIChanged : INotifyPropertyChanged {
        
        private string _WVCCID, _FName, _LName, _MadenName, _MName, _SSN;
        private string _SubStatus, _CallStatus, _LastDispo,  _Address1;
        private string _Address2, _City, _State, _ZIP, _PhoneNum,  _AutoSummary;
        private string _CallerNote, _CallNoteHistory, _NotifyMessage;
        private string  _UserStatus, _ProcessNotification, _Searchitem;
        private int _Progress;
        private double _SliderMax, _SliderValue;
        private DateTime? _LastCalled;
        private int? _TZone;

      #region Subject Identity
        public string WVCCID {
            get { return _WVCCID; }
            set { _WVCCID = value;
                  this.OnPropertyChanged("WVCCID");
            }
        }
        public string FName {
            get { return _FName; }
            set { _FName = value;
                  this.OnPropertyChanged("FName");
            }
        }
        public string LName {
            get { return _LName; }
            set { _LName = value;
                  this.OnPropertyChanged("LName");
            }
        }
        public string MadenName {
            get { return _MadenName; }
            set { _MadenName = value;
                  this.OnPropertyChanged("MadenName");
            }
        }
        public string MName {
            get { return _MName; }
            set { _MName = value;
                  this.OnPropertyChanged("MName");
            }
        }
        public string SSN {
            get { return _SSN; }
            set { _SSN = value;
                  this.OnPropertyChanged("SSN");
            }
        }
      #endregion

      #region Call History
        public DateTime? LastCalled {
            get { return _LastCalled; }
            set { _LastCalled = value;
                  this.OnPropertyChanged("LastCalled");
            }
        }
        public string SubStatus {
            get { return _SubStatus; }
            set { _SubStatus = value;
                  this.OnPropertyChanged("SubStatus");
            }
        }
        public string CallStatus {
            get { return _CallStatus; }
            set { _CallStatus = value;
                  this.OnPropertyChanged("CallStatus");
            }
        }
        public string LastDispo {
            get { return _LastDispo; }
            set { _LastDispo = value;
                  this.OnPropertyChanged("LastDispo");
            }
        }
      #endregion

      #region Contact information
        public string Address1 {
            get { return _Address1; }
            set { _Address1 = value;
                  this.OnPropertyChanged("Address1bx");
            }
        }
        public string Address2 {
            get { return _Address2; }
            set { _Address2 = value;
                  //this.OnPropertyChanged("Address2");
            }
        }
        public string City {
            get { return _City; }
            set { _City = value;
                  this.OnPropertyChanged("City");
            }
        }
        public string State {
            get { return _State; }
            set { _State = value;
                  this.OnPropertyChanged("State");
            }
        }
        public string ZIP {
            get { return _ZIP; }
            set { _ZIP = value;
                  this.OnPropertyChanged("ZIP");
            }
        }
        public string PhoneNum {
            get { return _PhoneNum; }
            set { _PhoneNum = value;
                  this.OnPropertyChanged("PhoneNum");
            }
        }
        public int? TZone {
            get { return _TZone; }
            set { _TZone = value;
                  this.OnPropertyChanged("TZone");
            }
        }
      #endregion

      #region GUI Specific Values
        public double SliderValue {
            get { return _SliderValue; }
            set { _SliderValue = value;
                  this.OnPropertyChanged("SliderValue");
            }
        }
        public double SliderMax {
            get { return _SliderMax; }
            set { _SliderMax = value;
                  this.OnPropertyChanged("SliderMax");
            }
        }
      #endregion

      #region Call Notes
        public string CallNoteHistory {
            get { return _CallNoteHistory; }
            set { _CallNoteHistory = value;
                  this.OnPropertyChanged("CallNoteHistory");
            }
        }
        public string AutoSummary {
            get { return _AutoSummary; }
            set { _AutoSummary = value;
                  this.OnPropertyChanged("AutoSummary");
            }
        }
        public string CallerNote {
            get { return _CallerNote; }
            set { _CallerNote = value;
                  this.OnPropertyChanged("CallerNote");
            }
        }
      #endregion

     #region Nofifications and Status Bar
        public string NotifyMessage {
            get { return _NotifyMessage; }
            set {
                _NotifyMessage = value;
                this.OnPropertyChanged("NotifyMessage");
            }
        }
        public string UserStatus {
            get { return _UserStatus; }
            set {
                _UserStatus = value;
                this.OnPropertyChanged("UserStatus");
            }
        }
        public string ProcessNotification {
            get { return _ProcessNotification; }
            set {
                _ProcessNotification = value;
                this.OnPropertyChanged("ProcessNotification");
            }
        }
        public int Progress {
            get { return _Progress; }
            set {
                _Progress = value;
                this.OnPropertyChanged("Progress");
            }
        }
     #endregion

     #region Search
        public string Searchitem {
            get { return _Searchitem; }
            set {
                _Searchitem = value;
                this.OnPropertyChanged("Searchitem");
            }
        }
     #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(
                    this, new PropertyChangedEventArgs(propName));
        }
    }
}
