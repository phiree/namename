/***********************************************************************
 * Module:  AreaInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class AreaInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class AreaInfo
    {
        public AreaInfo()
        {
            AreaShops = new List<ShopInfo>();
        }
        public virtual Guid AreaID { get; set; }
        public virtual string AreaName { get; set; }
        public virtual int OrderNO { get; set; }
        public virtual bool DeleteFlag { get; set; }
        public virtual IList<ShopInfo> AreaShops { get; set; }
        public virtual IList<UserInfo> PurUsers { get; set; }

    }
}