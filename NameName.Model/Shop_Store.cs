/***********************************************************************
 * Module:  Store_AccountSum.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Store_AccountSum
 ***********************************************************************/

using System;
namespace NameName.Model
{
public class Shop_Store
{
   private int _Id;
   private Guid _AccountID;
   private Guid _ShopID;
   private Guid _ProID;
   private decimal _PreQty;
   private decimal _ImpQty;
   private decimal _ExpQty;
   private decimal _ChkQty;
   private decimal _CurrQty;

   public int Id
   {
      get
      {
         return _Id;
      }
      set
      {
         if (this._Id != value)
            this._Id = value;
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
   
   public Guid ProID
   {
      get
      {
         return _ProID;
      }
      set
      {
         if (this._ProID != value)
            this._ProID = value;
      }
   }
   
   public decimal PreQty
   {
      get
      {
         return _PreQty;
      }
      set
      {
         if (this._PreQty != value)
            this._PreQty = value;
      }
   }
   
   public decimal ImpQty
   {
      get
      {
         return _ImpQty;
      }
      set
      {
         if (this._ImpQty != value)
            this._ImpQty = value;
      }
   }
   
   public decimal ExpQty
   {
      get
      {
         return _ExpQty;
      }
      set
      {
         if (this._ExpQty != value)
            this._ExpQty = value;
      }
   }
   
   public decimal ChkQty
   {
      get
      {
         return _ChkQty;
      }
      set
      {
         if (this._ChkQty != value)
            this._ChkQty = value;
      }
   }
   
   public decimal CurrQty
   {
      get
      {
         return _CurrQty;
      }
      set
      {
         if (this._CurrQty != value)
            this._CurrQty = value;
      }
   }

} }