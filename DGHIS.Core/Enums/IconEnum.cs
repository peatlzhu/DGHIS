using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Enums
{
    /// <summary>
    /// 图标
    /// </summary>
    public enum IconEnum
    {
        /// <summary>
        /// 详情页面图标
        /// </summary>
        [Description("detail")]
        Detail,

        /// <summary>
        /// 新增页面图标
        /// </summary>
        [Description("add")]
        Add,

        /// <summary>
        /// 编辑页面图标
        /// </summary>
        [Description("edit")]
        Edit
    }
}
