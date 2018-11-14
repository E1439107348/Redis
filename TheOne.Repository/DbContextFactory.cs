using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TheOne.Model;

namespace TheOne.Repository
{
   public class DbContextFactory
    {       //获取当前EF上下文的唯一实例
        public static DbContext GetCurrentThreadInstance()
        {
            DbContext obj = CallContext.GetData(typeof(DbContextFactory).FullName) as DbContext;
            if (obj == null)
            {
                obj = new THContext();
                CallContext.SetData(typeof(DbContextFactory).FullName, obj);
            }
            return obj;
        }
    }
}
