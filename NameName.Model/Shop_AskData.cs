/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;
namespace NameName.Model
{public class Shop_AskData
{
   private int _ID;
   private Guid _ShopID;
   private Guid _ProID;
   private decimal _Qty;

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
   
   public decimal Qty
   {
      get
      {
         return _Qty;
      }
      set
      {
         if (this._Qty != value)
            this._Qty = value;
      }
   }

} }
