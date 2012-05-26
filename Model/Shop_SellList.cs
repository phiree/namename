/***********************************************************************
 * Module:  Shop_SellList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_SellList
 ***********************************************************************/

using System;

public class Shop_SellList
{
   private string _BillNO;
   private Guid _DutyID;
   private DateTime _BillDate;
   private decimal _BillAmount;
   private bool _BackFlag;
   private string _BackBillNo;
   private string _Memo;
   private decimal _ActAmount;

   public string BillNO
   {
      get
      {
         return _BillNO;
      }
      set
      {
         if (this._BillNO != value)
            this._BillNO = value;
      }
   }
   
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
   
   public DateTime BillDate
   {
      get
      {
         return _BillDate;
      }
      set
      {
         if (this._BillDate != value)
            this._BillDate = value;
      }
   }
   
   public decimal BillAmount
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
   
   private decimal ActAmount
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
   
   public bool BackFlag
   {
      get
      {
         return _BackFlag;
      }
      set
      {
         if (this._BackFlag != value)
            this._BackFlag = value;
      }
   }
   
   public string BackBillNo
   {
      get
      {
         return _BackBillNo;
      }
      set
      {
         if (this._BackBillNo != value)
            this._BackBillNo = value;
      }
   }
   
   public string Memo
   {
      get
      {
         return _Memo;
      }
      set
      {
         if (this._Memo != value)
            this._Memo = value;
      }
   }

}