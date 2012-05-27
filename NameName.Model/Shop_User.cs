/***********************************************************************
 * Module:  Shop_User.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_User
 ***********************************************************************/

using System;
namespace NameName.Model
{ public class Shop_User
{
   private int _ID;
   private Guid _ShopID;
   private string _UserName;
   private bool _IsManager;

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
   
   public bool IsManager
   {
      get
      {
         return _IsManager;
      }
      set
      {
         if (this._IsManager != value)
            this._IsManager = value;
      }
   }

}}
