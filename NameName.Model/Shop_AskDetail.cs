/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Shop_AskDetail
    {
        public virtual int ID{get;set;}
        public virtual string AsklBillNo{get;set;}
        public virtual Guid ProID{get;set;}
        public virtual decimal Qty{get;set;}
    }
}