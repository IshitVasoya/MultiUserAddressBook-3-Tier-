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

    public class ContactCategoryDAL:DatabaseConfig
    {
        #region LocalVariable

        protected String _Message;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion LocalVariable

        #region InsertOperation
        public Boolean Insert(ContactCategoryENT entContactCategory )
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open(); 
                using(SqlCommand objCmd =objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_Insert";
                        objCmd.Parameters.AddWithValue("ContactCategoryName", entContactCategory.ContactCategoryName);
                        objCmd.Parameters.AddWithValue("UserID", entContactCategory.UserID);

                        #endregion prepare Command

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
                        objConn.Close();
                    }
                }
            }
        }
        #endregion InsertOperation

        #region updateOperation
        public Boolean Update(ContactCategoryENT entContactCategory)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_UpdateByPK";
                        objCmd.Parameters.AddWithValue("ContactCategoryID", entContactCategory.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("ContactCategoryName", entContactCategory.ContactCategoryName);
                        objCmd.Parameters.AddWithValue("UserID", entContactCategory.UserID);

                        #endregion prepare Command

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
                        objConn.Close();
                    }
                }
            }
        }
        #endregion updateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                try
                {
                    using (SqlCommand objCmd = objConn.CreateCommand())
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_DeleteByPK";
                        objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion PrepareCommand

                        #region ExecuteDelete
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteDelete
                    }
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    return false;
                }
                finally
                {
                    objConn.Close();
                }
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectAll(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_ContactCategory_SelectAll";
                        objCmd.Parameters.AddWithValue("UserID", UserID);

                        #endregion PrepareCommand

                        #region read data And Set to Controls
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion read data And Set to Controls
                    }
                    catch (Exception e)
                    {
                        Message=e.InnerException.Message;
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
        public ContactCategoryENT SelectByPK(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_SelectByPK";
                        objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);

                        #endregion PrepareCommand

                        #region read data And Set to Controls
                        ContactCategoryENT entContactCategory = new ContactCategoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                                    entContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString();
                            }
                        }
                        return entContactCategory;
                        
                        #endregion read data And Set to Controls
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
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

        #region ForDropDownListAll
        public DataTable DropDownListAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactCategory_ForDropDownList";
                        objCmd.Parameters.AddWithValue("UserID", UserID);

                        #endregion PrepareCommand

                        #region read data And Set to Controls
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion read data And Set to Controls
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
        #endregion ForDropDownListAll

        #endregion SelectOperation


    }
}
