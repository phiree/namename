/***********************************************************************
 * Module:  Shop_AskList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskList
 ***********************************************************************/

using System;

public class Pur_List
{
   private string _PurBillNo;
   private string _UserName;
   private string _TrueName;
   private DateTime _CrtDate;
   private string _ChkUser;
   private string _ChkName;
   private DateTime _ChkDate;
   private int _State;

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
   
   public string CrtUser
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
   
   public string CrtName
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
   
   public string ChkUser
   {
      get
      {
         return _ChkUser;
      }
      set
      {
         if (this._ChkUser != value)
            this._ChkUser = value;
      }
   }
   
   public string ChkName
   {
      get
      {
         return _ChkName;
      }
      set
      {
         if (this._ChkName != value)
            this._ChkName = value;
      }
   }
   
   public DateTime ChkDate
   {
      get
      {
         return _ChkDate;
      }
      set
      {
         if (this._ChkDate != value)
            this._ChkDate = value;
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

}