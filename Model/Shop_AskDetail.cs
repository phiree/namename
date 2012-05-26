/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;

public class Shop_AskDetail
{
   private int _ID;
   private string _AsklBillNo;
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
   
   public string AskBillNo
   {
      get
      {
         return _AsklBillNo;
      }
      set
      {
         if (this._AsklBillNo != value)
            this._AsklBillNo = value;
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

}