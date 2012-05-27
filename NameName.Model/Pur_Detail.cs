/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;
namespace NameName.Model
{public class Pur_Detail
{
   private int _ID;
   private string _PurBillNo;
   private Guid _ProID;
   private decimal _Qty;
   private decimal _ActQty;
   private int _BuyPrice;
   private decimal _PurAmount;
   private decimal _ActAmount;

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
   
   public string PurBillNo
   {
      get
      {
         return _PurBillNo;
      }
      set
      {
         if (this._PurBillNo != value)
            this._PurBillNo = value;
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
   
   public int BuyPrice
   {
      get
      {
         return _BuyPrice;
      }
      set
      {
         if (this._BuyPrice != value)
            this._BuyPrice = value;
      }
   }
   
   public decimal PurQty
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
   
   public decimal ActQty
   {
      get
      {
         return _ActQty;
      }
      set
      {
         if (this._ActQty != value)
            this._ActQty = value;
      }
   }
   
   public decimal PurAmount
   {
      get
      {
         return _PurAmount;
      }
      set
      {
         if (this._PurAmount != value)
            this._PurAmount = value;
      }
   }
   
   public decimal ActAmount
   {
      get
      {
         return _ActAmount;
      }
      set
      {
         if (this._ActAmount != value)
            this._ActAmount = value;
      }
   }

} }
