using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOne.Model.DataModel
{
    /// <summary>
    /// 
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string u_Id { get; set; }
        [Display(Name = "用户名")]
        [MaxLength(50)]
        public string u_Name { get; set; }

        /// <summary>
        /// md5小写格式
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(50)]
        public string u_PassWord { get; set; }


        [Display(Name = "注册时间")]
        public DateTime u_RegisterTime { get; set; }


        [Display(Name = "用户类型")]
        [MaxLength(50)]
        public string u_TypeId { get; set; }

        /// <summary>
        /// 1男 0女   剩下为其他
        /// </summary>
        [Display(Name = "性别")]
        public int u_Sex { get; set; }

        /// <summary>
        ///年龄 取整数  
        /// </summary>
        [Display(Name = "年龄")]
        public int u_Age { get; set; }

    }
}
