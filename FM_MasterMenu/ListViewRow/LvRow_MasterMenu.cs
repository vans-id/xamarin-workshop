﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppPOS.FM_MasterMenu.ListViewRow
{
    class LvRow_MasterMenu
    {
        public int id;
        public string kategori, namaMenu, hargaBeli, hargaJual;

        public LvRow_MasterMenu(int _id, string _kategori, string _namaMenu, string _hargaBeli, string _hargaJual)
        {
            this.id = _id;
            this.kategori = _kategori;
            this.namaMenu = _namaMenu;
            this.hargaBeli = _hargaBeli;
            this.hargaJual = _hargaJual;
        }
    }
}