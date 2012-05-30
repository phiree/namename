/***********************************************************************
 * Module:  DepartInfo.cs
 * Author:  Administrator
 * Purpose: Definition of the Class DepartInfo
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class DepartInfo
    {
        private Guid _DepartID;
        private int _OrderNO;
        private string _DepartName;
        private bool _DeleteFlag;

        [SubSonic.SqlGeneration.Schema.SubSonicPrimaryKey]
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
}
