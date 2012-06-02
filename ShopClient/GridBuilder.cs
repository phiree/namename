using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
namespace ShopClient
{

    public partial class GridBuilder<T>
    {
        Dictionary<string, T> Source;

        Size ButtonSize;

        int ColAmount;

        int InitTop;
        int RowSpace;

        Control GridContainer;

        /// <summary>
        /// 创建 表格显示的控件
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="buttonsize">按钮大小</param>
        /// <param name="control">容器</param>
        /// <param name="colamount">列数</param>
        /// <param name="rowspace">行间距</param>
        /// <param name="inittop">初始化高度</param>

        public GridBuilder(Dictionary<string, T> source, Size buttonsize, Control control, int colamount, int rowspace, int inittop)
        {
            Source = source;
            ButtonSize = buttonsize;
            GridContainer = control;
            ColAmount = colamount;
            RowSpace = rowspace;
            InitTop = inittop;
        }

        public delegate void BindButtonClick(Button b);
        public event BindButtonClick OnBindButtonClick;

        public void BuildButtons()
        {

            int btnIndex = 0;
            int space = (GridContainer.Width - ColAmount * ButtonSize.Width) / (ColAmount + 1);

            foreach (KeyValuePair<string, T> kv in Source)
            {


                int currentRow = btnIndex / ColAmount;
                int currentCol = btnIndex % ColAmount;

                int left = space + (ButtonSize.Width + space) * currentCol;
                int top = InitTop + (RowSpace + ButtonSize.Height) * currentRow;

                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = ButtonSize;

                btn.Text = kv.Key;
                btn.Tag = kv.Value;
                if (OnBindButtonClick != null)
                {
                    OnBindButtonClick(btn);
                }
                GridContainer.Controls.Add(btn);

                btnIndex++;

            }
        }
    }
}
