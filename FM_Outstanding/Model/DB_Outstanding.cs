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

namespace AppPOS.FM_Outstanding.Model
{
    class DB_Outstanding
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Control.Class_Outstanding> selectTable()
        {
            try
            {
                using(var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"POS.db")))
                {
                    return connection.Query<Control.Class_Outstanding>("SELECT * FROM Class_Outstanding ORDER BY idMenu ASC");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool insertIntoTable(Control.Class_Transaction data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool removeTable()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
            {
                connection.Query<Control.Class_Outstanding>("DELETE FROM Class_Outstanding");
                return true;
            }
        }
    }
}