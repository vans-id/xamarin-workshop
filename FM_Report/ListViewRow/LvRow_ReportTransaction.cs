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

namespace AppPOS.FM_Report.ListViewRow
{
    class LvRow_ReportTransaction
    {
        public int id;
        public string idMenu, kategori, namaMenu;
        public float hargaBeli, hargaJual;
        public float jmlItem, totalHarga;
      

        public LvRow_ReportTransaction(int _id, string _idMenu, string _kategori, string _namaMenu, float _hargaBeli, float _hargaJual, float _jmlItem, float _totalHarga)
        {
            this.id = _id;
            this.idMenu = _idMenu;
            this.kategori = _kategori;
            this.namaMenu = _namaMenu;
            this.hargaBeli = _hargaBeli;
            this.hargaJual = _hargaJual;
            this.jmlItem = _jmlItem;
            this.totalHarga = _totalHarga;
        }
    }
}