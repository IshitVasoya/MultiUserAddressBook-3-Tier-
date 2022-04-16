using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.ENT
{
    public class UserENT
    {
        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion UserID

        #region UserName
        protected SqlString _UserName;

        public SqlString UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion UserName

        #region Password
        protected SqlString _Password;
        public SqlString Password
        {
            get { return _Password; }   
            set { _Password = value; }
        }
        #endregion Password

        #region DisplayName
        protected SqlString _DisplayName;

        public SqlString DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                _DisplayName = value;
            }
        }
        #endregion DisplayName

        #region ContactNumber
        protected SqlString _ContactNumber;

        public SqlString ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                _ContactNumber = value;
            }
        }
        #endregion ContactNumber


    }
}
