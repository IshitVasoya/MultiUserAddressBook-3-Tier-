using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


namespace AddressBook.ENT
{
    public class StateENT
    {

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

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region CountryID

        protected SqlInt32 _CountryID;

        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }
        #endregion CountryID

        #region StateName

        protected SqlString _StateName;

        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
        #endregion StateName

        #region StateCode

        protected SqlString _StateCode;

        public SqlString StateCode
        {
            get
            {
                return _StateCode;
            }
            set
            {
                _StateCode = value;
            }
        }
        #endregion StateCode
    }
}
