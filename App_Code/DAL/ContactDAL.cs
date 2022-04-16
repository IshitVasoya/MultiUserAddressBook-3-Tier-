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
    public class ContactDAL:DatabaseConfig
    {
        #region LocalVariable Message
        protected String _Message;

        public String Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion LocalVariable Message

        //#region OutputContactID
        //protected SqlInt32 _ContactID;

        //public SqlInt32 ContactID
        //{
        //    get { return _ContactID; }
        //    set { _ContactID = value; }
        //}
        //#endregion OutputContactID

        #region InsertOperation
        public Boolean Insert(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_Insert";

                        objCmd.Parameters.Add("ContactID",SqlDbType.Int,4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("CityID", entContact.CityID);
                        //objCmd.Parameters.AddWithValue("ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("Contactname", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("ContactNumber", entContact.ContactNumber);
                        objCmd.Parameters.AddWithValue("WhatsappNumber", entContact.WhatsappNumber);
                        objCmd.Parameters.AddWithValue("BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("facebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("LinkedINID", entContact.LinkedinID);

                        #endregion PrepareCommand

                        #region ExecuteInsert
                        objCmd.ExecuteNonQuery();

                        if (objCmd.Parameters["ContactID"] != null)
                        {
                            //ContactID = Convert.ToInt32(objCmd.Parameters["ContactID"].Value);
                            entContact.ContactID = Convert.ToInt32(objCmd.Parameters["ContactID"].Value);
                        }
                        return true;
                        #endregion ExecuteInsert
                    }
                    catch (Exception e)
                    {
                        Message=e.Message;
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
        public Boolean Update(ContactENT entContact)
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
                        objCmd.CommandText = "PR_Contact_UpdateByPK";

                        objCmd.Parameters.AddWithValue("ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("UserID", entContact.UserID);
                        objCmd.Parameters.AddWithValue("CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("CityID", entContact.CityID);
                        //objCmd.Parameters.AddWithValue("ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.AddWithValue("Contactname", entContact.ContactName);
                        objCmd.Parameters.AddWithValue("ContactNumber", entContact.ContactNumber);
                        objCmd.Parameters.AddWithValue("WhatsappNumber", entContact.WhatsappNumber);
                        objCmd.Parameters.AddWithValue("BirthDate", entContact.BirthDate);
                        objCmd.Parameters.AddWithValue("Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("Age", entContact.Age);
                        objCmd.Parameters.AddWithValue("Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("facebookID", entContact.FacebookID);
                        objCmd.Parameters.AddWithValue("BloodGroup", entContact.BloodGroup);
                        objCmd.Parameters.AddWithValue("LinkedINID", entContact.LinkedinID);

                        #endregion PrepareCommand

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
                        #region PrepareCommand
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPK";
                        objCmd.Parameters.AddWithValue("ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion PrepareCommand

                        #region ExecuteDelete
                        objCmd.ExecuteNonQuery();
                        return true;
                        #endregion ExecuteDelete
                    }
                    catch (Exception e)
                    {
                        Message=e.Message;
                        return false;
                    }
                    finally { objConn.Close(); }
                }
            }
        }
        #endregion DeleteOperation

        #region SelectOperation

        #region SelectALL
        public DataTable SelectALL(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Contact_SelectALL";
                        objCmd.Parameters.AddWithValue("UserID", UserID);
                        #endregion PrepareCommand

                        #region read data and set to controls
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion read data and set to controls
                    }
                    catch (Exception e)
                    {
                        Message = e.InnerException.Message;
                        return null;    
                    }
                    finally { objConn.Close(); }
                }
            }
        }
        #endregion SelectALL

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID , SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("ContactID", ContactID);
                        objCmd.Parameters.AddWithValue("UserID",UserID);
                        #endregion PrepareCommand

                        #region read the Data and Set to Controls
                        ContactENT entContact = new ContactENT();
                        using(SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ContactID"].Equals(DBNull.Value))
                                    entContact.ContactID = Convert.ToInt32(objSDR["ContactID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID  = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID  = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                                //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                //    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);

                                if (!objSDR["ContactName"].Equals(DBNull.Value))
                                    entContact.ContactName = objSDR["ContactName"].ToString();

                                if (!objSDR["ContactNumber"].Equals(DBNull.Value))
                                    entContact.ContactNumber = objSDR["ContactNumber"].ToString();

                                if (!objSDR["WhatsappNumber"].Equals(DBNull.Value))
                                    entContact.WhatsappNumber = objSDR["WhatsappNumber"].ToString();

                                if (!objSDR["BirthDate"].Equals(DBNull.Value))
                                    entContact.BirthDate = objSDR["BirthDate"].ToString();

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = objSDR["Email"].ToString();

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = objSDR["Address"].ToString();

                                if (!objSDR["Age"].Equals(DBNull.Value))
                                    entContact.Age = Convert.ToInt32(objSDR["Age"]);

                                if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                                    entContact.BloodGroup = objSDR["BloodGroup"].ToString();

                                if (!objSDR["FacebookID"].Equals(DBNull.Value))
                                    entContact.FacebookID = objSDR["FacebookID"].ToString();

                                if (!objSDR["LinkedinID"].Equals(DBNull.Value))
                                    entContact.LinkedinID = objSDR["LinkedinID"].ToString();

                                if (!objSDR["ContactImageFilePath"].Equals(DBNull.Value))
                                    entContact.ContactImageFilePath = objSDR["ContactImageFilePath"].ToString();
                            }
                        }
                        return entContact;
                        #endregion read the Data and Set to Controls
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


        #endregion SelectOperation
    }
}
