/***********************************************************************
 * Module:  Shop_AskList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskList
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class Shop_AskList
    {
        public Shop_AskList()
        {
            Details = new List<Shop_AskDetail>();
        }
        public virtual string AskBillNo{get;set;}
        public virtual ShopInfo ShopInfo{get;set;}
        public virtual UserInfo UserInfo{get;set;}
        
        public virtual DateTime CrtDate{get;set;}
        public virtual DateTime AppDate{get;set;}
        public virtual int State{get;set;}
        public virtual string PurBillNo{get;set;}
        public virtual IList<Shop_AskDetail> Details { get; set; }
    }
}