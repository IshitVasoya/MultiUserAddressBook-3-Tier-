using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.BAL
{
    public class ContactWiseContactCategoryBAL
    {
        #region LocalVariableMessage
        protected String _Message;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #endregion LocalVariableMessage

        #region InsertOperation
        public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if (dalContactWiseContactCategory.Insert(entContactWiseContactCategory))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion InsertOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if (dalContactWiseContactCategory.Delete(ContactID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectByContactID
        public DataTable SelectByContactID(SqlInt32 ContactID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            return dalContactWiseContactCategory.SelectByContactID(ContactID);
        }
        #endregion SelectByContactID
    }
}
