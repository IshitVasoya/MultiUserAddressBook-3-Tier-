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
    public class CityBAL
    {
        #region LocalVariableMessage
        protected string _Message;

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
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }

        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }

        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 CityID, SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Delete(CityID,UserID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }

        }
        #endregion DeleteOperation

        #region SelectOperation
        #region SelectALL
        public DataTable SelectALL(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll(UserID);
        }
        #endregion SelectALL

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID, SqlInt32 UserID)
        {
            CityDAL dalState = new CityDAL();
            return dalState.SelectByPK(CityID,UserID);
        }
        #endregion SelectByPK

        #region DropDownListALLCity
        public DataTable DropDownListAllCity(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.DropDownListAllCity(UserID);
        }
        #endregion DropDownListALLCity

        #region ForDropDownListCitySelectByStateID
        public DataTable DropDownListSelectByStateID(SqlInt32 StateID, SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.DropDownListSelectByStateID(StateID,UserID);
        }
        #endregion ForDropDownListCitySelectByStateID

        #endregion SelectOperation


        }
}