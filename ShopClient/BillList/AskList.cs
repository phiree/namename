using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameName.DAL;
using NameName.Model;

namespace ShopClient.BillList
{
    public partial class AskList : ListFrm
    {
        public AskList()
        {

        }


        public void ShowAskList(DateTime begindate, DateTime enddate)
        {
            Bdate = begindate;
            EDate = enddate;
            GetData();
            ShowDialog();
        }

        public override void GetData()
        {
            base.GetData();
            DALShopAskList dsal = new DALShopAskList();
            IList<Shop_AskList> sals = dsal.GetByDateTime(Bdate, EDate, GlobalValue.GShop.ShopID);
            dataGridView1.DataSource = sals;
        }

        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.ColumnIndex == 2)
        //    {
        //        switch (e.Value.ToString())
        //        {
        //            case "1":
        //                e.Value = "提交";
        //                break;
        //            case "2":
        //                e.Value = "采购";
        //                break;
        //            case "3":
        //                e.Value = "配货";
        //                break;
        //        }
        //    }
        //}

    }
}
