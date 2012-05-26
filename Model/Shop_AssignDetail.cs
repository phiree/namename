/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;

public class Shop_AssignDetail
{
   private int _ID;
   private string _AssBillNo;
   private Guid _ProID;
   private decimal _AskQty;
   private decimal _AssignQty;
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
   
   public decimal AskQty
   {
      get
      {
         return _AskQty;
      }
      set
      {
         if (this._AskQty != value)
            this._AskQty = value;
      }
   }
   
   public decimal AssignQty
   {
      get
      {
         return _AssignQty;
      }
      set
      {
         if (this._AssignQty != value)
            this._AssignQty = value;
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