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

namespace AppPOS.FM_Transaction.ClassTransaction
{
    class ClassTransition
    {

        public void nextLayout(Context c,Intent intent)
        {
            //intent.PutExtra("outstanding", JsonConvert.SerializeObject(outstanding));
            c.StartActivity(intent);
        }
    }
}