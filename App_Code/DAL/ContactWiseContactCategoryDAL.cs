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
    public class ContactWiseContactCategoryDAL:DatabaseConfig
    {
        #region LocalVariableMessage
        protected String _Message;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #endregion LocalVariableMessage

        #region InsertOperation
        public Boolean Insert(ContactWiseContactCategoryENT entContactWiseContactCategory)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactWiseContactCategory_Insert";
                        objCmd.Parameters.AddWithValue("ContactID", entContactWiseContactCategory.ContactID);
                        objCmd.Parameters.AddWithValue("ContactCategoryID", entContactWiseContactCategory.ContactCategoryID);

                        #endregion PrepareCommand

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
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

        #region DeleteOperation
        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactWiseContactCategory_DeleteByContactID";
                        objCmd.Parameters.AddWithValue("ContactID",ContactID);
                        

                        #endregion PrepareCommand

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
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

        #region SelectByContactID
        public DataTable SelectByContactID(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region PrepareCommand
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactWiseContactCategory_SelectByContactID";
                        objCmd.Parameters.AddWithValue("ContactID", ContactID);
                        #endregion PrepareCommand
                        DataTable dt = new DataTable();
                        using(SqlDataReader ObjSDR = objCmd.ExecuteReader())
                        {
                             dt.Load(ObjSDR);
                            return dt;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByContactID
    }
}
