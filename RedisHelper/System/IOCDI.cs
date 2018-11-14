using System.Web.Mvc;
using TheOne.IServices.System;
using TheOne.IServices;
using TheOne.Model;
namespace RedisHelper.System
{

    public partial class IOCDI : Controller
    {
        protected IUser_Services UserSer;
        protected IUserType_Services UserTypeSer;
    }
}
