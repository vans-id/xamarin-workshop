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

namespace AppPOS.FM_Outstanding.ListViewRow
{
    class LvRow_MenuOutstanding
    {
        public int id;
        public string kategori, namaMenu;
        public float hargaBeli, hargaJual;
        public int jmlItem;
        public float totalHarga;

        public LvRow_MenuOutstanding(int _id, string _kategori, string _namaMenu, float _hargaBeli, float _hargaJual, int _jmlItem, float _totalHarga)
        {
            this.id = _id;
            this.kategori = _kategori;
            this.namaMenu = _namaMenu;
            this.hargaBeli = _hargaBeli;
            this.hargaJual = _hargaJual;
            this.jmlItem = _jmlItem;
            this.totalHarga = _totalHarga;
        }
    }
}