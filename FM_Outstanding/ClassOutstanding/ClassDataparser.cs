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
using AppPOS.FM_Outstanding.Model;

namespace AppPOS.FM_Outstanding.ClassOutstanding
{
    class ClassDataparser : AsyncTask

    {
        private Context c;
        private ProgressDialog pd;
        private ListView lvMenuOutstanding;
        private TextView tvTotalHarga;
        private Button btnOrder;

        private List<ListViewRow.LvRow_MenuOutstanding> lvRowMenuOrder;
        private List<Control.Class_Outstanding> lstOutstanding;

        private DB_Outstanding dbOutstanding;

        private int _id;
        private string _kategori, _namaMenu;
        private float _hargaBeli, _hargaJual, totalHarga = 0;
        private int jmlItem;

        public ClassDataparser(Context c, ListView _lvMenuOutstanding,TextView _tvTotalHarga, Button _btnOrder)
        {
            this.c = c;
            this.lvMenuOutstanding = _lvMenuOutstanding;
  
            this.tvTotalHarga = _tvTotalHarga;
            this.btnOrder = _btnOrder;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd = new ProgressDialog(c);
            pd.SetTitle("Load Data");
            pd.SetMessage("Load Data...Please Wait");
            pd.Show();

        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();
            if((bool)result)
            {
                FillDataListViewToolbox();
                btnOrder.Click += BtnOrder_Click;
                tvTotalHarga.Text = "Total Harga : Rp." + totalHarga.ToString();
            }

        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            new ClassSaveOrder(c, lvRowMenuOrder).Execute();
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            dbOutstanding = new DB_Outstanding();
            dbOutstanding.createDatabase();
 
            return parseData();
        }



        private bool parseData()
        {
            try
            {
                lvRowMenuOrder = new List<ListViewRow.LvRow_MenuOutstanding>();
                lstOutstanding = new List<Control.Class_Outstanding>();
                lstOutstanding = dbOutstanding.selectTable();
                foreach(Control.Class_Outstanding a in lstOutstanding)
                {
                    totalHarga += a.hargaJual;
                    if (_id == int.Parse(a.idMenu))
                    {

                    }
                    else
                    {
                        _id = int.Parse(a.idMenu);
                        _kategori = a.kategori;
                        _namaMenu = a.namaMenu;
                        _hargaBeli = a.hargaBeli;
                        _hargaJual = a.hargaJual;
                        jmlItem = 0;

                        foreach (Control.Class_Outstanding b in lstOutstanding)
                        {
                            if (_id == int.Parse(b.idMenu))
                            {
                                jmlItem++;
                            }
                        }
                        lvRowMenuOrder.Add(new ListViewRow.LvRow_MenuOutstanding(_id, _kategori, _namaMenu, _hargaBeli, _hargaJual, jmlItem, jmlItem * _hargaJual));
                    }
                }
                return true; 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FillDataListViewToolbox()
        {
            lvMenuOutstanding.Adapter = new ListViewRow.LvRow_MenuOutstandingNR(c, Resource.Layout.FM_OutstandingNR, lvRowMenuOrder);
        }

    }
}