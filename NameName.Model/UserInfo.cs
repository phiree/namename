/***********************************************************************
 * Module:  UserInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class UserInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class UserInfo
    {
        private string _UserName;
        private string _TrueName;
        private string _Pwd;
        private string _Tel;
        private string _Mobile;
        private int _OrderNO;
        private int _RightSet;
        private Guid _DepartID;
        private bool _DeleteFlag;

        [SubSonic.SqlGeneration.Schema.SubSonicPrimaryKey]
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

        public string TrueName
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

        public string Pwd
        {
            get
            {
                return _Pwd;
            }
            set
            {
                if (this._Pwd != value)
                    this._Pwd = value;
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

        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                if (this._Mobile != value)
                    this._Mobile = value;
            }
        }

        public int OrderNO
        {
            get
            {
                return _OrderNO;
            }
            set
            {
                if (this._OrderNO != value)
                    this._OrderNO = value;
            }
        }

        public int RightSet
        {
            get
            {
                return _RightSet;
            }
            set
            {
                if (this._RightSet != value)
                    this._RightSet = value;
            }
        }

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
