using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using NameName.DAL;
using NameName.Model;

namespace ShopClient
{
    class CashPrint
    {
        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        PrintDialog printdialog = new PrintDialog();

        Shop_SellList ssl;

        PaperSize ps = new PaperSize("Custom Size 1", 224, 800);
        public CashPrint(Shop_SellList shopshelllist)
        {
            ssl = shopshelllist;
            //自定义纸张            
            printDocument.DefaultPageSettings.PaperSize = ps;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            //printDocument.Print();  //直接打印
            printView();  //打印预览
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            printcash(e);
        }

        private void printcash(PrintPageEventArgs e)
        {
            float headerHeight = 10;
            Graphics newGraphic = e.Graphics;
            Font titleFont = new Font("宋体", 10, FontStyle.Bold);
            Font newFont = new Font("宋体", 9);
            RectangleF newRect = new RectangleF();

            headerHeight = 0;
            //int yTop = 0;

            StringFormat SF = new StringFormat();
            SF.LineAlignment = StringAlignment.Center;
            SF.Alignment = StringAlignment.Center;
            //标题
            newRect = new RectangleF(0, headerHeight, ps.Width, titleFont.Height + 10);
            newGraphic.DrawString("收银单", titleFont, Brushes.Black, newRect, SF);
            headerHeight += titleFont.Height + 10;
            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height);
            newGraphic.DrawString("单据号:" + ssl.BillNO + " 时间:" + ssl.BillDate.ToString("HH:mm:ss"), newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height;
            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height + 10);
            newGraphic.DrawString("地址:" + GlobalValue.GShop.Address, newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height;
            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height + 10);
            newGraphic.DrawString("---------------------------------", newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height;
            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height + 10);
            newGraphic.DrawString("产品     单位 数量  单价   金额  ", newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height;
            //内容
            SF.LineAlignment = StringAlignment.Center;
            foreach (Shop_SellDetail sd in ssl.Details)
            {
                int wleft = 0;
                SF.Alignment = StringAlignment.Near;
                newRect = new RectangleF(wleft, headerHeight, 65, newFont.Height);
                newGraphic.DrawString(sd.ProName, newFont, Brushes.Black, newRect);
                wleft += 60;
                newRect = new RectangleF(wleft, headerHeight, 30, newFont.Height);
                newGraphic.DrawString(sd.ProUnit, newFont, Brushes.Black, newRect);

                SF.Alignment = StringAlignment.Far;
                wleft += 25;
                newRect = new RectangleF(wleft, headerHeight, 40, newFont.Height);
                newGraphic.DrawString(sd.Amount.ToString("0.00"), newFont, Brushes.Black, newRect, SF);
                wleft += 35;
                newRect = new RectangleF(wleft, headerHeight, 50, newFont.Height);
                newGraphic.DrawString(sd.Price.ToString("0.00"), newFont, Brushes.Black, newRect, SF);
                wleft += 45;
                newRect = new RectangleF(wleft, headerHeight, 50, newFont.Height);
                newGraphic.DrawString(sd.DetailAmount.ToString("0.00"), newFont, Brushes.Black, newRect, SF);
                headerHeight += newFont.Height + 10;
            }
            SF.Alignment = StringAlignment.Center;
            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height);
            newGraphic.DrawString("----------------------------------", newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height + 10;

            //总计    应付金额
            //实付金额 找零
            newRect = new RectangleF(0, headerHeight, ps.Width / 2, newFont.Height);
            newGraphic.DrawString("总计:" + ssl.BillAmount.ToString("0.00"), newFont, Brushes.Black, newRect);
            newRect = new RectangleF(ps.Width / 2, headerHeight, ps.Width / 2, newFont.Height);
            newGraphic.DrawString("应付:" + ssl.ActAmount.ToString("0.00"), newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height + 10;

            newRect = new RectangleF(0, headerHeight, ps.Width / 2, newFont.Height);
            newGraphic.DrawString("实付:" + ssl.ActCustomAmount.ToString("0.00"), newFont, Brushes.Black, newRect);
            newRect = new RectangleF(ps.Width / 2, headerHeight, ps.Width / 2, newFont.Height);
            newGraphic.DrawString("找零:" + (ssl.ActCustomAmount - ssl.ActAmount).ToString("0.00"), newFont, Brushes.Black, newRect);
            headerHeight += newFont.Height + 10;

            newRect = new RectangleF(0, headerHeight, ps.Width, newFont.Height);
            newGraphic.DrawString("------谢谢光临 欢迎惠顾------------", newFont, Brushes.Black, newRect, SF);
        }

        private void printView()
        {
            printdialog.Document = printDocument;
            printdialog.AllowPrintToFile = printdialog.AllowSelection = printdialog.AllowSomePages = true;
            printPreviewDialog.Document = printDocument;
            printDocument.DefaultPageSettings.Landscape = false;

            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }
    }
}
