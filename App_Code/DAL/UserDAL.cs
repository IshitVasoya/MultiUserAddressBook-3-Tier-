using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AddressBook.DAL
{
    public class UserDAL:DatabaseConfig
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

        public Boolean Insert(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_Insert";
                        objCmd.Parameters.AddWithValue("UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("DisplayName", entUser.DisplayName);
                        objCmd.Parameters.AddWithValue("ContactNumber", entUser.ContactNumber);
                        #endregion Prepare Command

                        #region ExecuteInsert
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteInsert
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

        #region SelectByUserNamePassword operation
        public UserENT SelectByUserNamePassword(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_SelectByUserNamePassword";
                        objCmd.Parameters.AddWithValue("UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("Password", entUser.Password);

                        #endregion Prepare Command

                        #region read data and set to controls
                        UserENT objENTUser = new UserENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["UserID"].Equals(DBNull.Value))
                                    {
                                        objENTUser.UserID = Convert.ToInt32(objSDR["UserID"]);
                                    }
                                    if (!objSDR["UserName"].Equals(DBNull.Value))
                                    {
                                        objENTUser.UserName = objSDR["UserName"].ToString();
                                    }
                                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    {
                                        objENTUser.DisplayName = objSDR["DisplayName"].ToString();
                                    }


                                }
                                return objENTUser;
                            }
                            return null;
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
        #endregion SelectByUserNamePassword operation

    }
}
