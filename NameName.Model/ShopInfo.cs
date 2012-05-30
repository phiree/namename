/***********************************************************************
 * Module:  ShopInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ShopInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class ShopInfo
    {
        public ShopInfo()
        {
            ShopUsers = new List<UserInfo>();
        }
        public virtual Guid ShopID { get; set; }
        public virtual string ShopNo { get; set; }
        public virtual AreaInfo AreaInfo { get; set; }
        public virtual string ShopName { get; set; }
        public virtual string Address { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual bool DeleteFlag { get; set; }
        public virtual bool IsCenter { get; set; }
        public virtual IList<UserInfo> ShopUsers { get; set; }


    }
}