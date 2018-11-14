using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOne.Model.DataModel;

namespace TheOne.Model
{
    public class THContext : DbContext
    {

        public THContext():base("name=RedisTs") { }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
