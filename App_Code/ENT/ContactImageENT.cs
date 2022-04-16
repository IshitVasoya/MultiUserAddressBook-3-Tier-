using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace AddressBook.ENT
{
    public class ContactImageENT
    {
        #region ContactImageID
        protected SqlInt32 _ContactImageID;

        public SqlInt32 ContactImageID
        {
            get
            {
                return _ContactImageID;
            }
            set
            {
                _ContactImageID = value;
            }
        }
        #endregion ContactImageID

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
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion UserID

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

        #region FileName
        protected SqlString _FileName;

        public SqlString FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        #endregion FileName

        #region FileSize
        protected SqlString _FileSize;

        public SqlString FileSize
        {
            get
            {
                return _FileSize;
            }
            set
            {
                _FileSize = value;
            }
        }
        #endregion FileSize

        #region Width
        protected SqlString _Width;

        public SqlString Width
        {
            get
            {
                return _Width;
            }
            set
            {
                _Width = value;
            }
        }
        #endregion Width

        #region Height
        protected SqlString _Height;

        public SqlString Height
        {
            get
            {
                return _Height;
            }
            set
            {
                _Height = value;
            }
        }
        #endregion Height

        #region Extension
        protected SqlString _Extension;

        public SqlString Extension
        {
            get
            {
                return _Extension;
            }
            set
            {
                _Extension = value;
            }
        }
        #endregion Extension
    }
}
