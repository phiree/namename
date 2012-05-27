/***********************************************************************
 * Module:  ProInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{public class ProInfo
{
   private Guid _ProID;
   private string _ProCate;
   private string _Name;
   private string _Unit;
   private string _PicName;
   private string _Memo;
   private bool _DeleteFlag;

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
   
   public string ProCate
   {
      get
      {
         return _ProCate;
      }
      set
      {
         if (this._ProCate != value)
            this._ProCate = value;
      }
   }
   
   public string Name
   {
      get
      {
         return _Name;
      }
      set
      {
         if (this._Name != value)
            this._Name = value;
      }
   }
   
   public string Unit
   {
      get
      {
         return _Unit;
      }
      set
      {
         if (this._Unit != value)
            this._Unit = value;
      }
   }
   
   public string PicName
   {
      get
      {
         return _PicName;
      }
      set
      {
         if (this._PicName != value)
            this._PicName = value;
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
   
   public bool DeleteFlag
   {
      get
      {
         return _DeleteFlag;
      }
      set
      {
         if (this._DeleteFlag != value)
            this._DeleteFlag = value;
      }
   }

} }
