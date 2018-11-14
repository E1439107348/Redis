using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOne.IRepository.System;
using TheOne.IServices.System;
using TheOne.Model.DataModel;

namespace TheOne.Services.System
{
   public class UserType_Services:BaseServices<UserType>, IUserType_Services
    {
        IUserType_DAL dalSer;
        public UserType_Services(IUserType_DAL dalSer)
        {
            base.dal = dalSer;
            this.dalSer = dalSer;
        }
    }
}
