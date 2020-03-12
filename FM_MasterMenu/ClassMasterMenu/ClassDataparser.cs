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
    class ClassDataparser : AsyncTask
    {
        private Context c;
        private FragmentManager fm;
        private FragmentTransaction next;

        private ListView lvMasterMenu;
        private ImageView addMenu;
        private ProgressDialog pd;

        private Model.DB_MasterMenu mod_masterMenu;
        private List<Control.Class_MasterMenu> listSource;
        private List<ListViewRow.LvRow_MasterMenu> listMasterMenu;

        // popup Control
        private EditText edtKategori, edtNamaMenu, edtHargaBeli, edtHargaJual;
        private TextView tvJudul;
        private Button btnSimpan;
        public ClassDataparser(Context _c,FragmentManager _fm, FragmentTransaction _next, ListView _lvMasterMenu, ImageView _addMenu)
        {
            this.c = _c;
            this.fm = _fm;
            this.next = _next;
            this.lvMasterMenu = _lvMasterMenu;
            this.addMenu = _addMenu;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            pd = new ProgressDialog(c);
            pd.SetTitle("Load Data");
            pd.SetMessage("Parse Data...Please wait");
            pd.Show();
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            mod_masterMenu = new Model.DB_MasterMenu();
            mod_masterMenu.createDatabase();
            return parseData();
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();

            if((bool)result)
            {
                FillListViewControl();
                lvMasterMenu.ItemClick += LvMasterMenu_ItemClick;
                lvMasterMenu.ItemLongClick += LvMasterMenu_ItemLongClick;
            }
            else
            {

            }
        }

        private void LvMasterMenu_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            int position = e.Position;
            int jmlData = 0;
            foreach (ListViewRow.LvRow_MasterMenu a in listMasterMenu)
            {
                if (position == jmlData)
                {
                    _id = a.id;
                    _kategori = a.kategori;
                    _namaMenu = a.namaMenu;
                    _hargaBeli = float.Parse(a.hargaBeli);
                    _hargaJual = float.Parse(a.hargaJual);
                    showPopUpDelete(_id, _kategori, _namaMenu, _hargaBeli, _hargaJual);
                    break;
                }
                else
                {
                    jmlData++;
                }
            }
        }

        private int _id;
        private string  _kategori, _namaMenu;
        private float _hargaBeli, _hargaJual;
        private void LvMasterMenu_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int position = e.Position;
            int jmlData = 0;
            foreach (ListViewRow.LvRow_MasterMenu a in listMasterMenu)
            {
                if (position == jmlData)
                {
                    _id = a.id;
                    _kategori = a.kategori;
                    _namaMenu = a.namaMenu;
                    _hargaBeli = float.Parse(a.hargaBeli);
                    _hargaJual = float.Parse(a.hargaJual);
                    showPopUp();
                    break;
                }
                else
                {
                    jmlData++;
                }
            }
        }

        AlertDialog dialog;

        private void showPopUpDelete(int _id, string _kategori, string _namaMenu, float _hargaBeli, float _hargaJual)
        {
            dialog = new AlertDialog.Builder(c).Create();
            dialog.SetTitle("Remove Menu");
            dialog.SetMessage("Apakah Anda ingin menghapus " + _namaMenu);
            dialog.SetButton("Ya", (c, ev) =>
             {
                 Control.Class_MasterMenu data = new Control.Class_MasterMenu()
                 {
                     ID = _id,
                     kategori = _kategori,
                     namaMenu = _namaMenu,
                     hargaBeli = _hargaBeli,
                     hargaJual = _hargaJual
                 };
                 mod_masterMenu.deleteTable(data);
                 parseData();
                 FillListViewControl();
             });
            dialog.SetButton2("Tidak", (c, ev) =>
             {
                 dialog.Dismiss();
             });
            dialog.Show();
        }

        private void showPopUp()
        {
            dialog = new AlertDialog.Builder(c).Create();

            LayoutInflater inflater = LayoutInflater.From(c);
            View view = inflater.Inflate(Resource.Layout.FM_MasterMenuAdd, null);
            tvJudul = view.FindViewById<TextView>(Resource.Id.textView1);
            edtKategori = view.FindViewById<EditText>(Resource.Id.EdtKategori);
            edtNamaMenu = view.FindViewById<EditText>(Resource.Id.EdtNamaMenu);
            edtHargaBeli = view.FindViewById<EditText>(Resource.Id.EdtHargaBeli);
            edtHargaJual = view.FindViewById<EditText>(Resource.Id.EdtHargaJual);
            btnSimpan = view.FindViewById<Button>(Resource.Id.BtnSimpan);

            // event
            tvJudul.Text = "Edit Menu";
            btnSimpan.Click += BtnSimpan_Click;

            // fill Toolbox control with Data
            edtKategori.Text = _kategori;
            edtNamaMenu.Text = _namaMenu;
            edtHargaBeli.Text = _hargaBeli.ToString();
            edtHargaJual.Text = _hargaJual.ToString();
            dialog.SetView(view);
            dialog.Show();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            Control.Class_MasterMenu menu = new Control.Class_MasterMenu()
            {
                ID = _id,
                kategori = edtKategori.Text.ToString(),
                namaMenu = edtNamaMenu.Text.ToString(),
                hargaBeli = float.Parse(edtHargaBeli.Text.ToString()),
                hargaJual = float.Parse(edtHargaJual.Text.ToString())
            };
            mod_masterMenu.updateTable(menu);
            dialog.Dismiss();
            parseData();
            FillListViewControl();
        }

        private bool parseData()
        {
            try
            {
                listSource = new List<Control.Class_MasterMenu>();
                listMasterMenu = new List<ListViewRow.LvRow_MasterMenu>();
                listSource = mod_masterMenu.selectTable();

                if(listSource.Count>0)
                {

                    foreach(Control.Class_MasterMenu a in listSource)
                    {
                        listMasterMenu.Add(new ListViewRow.LvRow_MasterMenu(a.ID, a.kategori, a.namaMenu, a.hargaBeli.ToString(),a.hargaJual.ToString()));
                    }
                 
                }
                else
                {
                    Toast.MakeText(c, "Data Tidak Ditemukan!", ToastLength.Short).Show();
                }
                return true;
            }
            catch(System.Exception ex)
            {
                return false;
                throw new System.Exception(ex.Message);
            }
        }

        private void FillListViewControl()
        {
            lvMasterMenu.Adapter = new ListViewRow.LvRow_MasterMenuNR(c, Resource.Layout.FM_MasterMenuNR, listMasterMenu);
        }
    }
}