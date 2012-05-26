/***********************************************************************
 * Module:  Shop_AssignList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AssignList
 ***********************************************************************/

using System;

public class Shop_AssignList
{
   private string _AssBillNo;
   private Guid _ShopID;
   private decimal _Amount;
   private string _CrtUser;
   private string _CrtName;
   private DateTime _CrtDate;
   private string _ChkUser;
   private string _ChkName;
   private DateTime _ChkDate;

   public string AssBillNo
   {
      get
      {
         return _AssBillNo;
      }
      set
      {
         if (this._AssBillNo != value)
            this._AssBillNo = value;
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
   
   public decimal Amount
   {
      get
      {
         return _Amount;
      }
      set
      {
         if (this._Amount != value)
            this._Amount = value;
      }
   }
   
   public string CrtUser
   {
      get
      {
         return _CrtUser;
      }
      set
      {
         if (this._CrtUser != value)
            this._CrtUser = value;
      }
   }
   
   public string CrtName
   {
      get
      {
         return _CrtName;
      }
      set
      {
         if (this._CrtName != value)
            this._CrtName = value;
      }
   }
   
   public DateTime CrtDate
   {
      get
      {
         return _CrtDate;
      }
      set
      {
         if (this._CrtDate != value)
            this._CrtDate = value;
      }
   }
   
   public string ChkUser
   {
      get
      {
         return _ChkUser;
      }
      set
      {
         if (this._ChkUser != value)
            this._ChkUser = value;
      }
   }
   
   public string ChkName
   {
      get
      {
         return _ChkName;
      }
      set
      {
         if (this._ChkName != value)
            this._ChkName = value;
      }
   }
   
   public DateTime ChkDate
   {
      get
      {
         return _ChkDate;
      }
      set
      {
         if (this._ChkDate != value)
            this._ChkDate = value;
      }
   }

}