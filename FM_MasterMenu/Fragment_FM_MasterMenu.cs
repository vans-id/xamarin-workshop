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
    public class Fragment_FM_MasterMenu : Fragment
    {

        private ListView lvMasterMenu;
        private ImageView addMenu;

        private FragmentManager fm;
        private FragmentTransaction next;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.FM_MasterMenu,container,false);
            lvMasterMenu = view.FindViewById<ListView>(Resource.Id.FMMDMLvMasterMenu);
            addMenu = view.FindViewById<ImageView>(Resource.Id.FMKPTImgBarcode);

            fm = FragmentManager;
            next = FragmentManager.BeginTransaction();

            loadData();
            addMenu.Click += AddMenu_Click;
            return view;
        }

        private void AddMenu_Click(object sender, EventArgs e)
        {
            ClassMasterMenu.ClassTransition ct;
            ct = new ClassMasterMenu.ClassTransition();
            ct.openFragment_FM_MasterMenuAdd(this.Activity, fm, next);
        }

        private void loadData()
        {
            new ClassMasterMenu.ClassDataparser(this.Activity, fm, next, lvMasterMenu, addMenu).Execute();
        }
    }
}