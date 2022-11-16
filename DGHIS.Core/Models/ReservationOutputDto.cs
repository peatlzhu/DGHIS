using DGHIS.Core.Enums;
using DGHIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Models
{
    /// <summary>
    /// 預約掛號記錄輸出對象(界面展示)
    /// </summary>
    public class ReservationOutputDto
    {
        /// <summary>
        /// 記錄ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 叫號順序
        /// </summary>
        [BindDescription("叫号顺序", ShowScheme.普通文本, "100*", 1, "")]
        public string Index { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        [BindDescription("流水号", ShowScheme.普通文本, "100*", 2, "")]
        public string BusinessNumber { get; set; }

        /// <summary>
        /// 挂号状态
        /// </summary>
        [BindDescription("挂号状态", ShowScheme.普通文本, "100*", 7, "")]
        public EntityStatus Status { get; set; }

        /// <summary>
        /// 挂号时间
        /// </summary>
        [BindDescription("挂号时间", ShowScheme.普通文本, "150*", 8, "")]
        public DateTime ReservationTime { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        [BindDescription("病人姓名", ShowScheme.普通文本, "80*", 3, "")]
        public string Name { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [BindDescription("性別", ShowScheme.普通文本, "80*", 4, "")]
        public int Gender { get; set; }

        /// <summary>
        /// 挂号科室
        /// </summary>
        [BindDescription("挂号科室", ShowScheme.普通文本, "100*", 4, "")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 诊治医生
        /// </summary>
        [BindDescription("诊治医生", ShowScheme.普通文本, "80*", 5, "")]
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [BindDescription("有效期", ShowScheme.普通文本, "100*", 6, "")]
        public string Expire { get; set; }
    }
}