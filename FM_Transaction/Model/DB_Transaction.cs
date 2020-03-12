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
namespace AppPOS.FM_Transaction.Model
{
    class DB_Transaction
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
   
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.CreateTable<Control.Class_Outstanding>();
               
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool createDatabaseMasterMenu()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.CreateTable<Control.Class_MasterMenu>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public List<Control.Class_MasterMenu> selectTable()
        {
            try
            {
                using(var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"POS.db")))
                {
                    return connection.Table<Control.Class_MasterMenu>().ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool insertTable(Control.Class_Outstanding data)
        {
            try
            {
                using(var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"POS.db")))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    
    }
}