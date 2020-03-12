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

namespace AppPOS.FM_Outstanding.ClassOutstanding
{
    class ClassSaveOrder : AsyncTask
    {
        Context c;
        private ProgressDialog pd;

        private List<ListViewRow.LvRow_MenuOutstanding> listOrder;

        private Model.DB_Outstanding dbOutstanding;

        public ClassSaveOrder(Context c, List<ListViewRow.LvRow_MenuOutstanding> _lstOrder  )
        {
            this.c = c;
            this.listOrder = _lstOrder;
        }

   

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd = new ProgressDialog(c);
            pd.SetTitle("Save Data");
            pd.SetMessage("Save...Please Wait");
            pd.Show();
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();
           if((bool)true)
            {
                successTransaction();
                
            }
        }

        private void successTransaction()
        {
            AlertDialog dialog = new AlertDialog.Builder(c).Create();
            dialog.SetTitle("Success Transaction");
            dialog.SetMessage("Berhasil Menambahkan Data");
            dialog.Show();
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            dbOutstanding = new Model.DB_Outstanding();
  

            return saveData();
        }

        private bool saveData()
        {
           try
            {
                foreach (ListViewRow.LvRow_MenuOutstanding a in listOrder)
                {
                    Control.Class_Transaction dataTransaction = new Control.Class_Transaction
                    {
                        IDMenu = a.id.ToString(),
                        kategori = a.kategori,
                        namaMenu = a.namaMenu,
                        hargaBeli = a.hargaBeli,
                        hargaJual = a.hargaJual,
                        jmlItem = a.jmlItem,
                        totalHarga = a.hargaJual * a.jmlItem
                    };
                dbOutstanding.insertIntoTable(dataTransaction);
                }

                dbOutstanding.removeTable();
        
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}