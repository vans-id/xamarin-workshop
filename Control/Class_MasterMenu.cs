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
using SQLite;

namespace AppPOS.Control
{
    class Class_MasterMenu
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string kategori { get; set; } = "";
        public string namaMenu { get; set; } = "";
        public float hargaBeli { get; set; } = 0;
        public float hargaJual { get; set; } = 0;
        
    }
}