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
    public class StateBAL
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
        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if(dalState.Insert(entState))
                return true;
            else
            {
                Message = dalState.Message;
                return false;   
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();
            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;

            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 StateID,SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            if(dalState.Delete(StateID,UserID))
            {
                return true;
            }
            else
            {
                Message= dalState.Message;
                return false;
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID,UserID);
        }
        #endregion SelectByPK

        #region DropDownListALLState
        public DataTable DropDownListAllState(SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.DropDownListAllState(UserID);
        }
        #endregion DropDownListALLState

        #region DropDownListStateSelectByCountryID
        public DataTable DropDownListStateSelectByCountryID(SqlInt32 CountryID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.DropDownListStateSelectByCountryID(CountryID,UserID);
        }
        #endregion DropDownListStateSelectByCountryID
        #endregion SelectOperation
    }
}
