/***********************************************************************
 * Module:  ShopInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class ShopInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class ShopInfo
    {
        private Guid _ShopID;
        private string _ShopNo;
        private Guid _AreaID;
        private string _ShopName;
        private string _Address;
        private string _Tel;
        private string _Fax;
        private bool _DeleteFlag;
        private bool _IsCenter;

        [SubSonic.SqlGeneration.Schema.SubSonicPrimaryKey]
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

        public string ShopNo
        {
            get
            {
                return _ShopNo;
            }
            set
            {
                if (this._ShopNo != value)
                    this._ShopNo = value;
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

        public string ShopName
        {
            get
            {
                return _ShopName;
            }
            set
            {
                if (this._ShopName != value)
                    this._ShopName = value;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (this._Address != value)
                    this._Address = value;
            }
        }

        public string Tel
        {
            get
            {
                return _Tel;
            }
            set
            {
                if (this._Tel != value)
                    this._Tel = value;
            }
        }

        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                if (this._Fax != value)
                    this._Fax = value;
            }
        }

        public bool IsCenter
        {
            get
            {
                return _IsCenter;
            }
            set
            {
                if (this._IsCenter != value)
                    this._IsCenter = value;
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
}
