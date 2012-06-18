/***********************************************************************
 * Module:  ProPrice.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProPrice
 ***********************************************************************/

using System;
namespace NameName.Model
{
    /// <summary>
    /// ��Ʒ���������
    /// </summary>
    public class Shop_StoreLimit
    {
        public virtual Guid Id { get; set; }
        public virtual ShopInfo ShopInfo { get; set; }
        public virtual ProInfo ProInfo { get; set; }
        //����
        public virtual decimal MaxLimit { get; set; }
        //����
        public virtual decimal MinLimit { get; set; }

        public virtual string ShopName { get { return ShopInfo.ShopName; } set { } }
        public virtual string ProName { get { return ProInfo.Name; } set { } }

    }
}