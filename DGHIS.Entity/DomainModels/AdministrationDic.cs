using DGHIS.Entity.SystemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DGHIS.Data;
using DGHIS.Entity.DomainModels.Core;

namespace DGHIS.Entity.DomainModels
{
    public  class AdministrationDic : BaseModel
    {
        private string _administrationName;
        /// <summary>
        ///给药途径名称
        /// </summary>    
        [BindDescription("给药途径名称")]
        [Required(ErrorMessage = "给药途径名称不能为空...")]
        [StringLength(5, ErrorMessage = "字符长度不能超过5")]
        public string AdministrationName
        {
            get { return _administrationName; }
            set 
            {
                SetProperty(ref _administrationName, value);
            }
        }

        /// <summary>
        ///给药途径代码
        /// </summary> 
        [Required(ErrorMessage = "给药途径代码不能为空...")]
        [StringLength(5, ErrorMessage = "字符长度不能超过5")]
        public string AdministrationCode { get; set; }

        private string _administrationInstruction;
        /// <summary>
        ///给药途径说明
        /// </summary>
        [BindDescription("给药途径说明")]
        [Required(ErrorMessage = "给药途径说明不能为空...")]
        public string AdministrationInstruction
        {
            get { return _administrationInstruction; }
            set
            {
                SetProperty(ref _administrationInstruction, value);
            }
        }

        /// <summary>
        ///输入码
        /// </summary>    
        [BindDescription("输入码")]
        public string InputCode { get; set; }

        /// <summary>
        ///国标标志
        /// </summary>

        public bool? GBCV { get; set; }

        /// <summary>
        ///序号
        /// </summary>
   
        public int? SerialNo { get; set; }

        /// <summary>
        ///是否可用
        /// </summary>
  
        public bool? Enable { get; set; }

        /// <summary>
        ///给药途径ID
        /// </summary>
        public int AdministrationId { get; set; }

        /// <summary>
        ///创建人ID
        /// </summary>
    
        public int? CreateID { get; set; }

        /// <summary>
        ///创建人名
        /// </summary>
  
        public string Creator { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
   
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///修改人ID
        /// </summary>
     
        public int? ModifyID { get; set; }

        /// <summary>
        ///修改人
        /// </summary>

        public string Modifier { get; set; }

        /// <summary>
        ///修改时间
        /// </summary>
  
        public DateTime? ModifyDate { get; set; }


    }
}
