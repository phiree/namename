/***********************************************************************
 * Module:  Shop_SellDetail.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_SellDetail
 ***********************************************************************/

using System;

public class Shop_SellDetail
{
   private int _ID;
   private string _BillNO;
   private Guid _产品id;
   private string _单位;
   private decimal _数量;
   private decimal _单价;

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
   
   public Guid 产品id
   {
      get
      {
         return _产品id;
      }
      set
      {
         if (this._产品id != value)
            this._产品id = value;
      }
   }
   
   public string 单位
   {
      get
      {
         return _单位;
      }
      set
      {
         if (this._单位 != value)
            this._单位 = value;
      }
   }
   
   public decimal 数量
   {
      get
      {
         return _数量;
      }
      set
      {
         if (this._数量 != value)
            this._数量 = value;
      }
   }
   
   public decimal 单价
   {
      get
      {
         return _单价;
      }
      set
      {
         if (this._单价 != value)
            this._单价 = value;
      }
   }

}