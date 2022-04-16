using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.ENT
{
    public class CityENT
    {
        #region CityID

        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion CityID

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region StateID

        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        #endregion StateID

        #region CityName
        protected SqlString _CityName;

        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }
        #endregion CityName

        #region STDCode
        protected SqlString _STDCode;

        public SqlString STDCode
        {
            get
            {
                return _STDCode;
            }
            set
            {
                _STDCode = value;
            }
        }
        #endregion STDCode

        #region PinCode
        protected SqlString _PinCode;

        public SqlString PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }
        #endregion PinCode
    }
}