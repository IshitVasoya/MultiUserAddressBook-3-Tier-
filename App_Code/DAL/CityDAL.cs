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
    public class CityDAL:DatabaseConfig
    {

        #region Local Variable Message

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
        #endregion Local Variable Message

        #region InsertOperation

        public Boolean Insert(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_Insert";
                        objCmd.Parameters.AddWithValue("StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("UserID", entCity.UserID);
                        objCmd.Parameters.AddWithValue("CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("PinCode", entCity.PinCode);
                        #endregion Prepare Command

                        #region InsertExecute
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion InsertExecute
                    }
                    catch (Exception e)
                    {
                        Message = e.InnerException.Message;
                        return false;
                    }
                    finally 
                    { 
                        objConn.Close();
                    }
                }
            }
        }
        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(CityENT entCity)
        {
            using( SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare COmmand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_UpdateByPK";
                        objCmd.Parameters.AddWithValue("CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("UserID", entCity.UserID);
                        objCmd.Parameters.AddWithValue("CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("PinCode", entCity.PinCode);
                        #endregion Prepare COmmand

                        #region ExecuteUpdate
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteUpdate
                    }
                    catch (Exception e)
                    {
                        Message=e.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 CityID ,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using( SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_DeletByPK";
                        objCmd.Parameters.AddWithValue("CityID", CityID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);

                        #endregion Prepare Command

                        #region ExecuteDelete
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteDelete
                    }
                    catch(Exception e)
                    {
                        Message= e.Message;
                        return false;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using( SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_SelectAll";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Get Values And Set to Controls
                        DataTable dt =new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Get Values And Set to Controls
                    }
                    catch(Exception e)
                    {
                        Message= e.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        objConn.Close();
                    }


                }
            }
        }
        #endregion SelectALL

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("CityID", CityID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Get Values And Set to Controls
                        CityENT entCity = new CityENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entCity.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName = objSDR["CityName"].ToString();

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    entCity.STDCode = objSDR["STDCode"].ToString();

                                if (!objSDR["PinCode"].Equals(DBNull.Value))
                                    entCity.PinCode = objSDR["PinCode"].ToString();

                            }
                            
                        }

                        return entCity;
                        #endregion Get Values And Set to Controls
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
        #endregion SelectByPK

        #region ForDropDownListAllCity
        public DataTable DropDownListAllCity(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_City_ForDropDownList";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Get Values And Set to Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Get Values And Set to Controls
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
        #endregion ForDropDownListAllCity

        #region ForDropDownListCitySelectByStateID
        public DataTable DropDownListSelectByStateID(SqlInt32 StateID,SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_City_SelectByStateID";
                        objCmd.Parameters.AddWithValue("StateID", StateID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Get Values And Set to Controls
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Get Values And Set to Controls
                    }
                    catch(Exception e)
                    {
                        Message=e.Message;
                        return null;
                    }
                    finally 
                    { 
                        objConn.Close(); 
                    }



                }
            }
        }
        #endregion ForDropDownListCitySelectByStateID
        #endregion SelectOperation
    }
}
