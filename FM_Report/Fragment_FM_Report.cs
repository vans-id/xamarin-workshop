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

namespace AppPOS.FM_Report
{
    public class Fragment_FM_Report : Fragment
    {
        ListView lvOrderTransaction;
        TextView tvProvit;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.FM_Report, container, false);
            lvOrderTransaction = view.FindViewById<ListView>(Resource.Id.LvTransaction);
            tvProvit = view.FindViewById<TextView>(Resource.Id.TvTotalProvit);

            new ClassReport.ClassDataparser(this.Activity, lvOrderTransaction, tvProvit).Execute();

            return view;
        }
    }
}