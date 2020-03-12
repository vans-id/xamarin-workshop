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

namespace AppPOS.FM_Transaction
{
    public class Fragment_FM_Transaction : Fragment
    {
        FragmentManager fm;
        FragmentTransaction next;

        private ListView lvMasterMenu;
        private ImageView imgDelete;
        private TextView tvInfoItem;
        private Button btnChekOut;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.FM_Transaction, container, false);
            lvMasterMenu = view.FindViewById<ListView>(Resource.Id.LvMasterMenu);
            imgDelete = view.FindViewById<ImageView>(Resource.Id.ImgViewDelete);
            tvInfoItem = view.FindViewById<TextView>(Resource.Id.TVJmlItem);
            btnChekOut = view.FindViewById<Button>(Resource.Id.BtnOrder);

            fillDataMasterMenu();
            return view;
        }

        private void fillDataMasterMenu()
        {
            fm = FragmentManager;
            next = FragmentManager.BeginTransaction();
            new ClassTransaction.ClassDataparser(this.Activity, fm, next, lvMasterMenu, tvInfoItem, imgDelete, btnChekOut).Execute();
        }
    }
}