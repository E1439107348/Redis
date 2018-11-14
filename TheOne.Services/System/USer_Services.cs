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
    public class User_Services : BaseServices<User>, IUser_Services
    {
        IUser_DAL dalSer;
        public User_Services(IUser_DAL dalSer)
        {
            base.dal = dalSer;
            this.dalSer = dalSer;
        }
    }
}
