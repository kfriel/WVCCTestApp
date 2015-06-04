using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;


namespace WVCCTestApp
{
    /// <summary>
    /// Interaction logic for OutboundSurvey.xaml
    /// </summary>
    /// 
    public partial class OutboundSurvey : Window
    {

        SQLServer MySession = new SQLServer();
        private static int _QOrder;

        private static string _SQuestion, _SAnswer, _SessionKey; // _XAML_Logic;
        DataTable _xamldt = new DataTable("xamldt");


        public OutboundSurvey()
        {
            InitializeComponent();

        }

        #region Declarations

        // Question Order
        public int QOrder
        {
            get { return _QOrder; }
            set { _QOrder = value; }
        }

        // Question
        public string SQuestion
        {
            get { return _SQuestion; }
            set { _SQuestion = value; }
        }

        // Question
        public string SAnswer
        {
            get { return _SAnswer; }
            set { _SAnswer = value; }
        }

        // XAML Code (Survey Screen)

        public DataTable xamldt
        {
            get { return _xamldt; }
            set { _xamldt = xamldt; }
        }

        public string SessionKey
        {
            get { return MySession.SessionKey; }
            set { _SessionKey = value; }
        }
       
        #endregion


        
        private void Close_Click(object sender, EventArgs e)
        {

            //DataTable _xamldt = new DataTable("xamldt");

            xaml_code.Text = Convert.ToString(xamldt.Rows[0]["XAML_Logic"]);  
         
                
                //Window win = new Window();
                //win.Content =  Convert.ToString(xamldt.Rows[1]["XAML_Logic"]);
                //this.Content = win;       


            //Turn me into string so string can be called without erroring out
            //const string activatewindowobjects = "Question4.Text = Convert.ToString(ql.Rows[3][\"SQuestion\"]; + char(10) + char(13)" + 
            //                                      Question5.Text = Convert.ToString(ql.Rows[4][\"SQuestion\"]);""

            //Q4A1rdo.Content = Convert.ToString(al.Rows[9]["SAnswer"]);
            //Q4A2rdo.Content = Convert.ToString(al.Rows[10]["SAnswer"]);
            //Q4A3rdo.Content = Convert.ToString(al.Rows[11]["SAnswer"]);
            //Q4A4rdo.Content = Convert.ToString(al.Rows[12]["SAnswer"]);
            //Q4A5rdo.Content = Convert.ToString(al.Rows[13]["SAnswer"]);
            //Q4A6rdo.Content = Convert.ToString(al.Rows[14]["SAnswer"]);
            //Q4A7rdo.Content = Convert.ToString(al.Rows[15]["SAnswer"]);
            //Q4A8rdo.Content = Convert.ToString(al.Rows[16]["SAnswer"]);
            //Q4A9rdo.Content = Convert.ToString(al.Rows[17]["SAnswer"]);
            //Q4A10rdo.Content = Convert.ToString(al.Rows[18]["SAnswer"]);
            //Q4A11rdo.Content = Convert.ToString(al.Rows[20]["SAnswer"]);
            //Q4A12rdo.Content = Convert.ToString(al.Rows[19]["SAnswer"]);
            //Q4A13rdo.Content = Convert.ToString(al.Rows[21]["SAnswer"]);
            //Q4A14rdo.Content = Convert.ToString(al.Rows[22]["SAnswer"]);
            //Q4A15rdo.Content = Convert.ToString(al.Rows[23]["SAnswer"]);
            //Q4A16rdo.Content = Convert.ToString(al.Rows[24]["SAnswer"]);
            //Q4A17rdo.Content = Convert.ToString(al.Rows[25]["SAnswer"]);
            //Q4A18rdo.Content = Convert.ToString(al.Rows[26]["SAnswer"]);
            //Q4A19rdo.Content = Convert.ToString(al.Rows[27]["SAnswer"]);
            //Q4A20rdo.Content = Convert.ToString(al.Rows[28]["SAnswer"]);
            //Q4A21rdo.Content = Convert.ToString(al.Rows[29]["SAnswer"]);
            //Q4A22rdo.Content = Convert.ToString(al.Rows[30]["SAnswer"]);
            //Q4A23rdo.Content = Convert.ToString(al.Rows[31]["SAnswer"]); 


             

            //Question4.Text = Convert.ToString(ql.Rows[3]["SQuestion"]);
            //Question5.Text = Convert.ToString(ql.Rows[4]["SQuestion"]);
            //Question6.Text = Convert.ToString(ql.Rows[5]["SQuestion"]);

            //this.Close();
         }


