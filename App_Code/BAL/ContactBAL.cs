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
    public class ContactBAL
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

        //#region OutputContactID
        //protected SqlInt32 _ContactID;

        //public SqlInt32 ContactID
        //{
        //    get { return _ContactID; }
        //    set { _ContactID = value; }
        //}
        //#endregion OutputContactID

        #region InsertOperation
        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Insert(entContact))
            {
                //ContactID = dalContact.ContactID;
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 CountryID,SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Delete(CountryID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectALL(SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectALL(UserID);
        }
        #endregion SelectALL

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID,UserID);
        }
        #endregion SelectByPK

        
        #endregion SelectOperation
    }
}