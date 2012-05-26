/***********************************************************************
 * Module:  DepartInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class DepartInfo
 ***********************************************************************/

using System;

public class DepartInfo
{
   private Guid _DepartID;
   private string _DepartName;
   private bool _DeleteFlag;

   public Guid DepartID
   {
      get
      {
         return _DepartID;
      }
      set
      {
         if (this._DepartID != value)
            this._DepartID = value;
      }
   }
   
   public string DepartName
   {
      get
      {
         return _DepartName;
      }
      set
      {
         if (this._DepartName != value)
            this._DepartName = value;
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

}