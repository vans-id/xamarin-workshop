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

namespace AppPOS.FM_Report.ClassReport
{
    class ClassDataparser : AsyncTask
    {
       private Context c;
        private ProgressDialog pd;
        private ListView lvTransaction;
        private TextView tvProvit;

        private List<Control.Class_Transaction> lstTtransaction;
        private List<ListViewRow.LvRow_ReportTransaction> lstRowData;
        private Model.DB_Report dbReport;

        private float provit, totalHargaBeli, totalHargaJual;
        public ClassDataparser(Context _c, ListView _lvTransaction, TextView _tvProvit)
        {
            this.c = _c;
            this.lvTransaction = _lvTransaction;
            this.tvProvit = _tvProvit;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd = new ProgressDialog(c);
            pd.SetTitle("Parse Data");
            pd.SetMessage("Load Data...Please Waitt");
            pd.Show();
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();
            if((bool)result)
            {
                fillDataListView();
                tvProvit.Text = "Total Provit : Rp." + provit;
            }
            else
            {
                Toast.MakeText(c, "Data Tidak Ditemukan", ToastLength.Short).Show();
            }
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            dbReport = new Model.DB_Report();
            dbReport.createDatabase();
            lstRowData = new List<ListViewRow.LvRow_ReportTransaction>();
            lstTtransaction = new List<Control.Class_Transaction>();
            return parseData();
        }

        private bool parseData()
        {
            try
            {
                lstTtransaction = dbReport.selectTable();
                if(lstTtransaction.Count>0)
                {
                    int i = 1;
                    foreach(Control.Class_Transaction a in lstTtransaction)
                    {
                        lstRowData.Add(new ListViewRow.LvRow_ReportTransaction(i, a.IDMenu,a.kategori,a.namaMenu,a.hargaBeli,a.hargaJual, a.jmlItem,a.totalHarga));
                        totalHargaBeli += a.hargaBeli;
                        totalHargaJual += a.hargaJual;
                        i++;
                    }
                }
                provit = totalHargaJual - totalHargaBeli;
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void fillDataListView()
        {
            lvTransaction.Adapter = new ListViewRow.LvRow_ReportTransactionNR(c, Resource.Layout.FM_ReportNR, lstRowData);
        }
    }
}