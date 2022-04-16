using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.DAL
{
    public class StateDAL:DatabaseConfig
    {
        #region Message

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
        #endregion Message

        #region InsertOperation
        public Boolean Insert(StateENT entState)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try{
                        #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_State_Insert";
                    objCmd.Parameters.AddWithValue("UserID", entState.UserID );
                    objCmd.Parameters.AddWithValue("CountryID", entState.CountryID);
                    objCmd.Parameters.AddWithValue("StateName", entState.StateName);
                    objCmd.Parameters.AddWithValue("StateCode", entState.StateCode);
                    #endregion Prepare Command

                    #region ExecuteInsert
                    objCmd.ExecuteNonQuery();
                    return true;
                    #endregion ExecuteInsert
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
                
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(StateENT entState)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_UpdateByPK";
                        objCmd.Parameters.AddWithValue("StateID", entState.StateID);
                        objCmd.Parameters.AddWithValue("UserID", entState.UserID);
                        objCmd.Parameters.AddWithValue("CountryID", entState.CountryID);
                        objCmd.Parameters.AddWithValue("StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("StateCode", entState.StateCode);
                        #endregion Prepare Command

                        #region ExecuteUpdate
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteUpdate
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }

            }
        }
        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 StateID , SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_DeleteByPK";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        objCmd.Parameters.AddWithValue("StateID", StateID);
                        #endregion PrepareCommand

                        #region ExecuteDelete
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteDelete
                    }
                    catch(Exception e)
                    {
                        Message = e.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectAll";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Read Data and set to Control
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data and set to Control
                    }
                    catch(Exception e)
                    {
                        Message = e.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectAll

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("StateID", StateID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion PrepareCommand

                        #region Read the Data and Set to Controls
                        StateENT entState = new StateENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entState.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                    entState.StateName = objSDR["StateName"].ToString();

                                if (!objSDR["StateCode"].Equals(DBNull.Value))
                                    entState.StateCode = objSDR["StateCode"].ToString();
                            }
                        }
                        return entState;
                        #endregion Read the Data and Set to Controls
                    }
                    catch(Exception e)
                    {
                        Message = e.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByPK

        //AllState DropDown
        #region ForDropdownList 
        public DataTable DropDownListAllState(SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open(); 
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_ForDropDownList";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Execute command and return Datatable
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Execute command and return Datatable

                    }
                    catch (Exception e)
                    {
                        Message=e.Message;
                        return null ;
                    }
                    finally 
                    { 
                        objConn.Close(); 
                    }
                }
            }
        }
        #endregion ForDropdownList

        //State SelectByCountry DropDown
        #region StateSelectByCountryID
        public DataTable DropDownListStateSelectByCountryID(SqlInt32 CountryID,SqlInt32 UserID)
        {
            
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    objConn.Open();
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                    try
                    {
                        #region Prepare COmmand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_SelectByCountryID";
                        objCmd.Parameters.AddWithValue("CountryID", CountryID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare COmmand

                        #region ExecuteCpmmand And Return Data Table
                        DataTable dt = new DataTable();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion ExecuteCpmmand And Return Data Table
                    }
                    catch (Exception e)
                    {
                        Message = e.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
                }
            
            
        }
        #endregion StateSelectByCountryID


        #endregion SelectOperation
    }
}

