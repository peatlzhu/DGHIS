using DGHIS.Entity.DomainModels.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Models
{
    /// <summary>
    /// 预约挂号输入入DTO
    /// </summary>
    public class ReservationInputDto : BaseModel
    {
        /// <summary>
        /// 叫号顺序
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string BusinessNumber { get; set; }

        /// <summary>
        /// 挂号时间
        /// </summary>
        public DateTime? ReservationTime { get; set; }

      
        /// <summary>
        /// 病人姓名
        /// </summary>
        [Required(ErrorMessage = "病人姓名不能33为空...")]
        [StringLength(5, ErrorMessage = "字符长度不能超过5")]
        public string Name
        {
            get;set;
        }

        /// <summary>
        /// 性別
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 挂号科室
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// 诊治医生
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 科室ID
        /// </summary>
        public int DepartmentID { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public string Expire { get; set; }

       
    }
}