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

namespace AppPOS.FM_MasterMenu.ListViewRow
{
    class LvRow_MasterMenuNR : ArrayAdapter
    {
        List<LvRow_MasterMenu> lstData;
        public LvRow_MasterMenuNR(Context Context, int NoteListRowId, List<LvRow_MasterMenu> lstData) : base(Context, NoteListRowId, lstData)
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
                v = inflater.Inflate(Resource.Layout.FM_MasterMenuNR, parent, false);
            }
            v.FindViewById<TextView>(Resource.Id.TvJudul).Text = lstData[position].namaMenu.Substring(0, 2).ToUpper();
            v.FindViewById<TextView>(Resource.Id.TvNamaMenu).Text = lstData[position].namaMenu.ToString();
            v.FindViewById<TextView>(Resource.Id.TvHargaBeli).Text = "Harga Beli : Rp." + string.Format("{0:n}", double.Parse(lstData[position].hargaBeli.ToString()));
            v.FindViewById<TextView>(Resource.Id.TvhargaJual).Text = "Harga Jual : Rp." + string.Format("{0:n}", double.Parse(lstData[position].hargaJual.ToString()));
            return v;
        }
    }
}