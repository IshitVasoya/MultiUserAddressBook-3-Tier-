using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.BAL
{
    public class ContactImageBAL
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
        public Boolean Insert(ContactImageENT entContactImage)
        {
            ContactImageDAL dalContactImage = new ContactImageDAL();
            if (dalContactImage.Insert(entContactImage))
            {
                return true;
            }
            else
            {
                Message = dalContactImage.Message;
                return false;   
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(ContactImageENT entContactImage)
        {
            ContactImageDAL dalContactImage = new ContactImageDAL();
            if (dalContactImage.Update(entContactImage))
            {
                return true;
            }
            else
            {
                Message = dalContactImage.Message;
                return false;
            }
        }
        #endregion UpdateOperation

        #region DeleteOpertion
        public Boolean Delete(SqlInt32 ContactID , SqlInt32 UserID)
        {
            ContactImageDAL dalContactImage = new ContactImageDAL();
            if (dalContactImage.Delete(ContactID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactImage.Message;
                return false;
            }
        }
        #endregion DeleteOpertion

        #region ContactImageFilePathSelectByContactID

        public SqlString ContactImageFilePathSelectByContactID(SqlInt32 ContactID)
        {
            ContactImageDAL dalContactImage = new ContactImageDAL();
            return dalContactImage.ContactImageFilePathSelectByContactID(ContactID);
        }

        #endregion ContactImageFilePathSelectByContactID
    }
}
