using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.StoreManage
{
    /// <summary>
    /// 库房管理模块
    /// </summary>
    [Module(ModuleName = "StoreManageModule", OnDemand = true)]
    public class StoreManageModule:IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
