﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Filter
{
    /// <summary>
    /// 筛选操作方式
    /// </summary>
    public enum FilterOperate
    {
        /// <summary>
        /// 并且
        /// </summary>
        [OperateCode("and")]
        [Description("并且")]
        And = 1,

        /// <summary>
        /// 或者
        /// </summary>
        [OperateCode("or")]
        [Description("或者")]
        Or = 2,

        /// <summary>
        /// 等于
        /// </summary>
        [OperateCode("=")]
        [Description("等于")]
        Equal = 3,

        /// <summary>
        /// 不等于
        /// </summary>
        [OperateCode("!=")]
        [Description("不等于")]
        NotEqual = 4,

        /// <summary>
        /// 小于
        /// </summary>
        [OperateCode("<")]
        [Description("小于")]
        Less = 5,

        /// <summary>
        /// 小于或等于
        /// </summary>
        [OperateCode("<=")]
        [Description("小于等于")]
        LessOrEqual = 6,

        /// <summary>
        /// 大于
        /// </summary>
        [OperateCode(">")]
        [Description("大于")]
        Greater = 7,

        /// <summary>
        /// 大于或等于
        /// </summary>
        [OperateCode(">=")]
        [Description("大于等于")]
        GreaterOrEqual = 8,

        /// <summary>
        /// 以……开始
        /// </summary>
        [OperateCode("startswith")]
        [Description("开始于")]
        StartsWith = 9,

        /// <summary>
        /// 以……结束
        /// </summary>
        [OperateCode("endswith")]
        [Description("结束于")]
        EndsWith = 10,

        /// <summary>
        /// 字符串的包含（相似）
        /// </summary>
        [OperateCode("like")]
        [Description("包含")]
        Contains = 11,

        /// <summary>
        /// 字符串的不包含
        /// </summary>
        [OperateCode("not like")]
        [Description("不包含")]
        NotContains = 12
    }
}
