using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WVCCTestApp {

    public class CallListDM {
        #region Declarations
        System.Data.DataTable myCallList = new System.Data.DataTable("myCallList");
        #endregion

        //Load recordset into data table
        public void load(SqlDataReader ListRecSet) {
            if (ListRecSet != null) {
                myCallList.Load(ListRecSet);            // Load record set into datatable
                ListRecSet.Dispose();                   // 
                myCallList.Columns.Add("Used", typeof(System.Boolean));     // Add data used column
                myCallList.Columns.Add("Delete", typeof(System.Boolean));   // Add delete flag column
                myCallList.Columns.Add("New", typeof(System.Boolean));      // Add new data flag colum
                foreach (DataRow rec in myCallList.Rows) {                  // Set initial value for new columns
                    rec["Used"] = 0;
                    rec["Delete"] = 0;
                    rec["New"] = 0;
                }
                myCallList.AcceptChanges();                                 // Commit changes to the datatable
            }
            else { // ToDo:ListRecSet is null - handle error
                Console.WriteLine("Error:ListRecSet is null");
            }
                    }

        //Return datatable
        public DataTable clist() {
            return myCallList;
        }

        //public void Add() {
        //
        //}

        public void RemoveRecByIndex(int tdIndex) {
            myCallList.Rows[tdIndex].Delete();
        }
        public void RemoveRecByID(string wvccid) {

        }

        public void Empty() {
            myCallList.Clear();
        }

        public void pushChanges() {
            // build SQL to push updates to the server
            // Fire off update
            // 
        }
    }
}
// Retrieving Changed Rows - http://msdn.microsoft.com/en-us/library/thc1eetk.aspx
// Adding rows to datatable - http://msdn.microsoft.com/en-us/library/5ycd1034.aspx
// Delete row(s) in a datatable - http://msdn.microsoft.com/en-us/library/feh3ed13.aspx
// Data layer guidelines - http://msdn.microsoft.com/en-us/library/ee658127.aspx


// 
