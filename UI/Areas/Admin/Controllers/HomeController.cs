using Newtonsoft.Json;
using RedisHelper;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            redis();
            Lognet();
            return View();
        }




        //layui table
        public string layuiTable(string emailx, string sexx)
        {
            //获取layui传入的参数
            string num = Request["limit"].ToString().Trim();//数量
            string page = Request["page"].ToString().Trim();//页数
                                                            //获取条件
            string searchEmail = ""; string searchSex = "";
            if (!string.IsNullOrEmpty(emailx))
            {
                searchEmail = emailx;
            }
            if (!string.IsNullOrEmpty(sexx))
            {
                searchSex = sexx;
            }

            List<Demo> ld = new List<Demo>();
            int numStatr = int.Parse(page) * 10;
            int numEnd = (int.Parse(page) - 1) * 10;
            for (int i = numEnd; i < numStatr; i++)
            {
                Demo de = new Demo();
                de.Id = i;
                //条件筛选
                //筛选邮箱
                if (string.IsNullOrEmpty(searchEmail)) { de.Email = i + "er1@qq.com"; }
                else
                {
                    //判断有没有@
                    if (searchEmail.Contains("@")) { de.Email = i + searchEmail; }
                    else { de.Email = i + searchEmail + "@qq.com"; }
                }
                //筛选性别
                if (searchSex == "男") { de.Sex = 1; de.Name = "Tom" + i; de.Logins = i * 3; }
                else if (searchSex == "女") { de.Sex = 0; de.Name = "Jir" + i; de.Logins = i * 2; }
                else { if (i % 2 == 0) { de.Sex = 0; de.Name = "Jir" + i; de.Logins = i * 2; } else { de.Sex =1; de.Name = "Tom" + i; de.Logins = i * 3; } }

                de.JoinTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                ld.Add(de);
            }


            return JsonConvert.SerializeObject(new { code = 0, msg = "", count = 30, data = ld });
        }


        //日志
        private void Lognet()
        {


            SysLogMsg logMessage = new SysLogMsg();
            logMessage.UserName = "小王";
            logMessage.OperationTime = DateTime.Now;
            logMessage.Content = "测试小酱油";
            logMessage.Url = "192.168";
            string Retunr = LogHelper.logMessage(logMessage);
            LogHelper.Info(Retunr);
        }
        //redis
        private void redis()
        {
            RedisHelperCs redis = new RedisHelperCs(1);

            #region String

            string str = "123";
            Demo demo = new Demo()
            {
                Id = 1,
                Name = "123"
            };
            var resukt = redis.StringSet("redis_string_test", str);
            var str1 = redis.StringGet("redis_string_test");
            redis.StringSet("redis_string_model", demo);
            var model = redis.StringGet<Demo>("redis_string_model");

            for (int i = 0; i < 10; i++)
            {
                redis.StringIncrement("StringIncrement", 2);
            }
            for (int i = 0; i < 10; i++)
            {
                redis.StringDecrement("StringIncrement");
            }
            redis.StringSet("redis_string_model1", demo, TimeSpan.FromSeconds(10));

            #endregion String

            #region List

            for (int i = 0; i < 10; i++)
            {
                redis.ListRightPush("list", i);
            }

            for (int i = 10; i < 20; i++)
            {
                redis.ListLeftPush("list", i);
            }
            var length = redis.ListLength("list");

            var leftpop = redis.ListLeftPop<string>("list");
            var rightPop = redis.ListRightPop<string>("list");

            var list = redis.ListRange<int>("list");

            #endregion List

            #region Hash

            redis.HashSet("user", "u1", "123");
            redis.HashSet("user", "u2", "1234");
            redis.HashSet("user", "u3", "1235");
            var news = redis.HashGet<string>("user", "u2");

            #endregion Hash

            #region 发布订阅

            redis.Subscribe("Channel1");
            for (int i = 0; i < 10; i++)
            {
                redis.Publish("Channel1", "msg" + i);
                if (i == 2)
                {
                    redis.Unsubscribe("Channel1");
                }
            }

            #endregion 发布订阅

            #region 事务

            var tran = redis.CreateTransaction();

            tran.StringSetAsync("tran_string", "test1");
            tran.StringSetAsync("tran_string1", "test2");
            bool committed = tran.Execute();

            #endregion 事务

            #region Lock

            var db = redis.GetDatabase();
            RedisValue token = Environment.MachineName;
            if (db.LockTake("lock_test", token, TimeSpan.FromSeconds(10)))
            {
                try
                {
                    //TODO:开始做你需要的事情
                    Thread.Sleep(5000);
                }
                finally
                {
                    db.LockRelease("lock_test", token);
                }
            }

            #endregion Lock
        }
    }


    public class Demo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Sex { get; set; }
        public int Logins { get; set; }
        public string JoinTime { get; set; }
    }
}