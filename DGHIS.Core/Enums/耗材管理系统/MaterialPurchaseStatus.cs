// -------------------------------------------------------------------------
//  <copyright file="MaterialPurchaseStatus.cs" company="江湖人士（DGHIS.com）">
//      Copyright (c) 2020-2050 DGHIS.com. All rights reserved.
//  </copyright>
//  <site>https://DGHIS.com</site>
//  <last-editor>自动化工具生成的枚举类（CloudH）</last-editor>
//  <last-date>2020-08-26 16:24:22</last-date>
// -------------------------------------------------------------------------

using System.ComponentModel;

namespace DGHIS.Core.Enums.耗材管理系统
{
    /// <summary>
    /// 耗材采购状态
    /// </summary>
    public enum MaterialPurchaseStatus
    {
        /// <summary>
        /// 未执行
        /// </summary>
        未执行 = 1,

        /// <summary>
        /// 采购中
        /// </summary>
        采购中 = 2,

        /// <summary>
        /// 待入库
        /// </summary>
        待入库 = 3,

        /// <summary>
        /// 未完成
        /// </summary>
        未完成 = 4,

        /// <summary>
        /// 已入库
        /// </summary>
        已入库 = 5,

        /// <summary>
        /// 完成
        /// </summary>
        完成 = 6
    }
}