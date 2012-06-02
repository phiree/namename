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
        IList<T> Source;
        Size ItemSize;
        
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

        public GridBuilder(IList<T> source, Size itemsize, Control control, int colamount, int rowspace, int inittop)
        {
            Source = source;
            ItemSize = itemsize;
            GridContainer = control;
            ColAmount = colamount;
            RowSpace = rowspace;
            InitTop = inittop;
        }

        public delegate void AddItem(T t, Rectangle position, Control gridcontainer);
        public event AddItem OnAddItem;

        public void BuildButtons()
        {

            int btnIndex = 0;
            int space = (GridContainer.Width - ColAmount * ItemSize.Width) / (ColAmount + 1);

            foreach (T t in Source)
            {
                int currentRow = btnIndex / ColAmount;
                int currentCol = btnIndex % ColAmount;
                int left = space + (ItemSize.Width + space) * currentCol;
                int top = InitTop + (RowSpace + ItemSize.Height) * currentRow;              

                if (OnAddItem != null)
                {
                    OnAddItem(t, new Rectangle(left, top, ItemSize.Width, ItemSize.Height), GridContainer);
                }
                
                btnIndex++;

            }
        }
    }
}
