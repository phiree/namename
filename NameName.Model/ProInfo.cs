/***********************************************************************
 * Module:  ProInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class ProInfo
    {
        public virtual Guid ProID { get; set; }
        public virtual string ProCate { get; set; }
        public virtual string Name { get; set; }
        public virtual string Unit { get; set; }
        public virtual string PicName { get; set; }
        public virtual string Memo { get; set; }
        public virtual bool DeleteFlag { get; set; }
    }
}