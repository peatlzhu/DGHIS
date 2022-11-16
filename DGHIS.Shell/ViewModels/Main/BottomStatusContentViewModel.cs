using DGHIS.Core.Identity;
using DGHIS.Core.ViewModels;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DGHIS.Shell.ViewModels
{
    public class BottomStatusContentViewModel : BaseViewModel
    {
        /// <summary>
        /// 主界面构造函数
        /// </summary>
        /// <param name="container"></param>
        public BottomStatusContentViewModel(IContainerExtension container) : base(container)
        {
          
        }

        /// <summary>
        /// 当前登录用戶
        /// </summary>
        public UserContext CurrentUser => UserContext;
    }
}
