/***********************************************************************
 * Module:  Shop_TransList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_TransList
 ***********************************************************************/

using System;
namespace NameName.Model
{public class Shop_TransList
{
   private string _BillNo;
   private Guid _FromID;
   private Guid _ToID;
   private string _TransUser;
   private string _TransName;
   private DateTime _TransDate;
   private int _State;
   private string _ChkUser;
   private string _ChkName;
   private DateTime _ChkDate;
   private string _AcceptUser;
   private string _AcceptName;
   private DateTime _AcceptDate;

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
   
   public Guid FromID
   {
      get
      {
         return _FromID;
      }
      set
      {
         if (this._FromID != value)
            this._FromID = value;
      }
   }
   
   public Guid ToID
   {
      get
      {
         return _ToID;
      }
      set
      {
         if (this._ToID != value)
            this._ToID = value;
      }
   }
   
   public string TransUser
   {
      get
      {
         return _TransUser;
      }
      set
      {
         if (this._TransUser != value)
            this._TransUser = value;
      }
   }
   
   public string TransName
   {
      get
      {
         return _TransName;
      }
      set
      {
         if (this._TransName != value)
            this._TransName = value;
      }
   }
   
   public DateTime TransDate
   {
      get
      {
         return _TransDate;
      }
      set
      {
         if (this._TransDate != value)
            this._TransDate = value;
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
   
   public string AcceptUser
   {
      get
      {
         return _AcceptUser;
      }
      set
      {
         if (this._AcceptUser != value)
            this._AcceptUser = value;
      }
   }
   
   public string AcceptName
   {
      get
      {
         return _AcceptName;
      }
      set
      {
         if (this._AcceptName != value)
            this._AcceptName = value;
      }
   }
   
   public DateTime AcceptDate
   {
      get
      {
         return _AcceptDate;
      }
      set
      {
         if (this._AcceptDate != value)
            this._AcceptDate = value;
      }
   }

} }
