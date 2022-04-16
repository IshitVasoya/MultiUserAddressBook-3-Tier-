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
    public class CountryDAL : DatabaseConfig
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
        public Boolean Insert(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_Insert";
                        objCmd.Parameters.AddWithValue("UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("CountryCode", entCountry.CountryCode);
                        #endregion Prepare Command

                        #region ExecuteInsert
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteInsert

                    }
                    catch (Exception e)
                    {
                        Message = e.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State != ConnectionState.Closed)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }

        #endregion InsertOperation

        #region UpdateOperation
        public Boolean Update(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPK";

                        objCmd.Parameters.AddWithValue("CountryID", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("UserID", entCountry.UserID);
                        objCmd.Parameters.AddWithValue("CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("CountryCode", entCountry.CountryCode);
                        #endregion Prepare Command

                        #region Execute Update
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion Execute Update
                    }
                    catch (Exception e)
                    {
                        Message = e.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State != ConnectionState.Closed)
                        {
                            objConn.Close();
                        }
                    }

                }
            }
        }
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 CountryID , SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_DeleteByPK";
                        objCmd.Parameters.AddWithValue("CountryID", CountryID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region Execute Command
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion Execute Command
                    }
                    catch(Exception e)
                    {
                        Message = e.Message;
                        return false;
                    }
                    finally
                    {
                        if(objConn.State!=ConnectionState.Closed)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectAllOperation
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region PrepareCommand

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectAll";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion prepareCommand

                        #region Read Data And Set to Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data And Set to Controls

                    }
                    catch(Exception e)
                    {
                        _Message = e.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State != ConnectionState.Closed)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectAllOperation

        #region SelectByPkOperation


        public CountryENT SelectByPK(SqlInt32 CountryID, SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("CountryID", CountryID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion PrepareCommand

                        #region Read Data And Set to Controls

                        CountryENT entCountry = new CountryENT();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while(objSDR.Read())
                            {
                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCountry.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    entCountry.CountryName = objSDR["CountryName"].ToString();

                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    entCountry.CountryCode = objSDR["CountryCode"].ToString();

                            }
                            return entCountry;
                        }
                        #endregion Read Data And Set to Controls
                    }
                    catch(Exception e)
                    {
                        _Message = e.InnerException.Message;
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
        #endregion SelectByPkOperation

        #region ForDropDownList
        public DataTable SelectForDropdownList(SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {


                        #region Prepare Command

                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_ForDropDownList";
                        objCmd.Parameters.AddWithValue("UserID", UserID);

                        #endregion Prepare Command

                        #region Read Data And Set to Controls

                        DataTable dt = new DataTable();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data And Set to Controls
                    }
                    catch (Exception e)
                    {
                        _Message = e.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State != ConnectionState.Closed)
                            objConn.Close();
                    }

                }
            }
        }
        #endregion ForDropDownList
        #endregion SelectOperation



    }

}