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

namespace AppPOS.FM_MasterMenu.ClassMasterMenu
{
    class ClassTransition
    {
        public void openFragment_FM_MasterMenuAdd(Context c,FragmentManager fm, FragmentTransaction next)
        {
            next.Replace(Resource.Id.homeFrameLayout, new Fragment_FM_MasterMenuAdd());
            next.AddToBackStack(null);
            next.SetTransition(FragmentTransit.FragmentFade);
            next.Commit();
        }

        public void openFragment_FM_MasterMenu(Context c, FragmentManager fm, FragmentTransaction next)
        {
            next.Replace(Resource.Id.homeFrameLayout, new Fragment_FM_MasterMenu());
            next.AddToBackStack(null);
            next.SetTransition(FragmentTransit.FragmentFade);
            next.Commit();
        }
    }
}