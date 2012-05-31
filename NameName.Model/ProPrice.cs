/***********************************************************************
 * Module:  ProPrice.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProPrice
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class ProPrice
    {
        public virtual int Id { get; set; }
        public virtual AreaInfo AreaInfo { get; set; }
        public virtual ProInfo ProInfo { get; set; }
        public virtual Decimal Price { get; set; }
        

    }
}