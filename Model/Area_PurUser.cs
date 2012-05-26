/***********************************************************************
 * Module:  Area_PurUser.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Area_PurUser
 ***********************************************************************/

using System;

public class Area_PurUser
{
   private int _Id;
   private Guid _AreaID;
   private string _UserName;

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

}