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
      
        public virtual ProInfo ProInfo{get;set;}
        public virtual decimal Qty{get;set;}
    }
}