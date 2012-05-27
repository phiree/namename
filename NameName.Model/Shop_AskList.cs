/***********************************************************************
 * Module:  Shop_AskList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskList
 ***********************************************************************/

using System;
namespace NameName.Model
{ public class Shop_AskList
{
   private string _AskBillNo;
   private Guid _ShopID;
   private string _UserName;
   private string _TrueName;
   private DateTime _CrtDate;
   private DateTime _AppDate;
   private int _State;
   private string _PurBillNo;

   public string AskBillNo
   {
      get
      {
         return _AskBillNo;
      }
      set
      {
         if (this._AskBillNo != value)
            this._AskBillNo = value;
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
   
   public string UserName
   {
      get
      {
         return _UserName;
      }
      set
      {
         if (this._UserName != value)
            this._UserName = value;
      }
   }
   
   public string TrueName
   {
      get
      {
         return _TrueName;
      }
      set
      {
         if (this._TrueName != value)
            this._TrueName = value;
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
   
   public DateTime AppDate
   {
      get
      {
         return _AppDate;
      }
      set
      {
         if (this._AppDate != value)
            this._AppDate = value;
      }
   }
   
   public int State
   {
      get
      {
         return _State;
      }
      set
      {
         if (this._State != value)
            this._State = value;
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

}}
