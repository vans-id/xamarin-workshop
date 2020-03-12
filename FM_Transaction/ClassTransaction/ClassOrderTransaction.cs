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

namespace AppPOS.FM_Transaction.ClassTransaction
{
    class ClassOrderTransaction
    {
        public int id, jmlItem;
        public string kategori, namaMenu;
        public float hargaBeli, hargaJual;

        public ClassOrderTransaction(int _id, string _kategori, string _namaMenu, float _hargaBeli, float _hargaJual, int jmlItem)
        {
            this.id = _id;
            this.kategori = _kategori;
            this.namaMenu = _namaMenu;
            this.hargaBeli = _hargaBeli;
            this.hargaJual = _hargaJual;
            this.jmlItem = jmlItem;
        
        }
    }
}