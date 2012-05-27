/***********************************************************************
 * Module:  Shop_AskData.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskData
 ***********************************************************************/

using System;
namespace NameName.Model
{ public class Pur_Assign
{
   private int _ID;
   private string _PurBillNo;
   private Guid _ShopID;
   private Guid _ProID;
   private decimal _AskQty;
   private decimal _AssignQty;

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

}}
