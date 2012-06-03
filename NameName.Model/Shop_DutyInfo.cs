/***********************************************************************
 * Module:  Shop_DutyInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_DutyInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Shop_DutyInfo
    {
        public virtual Guid DutyID{get;set;}
        public virtual ShopInfo Shop{get;set;}
        public virtual UserInfo User{get;set;}
       
        public virtual DateTime BeginDate{get;set;}
        public virtual DateTime? EndDate{get;set;}
        public virtual int BillCount{get;set;}
        public virtual Decimal BillAmount{get;set;}
        public virtual int BackCount{get;set;}
        public virtual Decimal BackAmount{get;set;}
        public virtual Decimal ActAmount{get;set;}
        public virtual Account_Period AccountPeriod{get;set;}

    }
}