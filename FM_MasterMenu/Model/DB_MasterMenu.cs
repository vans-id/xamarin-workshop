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

namespace AppPOS.FM_MasterMenu.Model
{
    class DB_MasterMenu
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db"))) 
                {
                    connection.CreateTable<Control.Class_MasterMenu>();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool insertIntoTable(Control.Class_MasterMenu data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Control.Class_MasterMenu> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    return connection.Table<Control.Class_MasterMenu>().ToList();
                    
                }
            }
            catch(SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateTable(Control.Class_MasterMenu data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.Query<Control.Class_MasterMenu>("UPDATE Class_MasterMenu set kategori=?, namaMenu=?,hargaBeli=?,hargaJual=? Where ID=?", data.kategori,data.namaMenu,data.hargaBeli,data.hargaJual,data.ID);
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool deleteTable(Control.Class_MasterMenu data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "POS.db")))
                {
                    connection.Query<Control.Class_MasterMenu>("DELETE FROM Class_MasterMenu Where ID=?",data.ID);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}