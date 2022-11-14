﻿using DGHIS.Constants;
using DGHIS.Core.Events;
using DGHIS.Core.Modules;
using DGHIS.Core.ViewModels;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DGHIS.Shell.ViewModels
{
    public class LeftMenuContentViewModel: BaseViewModel
    {
        /// <summary>
        /// 登录窗体界面构造函数
        /// </summary>
        /// <param name="container"></param>
        public LeftMenuContentViewModel(IContainerExtension container) : base(container)
        {

        }



        /// <summary>
        /// 点击菜单选择页面
        /// </summary>
        public DelegateCommand<string> SelectCmd => new DelegateCommand<string>((menuName) =>
        {
            var manager = Container.Resolve<PageManager>();
            var pageType = manager.GetPage(menuName);
            if (pageType == null)
            {
                MessageBox.Show($"未实现或创建名称为【{menuName}】的Page对象", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var page = Container.Resolve(pageType) as Page;
            EventAggregator.GetEvent<PageEvent>().Publish(new NavigatePage { MenuName = menuName, Page = page });
        });
    }
}