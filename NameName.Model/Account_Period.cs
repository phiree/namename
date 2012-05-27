/***********************************************************************
 * Module:  Account_Period.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Account_Period
 ***********************************************************************/

using System;
namespace NameName.Model
{public class Account_Period
{
   private Guid _AccountID;
   private DateTime _BeginDate;
   private DateTime? _EndDate;

   public Guid AccountID
   {
      get
      {
         return _AccountID;
      }
      set
      {
         if (this._AccountID != value)
            this._AccountID = value;
      }
   }
   
   public DateTime BeginDate
   {
      get
      {
         return _BeginDate;
      }
      set
      {
         if (this._BeginDate != value)
            this._BeginDate = value;
      }
   }
   
   public DateTime? EndDate
   {
      get
      {
         return _EndDate;
      }
      set
      {
         if (this._EndDate != value)
            this._EndDate = value;
      }
   }

} }
