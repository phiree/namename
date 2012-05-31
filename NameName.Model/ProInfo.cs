/***********************************************************************
 * Module:  ProInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class ProInfo
    {
        public ProInfo()
        {
            ProPrices = new List<ProPrice>();
        }
        public virtual Guid ProID { get; set; }
        public virtual string ProCate { get; set; }
        public virtual string Name { get; set; }
        public virtual string Unit { get; set; }
        public virtual string PicName { get; set; }
        public virtual string Memo { get; set; }
        public virtual bool DeleteFlag { get; set; }
        public virtual DateTime LastUpDateTime { get; set; }
        public virtual IList<ProPrice> ProPrices { get; set; }
    }
}