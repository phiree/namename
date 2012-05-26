/***********************************************************************
 * Module:  ProPrice.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ProPrice
 ***********************************************************************/

using System;

public class ProPrice
{
   private int _Id;
   private Guid _AreaID;
   private Guid _ProID;
   private Decimal _Price;

   public int Id
   {
      get
      {
         return _Id;
      }
      set
      {
         if (this._Id != value)
            this._Id = value;
      }
   }
   
   public Guid AreaID
   {
      get
      {
         return _AreaID;
      }
      set
      {
         if (this._AreaID != value)
            this._AreaID = value;
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
   
   public Decimal Price
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