using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


public class ContactENT
{
    #region ContactID

    protected SqlInt32 _ContactID;

    public SqlInt32 ContactID
    {
        get
        {
            return _ContactID;
        }
        set
        {
            _ContactID = value;
        }
    }
    #endregion ContactID

    #region UserID
    protected SqlInt32 _UserID;

    public SqlInt32 UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    #endregion UserID

    #region CountryID

    protected SqlInt32 _CountryID;

    public SqlInt32 CountryID
    {
        get
        {
            return _CountryID;
        }
        set
        {
            _CountryID = value;
        }
    }
    #endregion CountryID

    #region StateID

    protected SqlInt32 _StateID;

    public SqlInt32 StateID
    {
        get
        {
            return _StateID;
        }
        set
        {
            _StateID = value;
        }
    }
    #endregion StateID

    #region CityID

    protected SqlInt32 _CityID;

    public SqlInt32 CityID
    {
        get
        {
            return _CityID;
        }
        set
        {
            _CityID = value;
        }
    }
    #endregion CityID

    //#region ContactCategoryID

    //protected SqlInt32 _ContactCategoryID;

    //public SqlInt32 ContactCategoryID
    //{
    //    get
    //    {
    //        return _ContactCategoryID;
    //    }
    //    set
    //    {
    //        _ContactCategoryID = value;
    //    }
    //}
    //#endregion ContactCategoryID

    #region ContactName

    protected SqlString _ContactName;

    public SqlString ContactName
    {
        get
        {
            return _ContactName;
        }
        set
        {
            _ContactName = value;
        }
    }
    #endregion ContactName

    #region ContactNumber

    protected SqlString _ContactNumber;

    public SqlString ContactNumber
    {
        get
        {
            return _ContactNumber;
        }
        set
        {
            _ContactNumber = value;
        }
    }

    #endregion ContactNumber

    #region WhatsappNumber

    protected SqlString _WhatsappNumber;

    public SqlString WhatsappNumber
    {
        get
        {
            return _WhatsappNumber;
        }
        set
        {
            _WhatsappNumber = value;
        }
    }
    #endregion WhatsappNumber

    #region BirthDate

    protected SqlString _BirthDate;

    public SqlString BirthDate
    {
        get
        {
            return _BirthDate;
        }
        set
        {
            _BirthDate = value;
        }
    }
    #endregion BirthDate

    #region Email

    protected SqlString _Email;

    public SqlString Email
    {
        get
        {
            return _Email;
        }
        set
        {
            _Email = value;
        }
    }
    #endregion Email

    #region Age

    protected SqlInt32 _Age;

    public SqlInt32 Age
    {
        get
        {
            return _Age;
        }
        set
        {
            _Age = value;
        }
    }
    #endregion Age

    #region Address

    protected SqlString _Address;

    public SqlString Address
    {
        get
        {
            return _Address;
        }
        set
        {
            _Address = value;
        }
    }
    #endregion Address

    #region BloodGroup

    protected SqlString _BloodGroup;

    public SqlString BloodGroup
    {
        get
        {
            return _BloodGroup;
        }
        set
        {
            _BloodGroup = value;
        }
    }
    #endregion BloodGroup

    #region FacebookID

    protected SqlString _FacebookID;

    public SqlString FacebookID
    {
        get
        {
            return _FacebookID;
        }
        set
        {
            _FacebookID = value;
        }
    }
    #endregion FacebookID

    #region LinkedinID

    protected SqlString _LinkedinID;

    public SqlString LinkedinID
    {
        get
        {
            return _LinkedinID;
        }
        set
        {
            _LinkedinID = value;
        }
    }
    #endregion LinkedinID

    #region ContactImageFilePath

    protected SqlString _ContactImageFilePath;

    public SqlString ContactImageFilePath
    {
        get
        {
            return _ContactImageFilePath;
        }
        set
        {
            _ContactImageFilePath = value;
        }
    }
    #endregion ContactImageFilePath


}