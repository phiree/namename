/***********************************************************************
 * Module:  Shop_SellList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_SellList
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Shop_SellList
    {
        public Shop_SellList()
        {
            Details =new  System.Collections.Generic.List<Shop_SellDetail>();
        }
        public virtual string BillNO{get;set;}
        public virtual Shop_DutyInfo Duty{get;set;}
        public virtual DateTime BillDate{get;set;}
        public virtual decimal BillAmount{get;set;}
        public virtual bool BackFlag{get;set;}
        public virtual string BackBillNo{get;set;}
        public virtual string Memo{get;set;}
        public virtual decimal ActAmount{get;set;}
        public virtual decimal ActCustomAmount { get; set; }
        public virtual System.Collections.Generic.IList<Shop_SellDetail> Details { get; set; }

    }
}