        #region functions

        // Method for creating Question retrieval

        public void GetQuestions(SQLServer MySession)
        {
            string tempsql = "EXEC dbo.GetQuestions '[id]', '[SessionKey]', 'O';";
            tempsql = tempsql.Replace("[id]", Environment.UserName);
            tempsql = MySession.secureQuery(tempsql);
            SqlCommand QCmd = new SqlCommand(tempsql, MySession.wvccConnection);
            DataTable ql = new DataTable("SurveyQuestions");
            ql.Clear();

            using (SqlDataAdapter da = new SqlDataAdapter(QCmd))
            {
                // Load SurveyQuestions dataTable 
                da.Fill(ql);

                //Question1.Text = Convert.ToString(ql.Rows[0]["SQuestion"]);
                //Question2.Text = Convert.ToString(ql.Rows[1]["SQuestion"]);
                //Question3.Text = Convert.ToString(ql.Rows[2]["SQuestion"]);

          
            }

            //Question7.Text = Convert.ToString(ql.Rows[6]["SQuestion"]);
            //Question8.Text = Convert.ToString(ql.Rows[7]["SQuestion"]);
            //Question9.Text = Convert.ToString(ql.Rows[8]["SQuestion"]);
            //Question10.Text = Convert.ToString(ql.Rows[9]["SQuestion"]);
        }

        // da.Dispose();



        public void GetAnswers(SQLServer MySession)
        {
            string tempsql = "EXEC dbo.GetAnswers '[id]', '[SessionKey]', 'O';";
            tempsql = tempsql.Replace("[id]", Environment.UserName);
            tempsql = MySession.secureQuery(tempsql);
            SqlCommand ACmd = new SqlCommand(tempsql, MySession.wvccConnection);
            DataTable al = new DataTable("SurveyAnswers");
            al.Clear();

            using (SqlDataAdapter da_answer = new SqlDataAdapter(ACmd))
            {
                
                DataTable xamldt = new DataTable();
                da_answer.Fill(al);


                Q1A1rdo.Content = Convert.ToString(al.Rows[0]["SAnswer"]);
                Q2A1rdo.Content = Convert.ToString(al.Rows[1]["SAnswer"]);
                Q2A2rdo.Content = Convert.ToString(al.Rows[2]["SAnswer"]);
                Q2A3rdo.Content = Convert.ToString(al.Rows[3]["SAnswer"]);   // TO DO: Word Wrap Text of long answer  
                Q2A4rdo.Content = Convert.ToString(al.Rows[4]["SAnswer"]);
                Q2A5rdo.Content = Convert.ToString(al.Rows[5]["SAnswer"]);
                Q2A6rdo.Content = Convert.ToString(al.Rows[6]["SAnswer"]);
                Q3A1rdo.Content = Convert.ToString(al.Rows[7]["SAnswer"]);
                Q3A2rdo.Content = Convert.ToString(al.Rows[8]["SAnswer"]);

                

                if (Convert.ToString(al.Rows[0]["SAnswer"]) == "")  //Make Dynamic across all radio buttons
                {
                    Q1A1rdo.Visibility = Visibility.Collapsed;
                }
            }

            // da.Dispose();

        }

        // get xaml code for Survey Questions and Answers

        public void GetXAMLCode(SQLServer MySession)
        {
            string tempsql = "EXEC dbo.GetXAML '[id]', '[SessionKey]', 'O';";
            tempsql = tempsql.Replace("[id]", Environment.UserName);
            tempsql = MySession.secureQuery(tempsql);
            SqlCommand XAMLCmd = new SqlCommand(tempsql, MySession.wvccConnection);
            //DataTable xamldt = new DataTable("XAMLSurvey");
            xamldt.Clear();

            using (SqlDataAdapter daxaml = new SqlDataAdapter(XAMLCmd))
            {
                daxaml.Fill(xamldt);
       
            }

             
        }

        
        #endregion
    }
}



    

