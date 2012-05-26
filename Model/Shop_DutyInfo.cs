/***********************************************************************
 * Module:  Shop_DutyInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_DutyInfo
 ***********************************************************************/

using System;

public class Shop_DutyInfo
{
   private Guid _DutyID;
   private Guid _ShopID;
   private string _UserName;
   private string _TrueName;
   private DateTime _BeginDate;
   private DateTime _EndDate;
   private int _BillCount;
   private Decimal _BillAmount;
   private int _BackCount;
   private Decimal _BackAmount;
   private Decimal _ActAmount;
   private Guid _AccountID;

   public Guid DutyID
   {
      get
      {
         return _DutyID;
      }
      set
      {
         if (this._DutyID != value)
            this._DutyID = value;
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
   
   public DateTime BeginDate
   {
      get
      {
         return _BeginDate;
      }
      set
      {
         if (this._BeginDate != value)
            this._BeginDate = value;
      }
   }
   
   public DateTime EndDate
   {
      get
      {
         return _EndDate;
      }
      set
      {
         if (this._EndDate != value)
            this._EndDate = value;
      }
   }
   
   public int BillCount
   {
      get
      {
         return _BillCount;
      }
      set
      {
         if (this._BillCount != value)
            this._BillCount = value;
      }
   }
   
   public Decimal BillAmount
   {
      get
      {
         return _BillAmount;
      }
      set
      {
         if (this._BillAmount != value)
            this._BillAmount = value;
      }
   }
   
   public int BackCount
   {
      get
      {
         return _BackCount;
      }
      set
      {
         if (this._BackCount != value)
            this._BackCount = value;
      }
   }
   
   public Decimal BackAmount
   {
      get
      {
         return _BackAmount;
      }
      set
      {
         if (this._BackAmount != value)
            this._BackAmount = value;
      }
   }
   
   public Decimal ActAmount
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
   
   private Guid AccountID
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

}