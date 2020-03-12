using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using AppPOS.FM_MasterMenu;
using AppPOS.FM_Report;
using AppPOS.FM_Transaction;

namespace AppPOS
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Visibility = ViewStates.Gone;
           // fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //load default Layout
            FragmentManager.PopBackStack();
            var fm = FragmentManager.BeginTransaction();
            fm.AddToBackStack(null);
            fm.Add(Resource.Id.homeFrameLayout, new Fragment_FM_Transaction());
            fm.SetTransition(FragmentTransit.FragmentOpen);
            fm.Commit();
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_masterMenu)
            {
                // Handle the camera action
                FragmentManager.PopBackStack();
                var fmMasterMenu = FragmentManager.BeginTransaction();
                fmMasterMenu.AddToBackStack(null);
                fmMasterMenu.Add(Resource.Id.homeFrameLayout, new Fragment_FM_MasterMenu());
                fmMasterMenu.SetTransition(FragmentTransit.FragmentOpen);
                fmMasterMenu.Commit();
                    }
            else if(id==Resource.Id.nav_transaction)
            {
                FragmentManager.PopBackStack();
                var fmTransaction = FragmentManager.BeginTransaction();
                fmTransaction.AddToBackStack(null);
                fmTransaction.Add(Resource.Id.homeFrameLayout, new Fragment_FM_Transaction());
                fmTransaction.SetTransition(FragmentTransit.FragmentOpen);
                fmTransaction.Commit();
            }
            else if(id==Resource.Id.nav_report)
            {
                FragmentManager.PopBackStack();
                var fmReport = FragmentManager.BeginTransaction();
                fmReport.AddToBackStack(null);
                fmReport.Add(Resource.Id.homeFrameLayout, new Fragment_FM_Report());
                fmReport.SetTransition(FragmentTransit.FragmentOpen);
                fmReport.Commit();
            }


            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

