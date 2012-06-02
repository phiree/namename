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

    public partial class GridBuilder<T> : UserControl
    {
        public Dictionary<string,T> Source
        {
            get;
            set;
        }
        public Size ButtonSize
        { get; set; }
        //列数
       public int ColAmount{get;set;}
        //顶部空间
        public int InitTop { get; set; }
        public int RowSpace { get; set; }
        public int ColSpace { get; set; }
        public Control GridContainer{get;set;}
        public GridBuilder()
        {
            InitializeComponent();
        }
        public delegate void BindButtonClick(Button b); 
         public event BindButtonClick OnBindButtonClick ;
        public void BuildButtons()
        {
           
            int btnIndex = 0;
                

              

            int space = (GridContainer.Width - ColAmount * ButtonSize.Width) /(ColAmount+1);

            foreach (KeyValuePair<string,T> kv in Source)
            {
               
               
                    int currentRow = btnIndex / ColAmount;
                    int currentCol = btnIndex % ColAmount;

                    int left = space + (ButtonSize.Width + space) * currentCol;
                    int top = (InitTop + ButtonSize.Height) * currentRow + InitTop;

                    Button btn = new Button();
                    btn.Left = left;
                    btn.Top = top;
                  btn.Size=ButtonSize;

                    btn.Text =kv.Key;
                    btn.Tag = kv.Value;
                    if (OnBindButtonClick!= null)
                    {
                        OnBindButtonClick(btn);
                    }
                    GridContainer.Controls.Add(btn);

                    btnIndex++;
                
            }
        }
        }
    }
}
