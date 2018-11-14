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
    /// 用户类型
    /// </summary>
    [Table("UserType")]
    public class UserType
    {
        [Key]
        [MaxLength(50)]
        public string Ut_Id { get; set; }
        [Display(Name = "类型")]
        [MaxLength(50)]
        public string Ut_Name { get; set; }

        [Display(Name = "备注")]
        [MaxLength(50)]
        public string Ut_Remarks { get; set; }
    }
}
