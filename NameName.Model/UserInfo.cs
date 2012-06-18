/***********************************************************************
 * Module:  UserInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class UserInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class UserInfo
    {
        public virtual string UserName { get; set; }
        public virtual  string TrueName{get;set;}
        public virtual  string Pwd{get;set;}
        public virtual  string Tel{get;set;}
        public virtual  string Mobile{get;set;}
        public virtual  int OrderNO{get;set;}
        public virtual  int RightSet{get;set;}
        public virtual  DepartInfo DepartInfo{get;set;}
        public virtual AreaInfo AreaInfo { get; set; }
        public virtual ShopInfo ShopInfo { get; set; }
        public virtual bool IsShopUser { get; set; }
        public virtual bool IsShopManager { get; set; }        
        public virtual  bool DeleteFlag{get;set;}

    }
}