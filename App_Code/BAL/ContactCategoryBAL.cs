using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.BAL
{

    public class ContactCategoryBAL
    {
        #region LocalVariableMessage
        protected String _Message;

        public String Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion LocalVariableMessage

        #region InsertOperation
        public Boolean Insert(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();

            if (dalContactCategory.Insert(entContactCategory))
                return true;
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Update(entContactCategory))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Delete(ContactCategoryID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectALL(SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectAll(UserID);
        }
        #endregion SelectALL

        #region SelectByPK
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectByPK(ContactCategoryID,UserID);
        }
        #endregion SelectByPK

        #region ForDropDownList
        public DataTable DropDownListAll(SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.DropDownListAll(UserID);
        }
        #endregion ForDropDownList
        #endregion SelectOperation
    }
}