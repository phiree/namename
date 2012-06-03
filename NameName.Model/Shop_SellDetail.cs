/***********************************************************************
 * Module:  Shop_SellDetail.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_SellDetail
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Shop_SellDetail
    {
        public virtual int ID{get;set;}
        public virtual string BillNO{get;set;}
        public virtual ProInfo Pro{get;set;}
        public virtual string Unit{get;set;}
        public virtual decimal Amount{get;set;}
        public virtual decimal Price{get;set;}

    }
}