/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;

public class Shop_TransDetail
{
   private int _ID;
   private string _BillNo;
   private Guid _ProID;
   private decimal _Qty;
   private decimal _Price;

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
   
   public string BillNo
   {
      get
      {
         return _BillNo;
      }
      set
      {
         if (this._BillNo != value)
            this._BillNo = value;
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
   
   public decimal Price
   {
      get
      {
         return _Price;
      }
      set
      {
         if (this._Price != value)
            this._Price = value;
      }
   }

}