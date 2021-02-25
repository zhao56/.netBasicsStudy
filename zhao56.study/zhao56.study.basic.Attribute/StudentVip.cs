using System;
using System.Collections.Generic;
using System.Text;
using zhao56.study.basic.AttributeExtend.ValidateExtend;

namespace zhao56.study.basic.AttributeExtend
{
    [Custom(123, Remark = "VIP", Description = ".Net高级班的学员")]
    [Serializable]
    public class StudentVip : Student
    {
        /// <summary>
        /// 不能为空
        /// 长度5到10
        /// </summary>
        [Custom(123, Remark = "VIP", Description = ".Net高级班的学员")]
        [Required]
        [StringLength(4, 10)]
        public string VipGroup { get; set; }

        /// <summary>
        /// QQ有个范围  大于10000  小于999999999999
        /// 不能为空
        /// </summary>
        [Required]
        [Long(10000, 999999999999)]
        public long QQ { get; set; }


        [Long(300_000, 1_000_000)]
        public long Salary { get; set; }

        [Custom(123, Remark = "VIP", Description = ".Net高级班的学员")]
        public void Homework()
        {
            Console.WriteLine("Homework");
        }


    }
}
