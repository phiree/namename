/***********************************************************************
 * Module:  ProPrice.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProPrice
 ***********************************************************************/

using System;
namespace NameName.Model
{
    /// <summary>
    /// 产品库存上下限
    /// </summary>
    public class Shop_StoreLimit
    {
        public virtual Guid Id { get; set; }
        public virtual ShopInfo ShopInfo { get; set; }
        public virtual ProInfo ProInfo { get; set; }
        //上限
        public virtual decimal MaxLimit { get; set; }
        //下限
        public virtual decimal MinLimit { get; set; }

        public virtual string ShopName { get { return ShopInfo.ShopName; } set { } }
        public virtual string ProName { get { return ProInfo.Name; } set { } }

    }
}