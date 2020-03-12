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

namespace AppPOS.FM_Transaction.ListViewRow
{
    class LvRow_MasterMenuNR : ArrayAdapter
    {
        List<LvRow_MasterMenu> lstData;

        public LvRow_MasterMenuNR(Context context, int NoteListRowId, List<LvRow_MasterMenu> lstData) :base(context,NoteListRowId,lstData )
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
                v = inflater.Inflate(Resource.Layout.FM_TransactionNR, parent, false);
            }
            v.FindViewById<TextView>(Resource.Id.TvJudul).Text = lstData[position].namaMenu.Substring(0, 2).ToUpper();
            v.FindViewById<TextView>(Resource.Id.TvNamaMenu).Text = lstData[position].namaMenu;
            v.FindViewById<TextView>(Resource.Id.TvHargaBeli).Text = "Harga : Rp." + lstData[position].hargaJual;
            v.FindViewById<TextView>(Resource.Id.TvKategori).Text = lstData[position].kategori;

            return v;
        }
    }
}