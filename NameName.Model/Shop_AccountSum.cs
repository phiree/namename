/***********************************************************************
 * Module:  Shop_AccountSum.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AccountSum
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class Shop_AccountSum
    {
        public virtual int Id { get; set; }
        public virtual Account_Period Account_Period { get; set; }
        public virtual ShopInfo ShopInfo { get; set; }
        public virtual ProInfo ProInfo { get; set; }
        public virtual decimal PreQty { get; set; }
        public virtual decimal ImpQty { get; set; }
        public virtual decimal ExpQty { get; set; }
        public virtual decimal ChkQty { get; set; }
        public virtual decimal CurrQty { get; set; }
    }
}