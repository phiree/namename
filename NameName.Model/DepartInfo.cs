/***********************************************************************
 * Module:  DepartInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class DepartInfo
 ***********************************************************************/

using System;
using System.Collections.Generic;
namespace NameName.Model
{
    public class DepartInfo
    {
        public DepartInfo()
        {
            DepartUsers = new List<UserInfo>();
        }
        public virtual  Guid DepartID{get;set;}
        public virtual  int OrderNO{get;set;}
        public virtual  string DepartName{get;set;}
        public virtual  bool DeleteFlag{get;set;}
        public virtual IList<UserInfo> DepartUsers { get; set; }
    }
}