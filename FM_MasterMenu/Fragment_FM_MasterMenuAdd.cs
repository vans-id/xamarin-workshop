using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AppPOS.FM_MasterMenu
{
    public class Fragment_FM_MasterMenuAdd : Fragment
    {

        private EditText edtKategori, edtNamaMenu, edtHargaBeli, edtHargaJual;
        private Button btnSimpan;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            // View view = inflater.Inflate(Resource.Layout)

            View view = inflater.Inflate(Resource.Layout.FM_MasterMenuAdd, container, false);
            edtKategori = view.FindViewById<EditText>(Resource.Id.EdtKategori);
            edtNamaMenu = view.FindViewById<EditText>(Resource.Id.EdtNamaMenu);
            edtHargaBeli = view.FindViewById<EditText>(Resource.Id.EdtHargaBeli);
            edtHargaJual = view.FindViewById<EditText>(Resource.Id.EdtHargaJual);
            btnSimpan = view.FindViewById<Button>(Resource.Id.BtnSimpan);

            btnSimpan.Click += BtnSimpan_Click;
            return view;
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            new ClassMasterMenu.ClassInsertMenu(this.Activity, edtKategori, edtNamaMenu, edtHargaBeli, edtHargaJual, btnSimpan).Execute();
        }
    }
}