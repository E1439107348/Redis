using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TheOne.Model
{
    public class DbModelContextFactory
    {
        //获取当前EF上下文的唯一实例
        public static DbContext GetCurrentThreadInstance()
        {
            DbContext obj = CallContext.GetData(typeof(DbModelContextFactory).FullName) as DbContext;
            if (obj == null)
            {
                obj = new THContext();
                CallContext.SetData(typeof(DbModelContextFactory).FullName, obj);
            }
            return obj;
        }
    }
}
