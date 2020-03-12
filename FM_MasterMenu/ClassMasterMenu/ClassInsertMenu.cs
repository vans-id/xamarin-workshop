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

namespace AppPOS.FM_MasterMenu.ClassMasterMenu
{
    class ClassInsertMenu : AsyncTask
    {
        private Activity c;
        private EditText edtKategori, edtNamaMenu, edtHargaBeli, edtHargaJual;
        private Button btnSimpan;

        private ProgressDialog pd;
        private Model.DB_MasterMenu db;

        public ClassInsertMenu(Activity _c,EditText _edtKategori, EditText _edtNamaMenu, EditText _edtHargaBeli, EditText _edtHargaJual, Button _btnSimpan)
        {
            this.c = _c;
            this.edtKategori = _edtKategori;
            this.edtNamaMenu = _edtNamaMenu;
            this.edtHargaBeli = _edtHargaBeli;
            this.edtHargaJual = _edtHargaJual;
            this.btnSimpan = _btnSimpan;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd = new ProgressDialog(c);
            pd.SetTitle("Insert Data");
            pd.SetMessage("Insert Data...Please Waitt");
            pd.Show();
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            db = new Model.DB_MasterMenu();
            db.createDatabase();

            return parseData();
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();
            if((bool)result)
            {
                Toast.MakeText(c, "Berhasil Simpan Data", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(c, "Gagal Menyimpan Data", ToastLength.Short).Show();
            }
        }

        private bool parseData()
        {
            try
            {
                Control.Class_MasterMenu data = new Control.Class_MasterMenu()
                {
                    kategori = edtKategori.Text.ToString(),
                    namaMenu = edtNamaMenu.Text.ToString(),
                    hargaBeli = float.Parse( edtHargaBeli.Text.ToString()),
                    hargaJual = float.Parse(edtHargaJual.Text.ToString())
                };
                db.insertIntoTable(data);
                return true;
            }
            catch(System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}