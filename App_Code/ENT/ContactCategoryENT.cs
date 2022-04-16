using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


namespace AddressBook.ENT
{
    public class ContactCategoryENT
    {
        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;

        public SqlInt32 ContactCategoryID
        {
            get
            {
                return _ContactCategoryID;
            }
            set
            {
                _ContactCategoryID = value;
            }
        }
        #endregion ContactCategoryID

        #region UserID
        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region ContactCategoryName
        protected SqlString _ContactCategoryName;

        public SqlString ContactCategoryName
        {
            get
            {
                return _ContactCategoryName;
            }
            set
            {
                _ContactCategoryName = value;
            }
        }
        #endregion ContactCategoryName
    }
}