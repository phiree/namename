/***********************************************************************
 * Module:  Account_Sum.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Account_Sum
 ***********************************************************************/

using System;
namespace NameName.Model
{public class Account_Sum
{
   private int _ID;
   private Guid _AccountID;
   private Guid _ShopID;
   private decimal _ImpAmount;
   private decimal _ExpAmount;
   private DateTime _AccountDate;
   private string _Memo;

   public int ID
   {
      get
      {
         return _ID;
      }
      set
      {
         if (this._ID != value)
            this._ID = value;
      }
   }
   
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
   
   public Guid ShopID
   {
      get
      {
         return _ShopID;
      }
      set
      {
         if (this._ShopID != value)
            this._ShopID = value;
      }
   }
   
   public decimal ImpAmount
   {
      get
      {
         return _ImpAmount;
      }
      set
      {
         if (this._ImpAmount != value)
            this._ImpAmount = value;
      }
   }
   
   public decimal ExpAmount
   {
      get
      {
         return _ExpAmount;
      }
      set
      {
         if (this._ExpAmount != value)
            this._ExpAmount = value;
      }
   }
   
   public DateTime AccountDate
   {
      get
      {
         return _AccountDate;
      }
      set
      {
         if (this._AccountDate != value)
            this._AccountDate = value;
      }
   }
   
   public string Memo
   {
      get
      {
         return _Memo;
      }
      set
      {
         if (this._Memo != value)
            this._Memo = value;
      }
   }

} }
