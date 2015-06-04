using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WVCCTestApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
      #region Declarations
        private string _UserStatusMsg, _ProcessNotificationMsg;
        private static double _SliderMax, _SliderValue;
        private int _ProgressPrctg, _CallListIndex;
        public bool Online = false;
        public SQLServer _MySession;
        DataTable CallListVM = new DataTable();
        DataTable SearchList = new DataTable();
        ContactInfoMgr MyContactInfoMgr = new ContactInfoMgr(); //Contact information manager class
        CallListManager MyCallListMgr = new CallListManager();  // Call list class and data model
        SubjectInfo MySubjectInfo = new SubjectInfo();          // Subject information class and data model
        
      #endregion

        public bool runapp = true;
        public MainWindow() {
            InitializeComponent();
            this.ClearGUI();
        }
        
      #region Dependency Properties
        //
        public double Maximum 
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Session information
        public SQLServer MySession 
        {
            get { return _MySession; }
            set { _MySession = value; }
        }

        public string UserStatusMsg {
            get { return _UserStatusMsg; }
            set { _UserStatusMsg = value; }
        }
        public string ProcessNotificationMsg {
            get { return _ProcessNotificationMsg; }
            set { _ProcessNotificationMsg = value; }
        }
        public int ProgressPrctg {
            get { return _ProgressPrctg; }
            set { _ProgressPrctg = value; }
        }

        public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register("Minimum", typeof(double),
        typeof(Slider), new UIPropertyMetadata(0d));

        // info Resources
        //http://www.wpftutorial.net/dependencyproperties.html
        //http://www.codeproject.com/Articles/140620/WPF-Tutorial-Dependency-Property
        //http://drwpf.com/blog/2010/05/05/value-coercion-for-the-masses/
        //http://www.thejoyofcode.com/Creating_a_Range_Slider_in_WPF_and_other_cool_tips_and_tricks_for_UserControls_.aspx

      #endregion

      #region GUI Display Functions
        //http://www.codeproject.com/Articles/26210/Moving-Toward-WPF-Data-Binding-One-Step-at-a-Time
        public void ClearGUI() 
        {
            base.DataContext=new GUIChanged {
                WVCCID = null,
                FName = null,
                LName = null,
                MadenName = null,
                MName = null,
                SSN = null,
                LastCalled = null,
                SubStatus = null,
                CallStatus = null,
                LastDispo = null,
                Address1 = null,
                City = null,
                State = null,
                ZIP = null,
                PhoneNum = null,
                TZone = 0,
                CallNoteHistory = null,
                AutoSummary = null,
                CallerNote = null
            };
        }

        // Update Call list on GUI
        public void FillCList() {
            MyCallListMgr.GetCList();        //Get Call list
            CallList(MyCallListMgr.CallList);  //Move data to gui
        }

        // Subject Information
        public void UpdateGUI() {
            base.DataContext = new GUIChanged {
                //Subject Identity
                WVCCID = SubjectInfo.WVCCID,
                FName = SubjectInfo.FName,
                LName = SubjectInfo.LName,
                MadenName = SubjectInfo.MdnName,
                MName = SubjectInfo.MName,
                SSN = SubjectInfo.SSN,
                //Call History
                LastCalled = SubjectInfo.LastCalled,
                SubStatus = SubjectInfo.ContactStatus,
                //Contact Information
                CallStatus = "Test",
                LastDispo = "Test",
                Address1 = ContactRec.Address1,
                //Todo Add to GUI:Address2 = WVCCTestApp.ContactRec.Address2,
                City = ContactRec.City,
                State = ContactRec.State,
                ZIP = ContactRec.Zip,
                //Phone Information
                PhoneNum = PhoneRec.PhoneNum,
                TZone = PhoneRec.TZ,
                //Call Notes
                CallNoteHistory = "Test",
                AutoSummary = "Test",
                CallerNote = "Test",
                //GUI Feedback information
                SliderValue = LocSliderValue,
                UserStatus = UserStatusMsg,
                ProcessNotification = ProcessNotificationMsg,
                Progress = ProgressPrctg,
                //Search components
                Searchitem = null
            };
        }
      #endregion

      #region Enable/Disable functions
        public void TakeCallTgl(string cmd) {
            switch (cmd) {
                case "On":
                    TakeCallbtn.IsEnabled = true;
                    break;
                case "Off":
                    TakeCallbtn.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }
        public void MakeCallTgl(string cmd) {
            switch (cmd) {
                case "On":
                    MakeCallbtn.IsEnabled = true;
                    break;
                case "Off":
                    MakeCallbtn.IsEnabled=false;
                    break;
                default:
                    break;
            }
        }
        public void SearchEnable(string cmd) {
            switch (cmd) {
                case "On":
                    searchItem.Visibility = Visibility.Visible;
                    Searchbtn.Visibility = Visibility.Visible;
                    Searchlbl.Visibility = Visibility.Visible;
                    break;
                case "Off":
                    searchItem.Visibility = Visibility.Hidden;
                    Searchbtn.Visibility = Visibility.Hidden;
                    Searchlbl.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }
        public void UseThisNum(string cmd,string facemsg = "") {
            switch (cmd) {
                case "On":
                    useThisNumbtn.Visibility = Visibility.Visible;
                    useThisNumbtn.Content = facemsg;
                    break;
                case "Off":
                    useThisNumbtn.Visibility = Visibility.Hidden;
                    useThisNumbtn.Content = facemsg;
                    break;
                default:
                    break;
            }
        }
        //Search Criteria textbox
      #endregion

      #region Alert functions
        private void NotifyMsgTGL(string cmd,
                                  string msg = "",
                                  string colorscheme = "standard") {
            switch (cmd) {
                case "On":
                    switch (colorscheme) {
                        case "Standard":
                            NotifyMessagelb.Foreground = Brushes.Black;
                            NotifyMessagelb.Background = Brushes.Transparent;
                            break;
                        case "Red Alert":
                            NotifyMessagelb.Foreground = Brushes.Red;
                            NotifyMessagelb.Background = Brushes.Black;
                            break;
                        default:
                            break;
                    }
                    NotifyMessagelb.Content = msg;
                    NotifyMessagelb.Visibility = Visibility.Visible;
                    break;
                case "Off":
                    NotifyMessagelb.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void BlockAlertTgl(string cmd, 
            string msg = "", 
            string colorscheme = "standard") {
                switch (cmd) {     
                    case "On":
                        switch (colorscheme) {
                            case "standard":
                                BlockingAlert.Foreground = Brushes.Black;
                                BlockingAlertBG.Fill = Brushes.DarkKhaki;
                                break;
                            case "Red":
                                BlockingAlert.Foreground = Brushes.Red;
                                BlockingAlertBG.Fill = Brushes.Black;
                                break;
                            case "Yellow":
                                BlockingAlert.Foreground = Brushes.Red;
                                BlockingAlertBG.Fill = Brushes.Black;
                                break;
                            default:
                                break;
                        }
                        BlockingAlert.Content = msg;
                        BlockingAlertBG.Visibility = Visibility.Visible;
                        BlockingAlert.Visibility = Visibility.Visible;
                        break;
                    case "Off":
                        BlockingAlert.Visibility = Visibility.Hidden;
                        BlockingAlertBG.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }
        }
      #endregion

      #region TakeCall
        public void SearchDB(object sender, RoutedEventArgs e) {
            SqlDataReader SearchListRec;
            //ToDo: Get search value from textbox
            string tempSQL = "EXEC dbo.SearchDB '[id]', '[SessionKey]';";
            SearchListRec = MySession.queryDB(tempSQL);
            load(SearchListRec);
            //ToDo: Trigger Listbox fill
        }
        private void load(SqlDataReader SearchListRec) {
            if (SearchListRec != null) {
                SearchList.Load(SearchListRec);     //LoadCompletedEventHandler search results to DataTable
                SearchListRec.Dispose();
                SearchList.AcceptChanges();
            }
            else { // ToDo:ListRecSet is null - handle error
                Console.WriteLine("Error:ListRecSet is null");
            }
        }
      #endregion

      #region MakeCall
        //Phone Number textbox
        //TZ textbox
        //Main Number checkbox
      #endregion

      #region controls
        // Mode Combobox
        private void Mode_menu_pl(object sender, RoutedEventArgs e) 
        {
            List<string> data = new List<string>();     //Build dropdown list
                data.Add("Off Line");
                data.Add("Agent On Line");
                data.Add("Agent On Break");
                data.Add("Agent In Meeting");
                data.Add("Agent In Training");
                data.Add("Training Mode On");
                data.Add("Training Mode Off");
                data.Add("Idle");

            var comboBox = sender as ComboBox;          //Get reference
            comboBox.ItemsSource = data;                //Assign list items
            if (Online) 
            {
                comboBox.SelectedIndex = 1;             //Set initial selection
            }
            else 
            {
                comboBox.SelectedIndex = 0;                 
            }
            
        }
        private void Mode_SelectionChanged(object sender, RoutedEventArgs e) 
        {
            var comboBox = sender as ComboBox;
            switch (comboBox.SelectedItem as string) {
                case "Off Line":
                    BlockAlertTgl("On", "Off Line");
                    //ToDo: Send note to activity log
                    break;
                case "Agent On Line":
                    BlockAlertTgl("Off");
                    //ToDo: Send note to activity log
                    break;
                case "Agent On Break":
                    BlockAlertTgl("On", "Agent On Break");
                    //ToDo: Send note to activity log
                    break;
                case "Agent In Meeting":
                    BlockAlertTgl("On", "Agent In Meeting");
                    //ToDo: Send note to activity log
                    break;
                case "Agent In Training":
                    BlockAlertTgl("On", "Agent In Training");
                    //ToDo: Send note to activity log
                    break;
                case "Training Mode On":
                    NotifyMsgTGL("On", "Training Mode", "Red Alert");
                    //ToDo: Send note to activity log
                    break;
                case "Training Mode Off" :
                    NotifyMsgTGL("Off");
                    //ToDo: Send note to activity log
                    break;
                case "Idle":
                    BlockAlertTgl("On", "Idle", "Yellow");
                    //ToDo: Send note to activity log
                    break;
                default:
                    break;
            }
        }

        // Assignment combobox
        private void Assignment_menu_pl(object sender, RoutedEventArgs e) {
            List<string> data = new List<string>();     //Build dropdown list
            data.Add("Out Bound");
            data.Add("In Bound");

            var comboBox = sender as ComboBox;          //Get reference
            comboBox.ItemsSource = data;                //Assign list items
            comboBox.SelectedIndex = 0;                 //Set initial selection
        }
        private void Assignment_SelectionChanged(object sender, RoutedEventArgs e) {
            EventManager("Assignment", Mode.Text);
        }

        // ListBox
        public void CallList(DataTable CallListView ) 
        {
            if (CallListView.Rows.Count > 0) 
            {
                ListView.ItemsSource = ((IListSource)CallListView).GetList();
            }
            //http://stackoverflow.com/questions/961877/binding-a-wpf-listview-to-a-dataset-possible
            //http://holstcoding.blogspot.com/2010/08/wpf-binding-listview-to-datatable.html
        }

        // List Selection Changed
        public void CallListSlChnd(Object sender, SelectionChangedEventArgs args) {
            //Test to see if selection was made
            if (ListView.SelectedIndex > -1) {
                DataRowView drv = (DataRowView)ListView.SelectedItem;
                String WVCCID = drv["WVCCID"].ToString();              //Pull Selected Value
                MyContactInfoMgr.GetContactInfo(MySession, WVCCID);    //Pass selection for retrevial
                UserStatusMsg = "Veteran Selected";
                TakeCallTgl("Off");
                UpdateGUI();
            }
        }
        
        // List Reset button
        private void ListReset(Object sender, RoutedEventArgs e) {
            TakeCallTgl("On");
            MakeCallTgl("On");
            SearchEnable("Off");
            ClearGUI();
            ListView.SelectedIndex = -1;
            //Todo: Filter used and deleted
        }

        // List New Button
        private void ListNew(object sender, RoutedEventArgs e) {
            MakeCallTgl("On");
            TakeCallTgl("On");
            FillCList();
        }

        // Edit Subject Info button
        private void EditSubjectInfo(object sender, RoutedEventArgs e) {
            EventManager("EditSubjevtinfo", "True");
        }

        // Add Address button
        private void AddAddress(object sender, RoutedEventArgs e) {
            EventManager("AddAddress", "True");
        }

        // Take Call button
        private void TakeCall(object sender, RoutedEventArgs e) {
            Assignmentcbx.SelectedItem = 1;     // Set InBound
            SearchEnable("On");
            MakeCallTgl("Off");
            TakeCallTgl("Off");
            //ToDo: Post start time
            //ToDo: Fire Inbound 
        }

        // Make Call button
        private void MakeCall(object sender, RoutedEventArgs e) {
            Assignmentcbx.SelectedItem = 0;     // Set OutBound
            //ToDo: Post Start time
            //ToDo: Fire OutBound
        }

        // Search for subject button
        private void SearchFor(object sender, RoutedEventArgs e) {
            //Todo: Check to see if search item box is null
            if (searchItem.Text != "") {
                EventManager("SearchFor", searchItem.Text);
            }
        }

        // Slider control
        private void SliderPosition(object sender, RoutedPropertyChangedEventArgs<double> e) {
            var slider = sender as Slider;  // Get slider reference
            double svalue = slider.Value;    // Get Value
            svalue = Math.Round(svalue);
            AdrsSlider.Value = svalue;
            LocSliderValue = (int)svalue;
            UpdateGUI();
            EventManager("Slider", svalue.ToString());
        }
        private double SliderMax 
        {
            get { return _SliderMax; }
            set { _SliderMax = value; 
            
            }
        }
        private double LocSliderValue 
        {
            get { return _SliderValue; }
            set { _SliderValue = value; }
        }

        private void SliderTicks() {

        }
        //http://www.wpftutorial.net/dependencyproperties.html#introduction

        // Quit button
        private void QuitBtnClk(object sender, RoutedEventArgs e)
        {
            EventManager("Quit", "True");    //Send the quit event
        }

     #endregion

     #region event communicator
        public void EventManager(string eventCtrl, string eventData) {
            //Send event date to Event manager in origional thread
            switch (eventCtrl.ToLower()) {
                case "quit":
                    MySubjectInfo = null;
                    MyCallListMgr.Dispose(); 
                    this.Close();                   //Close window
                    break;
                case "slider": 
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "searchfor":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "takecall":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "makecall":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "addaddress":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "editsubjevtinfo":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "resetnew":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "resetlist":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "calllistselect":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    //base.DataContext = new Person { WVCCID = eventData }; //Test: 
                    break;
                case "assignment":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                case "mode":
                    MessageBox.Show("Control: " + eventCtrl + " | Data: " + eventData);
                    break;
                default:
                    break;

            }

        }
     #endregion

    }
}
