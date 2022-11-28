using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Models
{
    public  class WsDrugImportMaster 
    {
        /// <summary>
        ///入库单号
        /// </summary>
      
        public string DocumentNo { get; set; }

        /// <summary>
        ///入库单位
        /// </summary>
     
        public string StorageCode { get; set; }

        /// <summary>
        ///入库日期
        /// </summary>
    
        public DateTime? ImportDate { get; set; }

        /// <summary>
        ///供应商
        /// </summary>
      
        public int? SupplierId { get; set; }

        /// <summary>
        ///供货方
        /// </summary>
      
        public string Supplier { get; set; }

        /// <summary>
        ///供货单位
        /// </summary>
   
        public string ProviderStorageCode { get; set; }

        /// <summary>
        ///总应付款
        /// </summary>
     
        public decimal? AccountReceivable { get; set; }

        /// <summary>
        ///该批药品的已付款
        /// </summary>
      
        public decimal? AccountPayed { get; set; }

        /// <summary>
        ///该批药品的附加费，如运杂费
        /// </summary>
     
        public decimal? AdditionalFee { get; set; }

        /// <summary>
        ///入库方式
        /// </summary>
    
        public string ImportCode { get; set; }

        /// <summary>
        ///记账日期
        /// </summary>
     
        public DateTime? AccountDate { get; set; }

        /// <summary>
        ///是否可用
        /// </summary>
     
        public bool? Enable { get; set; }

        /// <summary>
        ///备注
        /// </summary>
     
        public string Memos { get; set; }

        /// <summary>
        ///审核时间
        /// </summary>
    
        public DateTime? AuditDate { get; set; }

        /// <summary>
        ///审核人工号
        /// </summary>
 
        public int? AuditId { get; set; }

        /// <summary>
        ///审核人姓名
        /// </summary>
   
        public string Auditor { get; set; }

        /// <summary>
        ///备注
        /// </summary>
    
        public string Remark { get; set; }

        /// <summary>
        ///CreateID
        /// </summary>
     
        public int? CreateID { get; set; }

        /// <summary>
        ///Creator
        /// </summary>
  
        public string Creator { get; set; }

        /// <summary>
        ///CreateDate
        /// </summary>
      
        public DateTime? CreateDate { get; set; }

        /// <summary>
        ///ModifyID
        /// </summary>
       
        public int? ModifyID { get; set; }

        /// <summary>
        ///Modifier
        /// </summary>

        public string Modifier { get; set; }

        /// <summary>
        ///ModifyDate
        /// </summary>
     
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        ///到票标识
        /// </summary>
    
        public string TicketArrivalIndicator { get; set; }

        /// <summary>
        ///审核状态
        /// </summary>
    
        public int? AuditStatus { get; set; }

        /// <summary>
        ///唯一标识
        /// </summary>
    
        public Guid ImportMasterId { get; set; }

    
   

    }
}
