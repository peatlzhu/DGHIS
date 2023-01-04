using DGHIS.Entity.DomainModels;
using DGHIS.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity.DomainModels;

namespace DGHIS.Core.Apis
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    [Headers("User-Agent: DGHIS.WPF-Client")]
    public interface ISysMenuApi
    {
        /// <summary>
        /// 用户查询自己权限菜单
        /// </summary>
        /// <returns></returns>
        [Post("/api/menu/getTreeMenu")]
        Task<List<object>> GetTreeMenu();

       
        [Post("/api/menu/getMenu")]
        Task<object> GetMenu();

        [Post("/api/menu/getTreeItem")]
        Task<object> GetTreeItem(int menuId);

        ///// <summary>
        ///// 只有角色ID为1的才能进行保存操作
        ///// </summary>
        ///// <param name="menu"></param>
        ///// <returns></returns>
        [Post("/api/menu/Save")]
        Task<ApiResult> Save(Sys_Menu menu);


        /// <summary>
        /// 限制只能超级管理员才删除菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [Post("/api/menu/delMenu")]
        Task<ApiResult> DelMenu(int menuId);

       
    }
}
