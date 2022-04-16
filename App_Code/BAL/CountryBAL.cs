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
    public class CountryBAL
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
        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Insert(entCountry))
                return true;
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false ;
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            if (dalCountry.Delete(CountryID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectALL(SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll(UserID);
        }
        #endregion SelectALL

        #region SelectByPK
        public CountryENT SelectByPK(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID, UserID);
        }
        #endregion SelectByPK

        #region ForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropdownList(UserID);
        }
        #endregion ForDropDownList
        #endregion SelectOperation
    }
}
