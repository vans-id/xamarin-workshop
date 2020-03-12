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

namespace AppPOS.FM_Report.ListViewRow
{
    class LvRow_ReportTransactionNR : ArrayAdapter
    {
        List<ListViewRow.LvRow_ReportTransaction> lstData;

        public LvRow_ReportTransactionNR(Context context, int NoteListRowId, List<LvRow_ReportTransaction> lstData) : base(context, NoteListRowId, lstData)
        {
            this.lstData = lstData;
        }

        public override int Count { get { return lstData.Count; } }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if(v==null)
            {
                LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
                v = inflater.Inflate(Resource.Layout.FM_ReportNR, parent, false);
            }
            v.FindViewById<TextView>(Resource.Id.TvNo).Text = lstData[position].id.ToString();
            v.FindViewById<TextView>(Resource.Id.TvNamaMenu).Text = lstData[position].namaMenu.ToString();
            v.FindViewById<TextView>(Resource.Id.TvHarga).Text = lstData[position].jmlItem.ToString() + " x " + lstData[position].hargaJual.ToString() + " = " + lstData[position].totalHarga.ToString();
            return v;
        }
    }
}