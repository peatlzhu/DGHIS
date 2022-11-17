using DGHIS.Constants;
using DGHIS.OutpatientSystem.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.OutpatientSystem
{
    /// <summary>
    /// 预约挂号模块
    /// </summary>
    [Module(ModuleName = "OutpatientSystemModule", OnDemand = true)]
    public class OutpatientSystemModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
         
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
