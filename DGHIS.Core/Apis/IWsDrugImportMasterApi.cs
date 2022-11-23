// -------------------------------------------------------------------------
//  <copyright file="IReservationApi.cs" company="江湖人士（DGHIS.com）">
//      Copyright (c) 2020-2050 DGHIS.com. All rights reserved.
//  </copyright>
//  <site>https://DGHIS.com</site>
//  <last-editor>自动化工具生成的客户端接口类，可供Refit调用</last-editor>
//  <last-date>2020-08-24</last-date>
// -------------------------------------------------------------------------
using DGHIS.Core.Enums;
using DGHIS.Core.Models;
using DGHIS.Data;
using DGHIS.Filter;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Apis
{
    /// <summary>
    /// 预约挂号接口
    /// </summary>
    [Headers("User-Agent: DGHIS.WPF-Client")]
    public interface IWsDrugImportMasterApi
    {
        /// <summary>
        /// 分页查询接口
        /// </summary>
        /// <param name="request">请求规则</param>
        /// <returns></returns>
        [Post("/api/WsDrugImportMaster/GetPageData")]
        Task<OperationResult<PageData<ReservationOutputDto>>> GetPageData(PageRequest request);
    }
}
