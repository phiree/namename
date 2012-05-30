/***********************************************************************
 * Module:  Account_Period.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Account_Period
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Account_Period
    {
        public virtual Guid AccountID { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime? EndDate { get; set; }

    }
}