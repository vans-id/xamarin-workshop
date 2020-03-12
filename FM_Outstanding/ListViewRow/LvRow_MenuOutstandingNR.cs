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

namespace AppPOS.FM_Outstanding.ListViewRow
{
    class LvRow_MenuOutstandingNR : ArrayAdapter
    {
        List<LvRow_MenuOutstanding> lstData;
        public LvRow_MenuOutstandingNR(Context Context, int NoteListRowId, List<LvRow_MenuOutstanding> lstData) : base(Context, NoteListRowId, lstData)
        {
            this.lstData = lstData;
        }
        public override int Count { get { return lstData.Count; } }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if (v == null)
            {
                LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
                v = inflater.Inflate(Resource.Layout.FM_OutstandingNR, parent, false);
            }
            v.FindViewById<TextView>(Resource.Id.TvJudul).Text = lstData[position].namaMenu.Substring(0, 2).ToUpper();
            v.FindViewById<TextView>(Resource.Id.TvNamaMenu).Text = lstData[position].namaMenu.ToString();
            v.FindViewById<TextView>(Resource.Id.TvJmlItem).Text = lstData[position].jmlItem + " x " + lstData[position].hargaJual + " = " + lstData[position].totalHarga;
          
            return v;
        }
    }
}