/***********************************************************************
 * Module:  Shop_AskList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskList
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Shop_AskList
    {
        public virtual string AskBillNo{get;set;}
        public virtual Guid ShopID{get;set;}
        public virtual string UserName{get;set;}
        public virtual string TrueName{get;set;}
        public virtual DateTime CrtDate{get;set;}
        public virtual DateTime AppDate{get;set;}
        public virtual int State{get;set;}
        public virtual string PurBillNo{get;set;}
    }
}