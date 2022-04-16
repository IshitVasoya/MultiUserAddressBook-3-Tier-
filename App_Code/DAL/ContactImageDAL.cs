using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.DAL
{
    public class ContactImageDAL : DatabaseConfig
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
        public bool Insert(ContactImageENT entContactImage)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactImage_Insert";
                        objCmd.Parameters.AddWithValue("ContactID", entContactImage.ContactID);
                        objCmd.Parameters.AddWithValue("ContactImageFilePath", entContactImage.ContactImageFilePath);
                        objCmd.Parameters.AddWithValue("UserID", entContactImage.UserID);
                        objCmd.Parameters.AddWithValue("FileName", entContactImage.FileName);
                        objCmd.Parameters.AddWithValue("FileSize", entContactImage.FileSize);
                        objCmd.Parameters.AddWithValue("Width", entContactImage.Width);
                        objCmd.Parameters.AddWithValue("Height", entContactImage.Height);
                        objCmd.Parameters.AddWithValue("Extension", entContactImage.Extension);
                        #endregion prepare Command

                        #region Execute Insert

                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion Execute Insert
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


        #region UpdateOperation
        public bool Update(ContactImageENT entContactImage)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region prepare Command
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactImage_UpdateByContactID";
                        objCmd.Parameters.AddWithValue("ContactID", entContactImage.ContactID);
                        objCmd.Parameters.AddWithValue("ContactImageFilePath", entContactImage.ContactImageFilePath);
                        objCmd.Parameters.AddWithValue("UserID", entContactImage.UserID);
                        objCmd.Parameters.AddWithValue("FileName", entContactImage.FileName);
                        objCmd.Parameters.AddWithValue("FileSize", entContactImage.FileSize);
                        objCmd.Parameters.AddWithValue("Width", entContactImage.Width);
                        objCmd.Parameters.AddWithValue("Height", entContactImage.Height);
                        objCmd.Parameters.AddWithValue("Extension", entContactImage.Extension);
                        #endregion prepare Command

                        #region Execute Insert

                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion Execute Insert
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
        #endregion UpdateOperation

        #region DeleteOperation
        public Boolean Delete(SqlInt32 ContactID , SqlInt32 UserID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactImage_DeleteByContactID";
                        objCmd.Parameters.AddWithValue("ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion Prepare Command

                        #region ExecuteDelete
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteDelete
                    }
                    catch(Exception ex)
                    {
                        Message=ex.Message;
                        return false;
                    }
                    finally { objConn.Close(); }    
                }
            }
        }
        #endregion DeleteOperation

        #region ContactImageFilePathSelectByContactID

        public SqlString ContactImageFilePathSelectByContactID(SqlInt32 ContactID)
        {
            using(SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using(SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command

                        objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_ContactImage_FilePathSelectByContactID";
                        objCmd.Parameters.AddWithValue("ContactID", ContactID);
                        #endregion Prepare Command

                        #region read data and set to controls
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                if (objSDR.Read())
                                {
                                    if (!objSDR["ContactImageFilePath"].Equals(DBNull.Value))
                                        return objSDR["ContactImageFilePath"].ToString();
                                }
                            }
                            return null ;
                        }
                        #endregion read data and set to controls
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
        #endregion ContactImageFilePathSelectByContactID
    }
}
