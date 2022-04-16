using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.BAL
{
    public class UserBAL
    {
        #region LocalVariableMessage
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
        #endregion LocalVariableMessage

        #region InsertOperation

        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;   
            }
        }

        #endregion InsertOperation

        #region SelectByUsernamePassword operation

        public UserENT SelectByUserNamePassword(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();
            UserENT objENTUser= new UserENT();

            objENTUser= dalUser.SelectByUserNamePassword(entUser);
            return objENTUser;
        }
        #endregion SelectByUsernamePassword operation
    }
}
