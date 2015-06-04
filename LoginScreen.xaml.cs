using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel; //Added for CancelArg event
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WVCCTestApp
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private int baseline, followup, unused;   // use integers to check for buckets with no veterans in them
        public static int _shifty, _assign;       // pass integer values back to User Info


        public LoginWindow()

        {
            InitializeComponent();

            BI _bi = new BI();

            // Bind Values from BI Class to Text Boxes in Login Window

            NewCountbx.Text = _bi.unused.ToString();
            BaselineCountbx.Text = _bi.baseline.ToString();
            FollowCountbx.Text = _bi.followup.ToString();

            // Convert Count value to integer to run comparison when caller chooses assignment

            unused = Convert.ToInt32(_bi.unused);
            baseline = Convert.ToInt32(_bi.baseline);
            followup = Convert.ToInt32(_bi.followup);

        }


        #region Declarations


        // Intialize Variables to hold counts for login screen

        #endregion

        // User Shift
        public int shifty
        
        {
            get { return _shifty; }
            set { _shifty = value; }
        }

        // User Assignment
        public int assign
       
        {
            get { return _assign; }
            set { _assign = value; }
        }

        #region functions


        // Cannot close window with cancel button

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);
        //    e.Cancel = true;
        //    //break;
        //}

        // Actions when Enter button on Login Window form is pressed

        private void Loginbtn_Click(object sender, EventArgs e)
        {

            int zerovalue = 0;

         

                // Check to see if at least ONE of the shift buttons and at least ONE of the assignment buttons is chosen

                if (((Shift1rdo.IsChecked == true) || (Shift2rdo.IsChecked == true) || (Shift3rdo.IsChecked == true) ||
                    (Shift4rdo.IsChecked == true))
                    && ((NewVetrdo.IsChecked == true) || (BaselineVetrdo.IsChecked == true) ||
                    (FollowVetrdo.IsChecked == true) || (InboundVetrdo.IsChecked == true)))
                {
                   
                    // Check whether assignment bucket chosen has enough veterans to call
                    
                    if (((unused > zerovalue && (NewVetrdo.IsChecked == true)) ||
                        (baseline > zerovalue && (BaselineVetrdo.IsChecked == true)) ||
                        (followup > zerovalue && (FollowVetrdo.IsChecked == true)) ||
                        (InboundVetrdo.IsChecked == true))) // fix this,,,,when caller enters inbound then no message box
                    {

                    // Assign numeric value to shift and assignment to store in static variables (stored in userinfoclass.cs)

                    if (Shift1rdo.IsChecked == true)
                    { _shifty = 1; }

                    if (Shift2rdo.IsChecked == true)
                    { _shifty = 2; }

                    if (Shift3rdo.IsChecked == true)
                    { _shifty = 3; }

                    if (Shift4rdo.IsChecked == true)
                    { _shifty = 4; }

                    if (NewVetrdo.IsChecked == true)
                    { _assign = 1; }

                    if (BaselineVetrdo.IsChecked == true)
                    { _assign = 2; }

                    if (FollowVetrdo.IsChecked == true)
                    { _assign = 3; }

                    if (InboundVetrdo.IsChecked == true)
                    { _assign = 4; }

                    // Close Login Window Form after it has successfully met all criteria.
                    // The Main Program (Call Control Screen) will now open.

                             this.Close();     
                    }         
                    
                    else
                    
                    {
                        // Dialog Box Variables for choosing an assignment with no veterans to call

                        string message = "You must choose an assignment that has veterans to call.";
                        string caption = "INCORRECT ASSIGNMENT";
                        MessageBoxButton buttons = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult shift = System.Windows.MessageBox.Show(message, caption, buttons, icon);
                        //break;
                    } }

               
                else
                {
                    // Create loop to pop up error window until user enters at least one value for shift or assignment

                    do
                    {
                        if (((Shift1rdo.IsChecked == false) && (Shift2rdo.IsChecked == false) && (Shift3rdo.IsChecked == false) &&
                        (Shift4rdo.IsChecked == false)) || ((NewVetrdo.IsChecked == false) && (BaselineVetrdo.IsChecked == false) &&
                        (FollowVetrdo.IsChecked == false) && (InboundVetrdo.IsChecked == false)))
                        {
                            // Dialog Box Variables for Shift and Assignment

                            string message = "You must enter a value for both SHIFT and ASSIGNMENT.";
                            string caption = "INCORRECT ENTRY";
                            MessageBoxButton buttons = MessageBoxButton.OK;
                            MessageBoxImage icon = MessageBoxImage.Warning;
                            MessageBoxResult shift = System.Windows.MessageBox.Show(message, caption, buttons, icon);
                            break;

                        }
                    } while (((Shift1rdo.IsChecked == false) && (Shift2rdo.IsChecked == false) && (Shift3rdo.IsChecked == false) &&
                     (Shift4rdo.IsChecked == false)) || ((NewVetrdo.IsChecked == false) && (BaselineVetrdo.IsChecked == false) &&
                     (FollowVetrdo.IsChecked == false) && (InboundVetrdo.IsChecked == false)));


                }

            }





        #endregion;


        }
    }

























