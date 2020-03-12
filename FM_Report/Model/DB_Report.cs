using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace AppPOS.FM_Report.Model
{
    class DB_Report
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); 
        public bool createDatabase()
        {
          try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.CreateTable<Control.Class_Transaction>();
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Control.Class_Transaction> selectTable()
        {
            try
            {
                using(var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"POS.db")))
                {
                    return connection.Table<Control.Class_Transaction>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}