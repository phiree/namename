using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using NameName.Model;
namespace NameName.Model.Mapping
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Id(x => x.UserName);
            References<DepartInfo>(x => x.DepartInfo);
            Map(x => x.DeleteFlag);
            Map(x => x.Mobile);
            Map(x => x.OrderNO);
            Map(x => x.Pwd);
            Map(x => x.RightSet);
            Map(x => x.TrueName);
            Map(x => x.Tel);
            Map(x => x.IsShopUser);
            Map(x => x.IsShopManager);
            References<ShopInfo>(x => x.ShopInfo);
            References<AreaInfo>(x => x.AreaInfo);

        }
    }
}
