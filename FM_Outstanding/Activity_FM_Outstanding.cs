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
using Newtonsoft.Json;

namespace AppPOS.FM_Outstanding
{
    [Activity(Label = "Activity_FM_Outstanding")]
    public class Activity_FM_Outstanding : Activity
    {
        private ListView lvMenuOutstanding;
        private TextView tvTotalHarga;
        private Button btnOrderNow;
        private ImageView imgBack;

        //private List<FM_Transaction.ClassTransaction.ClassOrderTransaction> listOrderTransaction;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FM_Outstanding);
            lvMenuOutstanding = FindViewById<ListView>(Resource.Id.LvMenuOrder);
            tvTotalHarga = FindViewById<TextView>(Resource.Id.TvTotalHargaOrder);
            btnOrderNow = FindViewById<Button>(Resource.Id.BtnOrderNow);
            imgBack = FindViewById<ImageView>(Resource.Id.ImgBack);

            //listOrderTransaction = new List<FM_Transaction.ClassTransaction.ClassOrderTransaction>();
            //listOrderTransaction = JsonConvert.DeserializeObject<List<FM_Transaction.ClassTransaction.ClassOrderTransaction>>(Intent.GetStringExtra("outstanding"));

            imgBack.Click += ImgBack_Click;

            new ClassOutstanding.ClassDataparser(this, lvMenuOutstanding, tvTotalHarga, btnOrderNow).Execute();
        }

        private void ImgBack_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}