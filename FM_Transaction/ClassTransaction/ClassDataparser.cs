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
using AppPOS.FM_Outstanding;
using AppPOS.FM_Transaction.Model;

namespace AppPOS.FM_Transaction.ClassTransaction
{
    class ClassDataparser :AsyncTask
    {
        private FragmentManager fm;
        private FragmentTransaction next;
        private ProgressDialog pd;
        private Context c;

        private ListView lvMasterData;
        private TextView tvInfoItem;
        private ImageView imgDelete;
        private Button btnChekOut;

        private Model.DB_Transaction mod_masterMenu;
        private List<Control.Class_MasterMenu> con_ListSourceTransaction;

        private List<ListViewRow.LvRow_MasterMenu> listMasterMenu;

        // order Transaction
        // private List<ClassOrderTransaction> listOrder;
        private List<Control.Class_Outstanding> listOutstanding;
        private int jmlItemTransaction;
        

        public ClassDataparser(Context _c, FragmentManager _fm, FragmentTransaction _next, ListView _lvMasterData,TextView _tvInfoItem,ImageView _imgDelete,Button _btnChekOut)
        {
            this.c = _c;
            this.fm = _fm;
            this.next = _next;
            this.lvMasterData = _lvMasterData;
            this.tvInfoItem = _tvInfoItem;
            this.imgDelete = _imgDelete;
            this.btnChekOut = _btnChekOut;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();

            pd = new ProgressDialog(c);
            pd.Show();
            
        }

        protected override void OnPostExecute(Java.Lang.Object result)
        {
            base.OnPostExecute(result);
            pd.Dismiss();
            if((bool)result)
            {
                FillListViewControl();
                lvMasterData.ItemClick += LvMasterData_ItemClick;
                btnChekOut.Click += BtnChekOut_Click;
            }
            else
            {

            }
        }

        private void BtnChekOut_Click(object sender, EventArgs e)
        {
            ClassTransition transition;
            transition = new ClassTransition();
            Intent intent = new Intent(c, typeof(Activity_FM_Outstanding));
            transition.nextLayout(c, intent);
        }

        private void LvMasterData_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
     

            int position=0;
     
            foreach(ListViewRow.LvRow_MasterMenu a in listMasterMenu)
            {
                if(position==e.Position)
                {
                    //listOrder.Add(new ClassOrderTransaction(a.id, a.kategori, a.namaMenu, a.hargaBeli, a.hargaJual, 1));
                    Control.Class_Outstanding data = new Control.Class_Outstanding()
                    {
                        idMenu = a.id.ToString(),
                        kategori = a.kategori,
                        namaMenu = a.namaMenu,
                        hargaBeli = a.hargaBeli,
                        hargaJual = a.hargaJual,

                    };
                    mod_masterMenu.insertTable(data);
                    jmlItemTransaction++;
                    successDialogPopUp(a.namaMenu);
                    break;
                }
                else
                {
                    position++;
                }
            }            
        }

        private void successDialogPopUp(string _namaMenu)
        {
            AlertDialog dialog = new AlertDialog.Builder(c).Create();
            dialog.SetTitle("Success Transaction");
            dialog.SetMessage("Berhasil Menambahkan Menu " + _namaMenu);
            dialog.Show();

            tvInfoItem.Text = jmlItemTransaction.ToString() + "Item";
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            mod_masterMenu = new Model.DB_Transaction();
            mod_masterMenu.createDatabase();
            //listOrder = new List<ClassOrderTransaction>();
          //  mod_masterMenu.createDatabaseMasterMenu();
            return parserData();
        }

        private bool parserData()
        {
            try
            {
                con_ListSourceTransaction = new List<Control.Class_MasterMenu>();
                listMasterMenu = new List<ListViewRow.LvRow_MasterMenu>();
                con_ListSourceTransaction = mod_masterMenu.selectTable();
                if(con_ListSourceTransaction.Count>0)
                {
                    foreach(Control.Class_MasterMenu a in con_ListSourceTransaction)
                    {
                        listMasterMenu.Add(new ListViewRow.LvRow_MasterMenu(a.ID, a.kategori, a.namaMenu, a.hargaBeli, a.hargaJual));
                    }
                    
                }
                else
                {
                    //Toast.MakeText(c, "Data Tidak Ditemukan", ToastLength.Short).Show();
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void FillListViewControl()
        {
            lvMasterData.Adapter = new ListViewRow.LvRow_MasterMenuNR(c, Resource.Layout.FM_TransactionNR, listMasterMenu);
        }
    }
}