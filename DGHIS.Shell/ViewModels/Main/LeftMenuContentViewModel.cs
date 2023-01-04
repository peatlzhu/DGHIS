using Common.Utility;
using DGHIS.Constants;
using DGHIS.Core.Apis;
using DGHIS.Core.Events;
using DGHIS.Core.Identity;
using DGHIS.Core.Modules;
using DGHIS.Core.Threading;
using DGHIS.Core.ViewModels;
using HandyControl.Controls;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Ioc;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VOL.Entity.DomainModels;
using static System.Net.Mime.MediaTypeNames;
using MessageBox = HandyControl.Controls.MessageBox;

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
            DispatcherExtension.RunOnUIThreadAsync(GetMenus);
        }

        private ObservableCollection<MenuEntity> _mainMenuItemsSource;
        /// <summary>
        /// 窗体主菜单集合
        /// </summary>
        public ObservableCollection<MenuEntity> MainMenuItemsSource
        {
            get { return _mainMenuItemsSource; }
            set
            { 
                SetProperty(ref _mainMenuItemsSource, value);
            }
        }

         /// <summary>
         /// 初始化功能菜單
         /// </summary>
        private async Task GetMenus()
        {
            MainMenuItemsSource = new ObservableCollection<MenuEntity>();
            var response = await RestService.For<ISysMenuApi>(AuthClient).GetTreeMenu();
            var menuDataList = response as List<dynamic>;

            //foreach(var menu in menuDataList)
            // {
            //     MainMenuItemsSource.Add(new MenuEntity { Id = menu.id, Name = menu.name,ParentId=menu.parentid });
            // }

            foreach (var item in menuDataList)
            {
                if (item.parentId == 0)
                {
                    MenuEntity menu = new MenuEntity();
                    menu.Id = item.id;
                    menu.Name = item.name;
                    menu.ParentId = item.parentId;
                    menu.Children = AddChildNode(menuDataList, item.id);
                    MainMenuItemsSource.Add(menu);
                }
            }
        }

        private List<MenuEntity> AddChildNode(List<dynamic> list, dynamic id)
        {
            List<MenuEntity> menuList =new List<MenuEntity>();

            foreach (var item in list.Where(p => p.parentId == id))
            {
                MenuEntity menu = new MenuEntity();
                menu.Id = item.id;
                menu.Name = item.name;
                menu.ParentId = item.parentId;
                menu.Children = AddChildNode(list, item.id);
                menuList.Add(menu);
            }
            return menuList;
        }


        ///// <summary>
        ///// 点击菜单选择页面
        ///// </summary>
        //public DelegateCommand<HandyControl.Data.FunctionEventArgs<object>> SwitchItemCmd => new DelegateCommand<HandyControl.Data.FunctionEventArgs<object>>((p) =>
        //{
        //    var menuItem = p.Info as SideMenuItem;
        //    var menuName = menuItem.Header.ToString();
        //    var manager = Container.Resolve<PageManager>();
        //    var pageType = manager.GetPage(menuName);
        //    if (pageType == null)
        //    {
        //       // AlertPopup($"未实现或创建名称为【{menuName}】的Page对象",MessageType.Error);
        //        MessageBox.Show($"未实现或创建名称为【{menuName}】的Page对象", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return;
        //    }
        //    var page = Container.Resolve(pageType) as Page;
        //    EventAggregator.GetEvent<PageEvent>().Publish(new NavigatePage { MenuName = menuName, Page = page });

        //});


        /// <summary>
        /// 点击菜单选择页面
        /// </summary>
        public DelegateCommand<HandyControl.Data.FunctionEventArgs<object>> SwitchItemCmd => new DelegateCommand<HandyControl.Data.FunctionEventArgs<object>>((p) =>
        {
            var menuItem = p.Info as SideMenuItem;
            if (menuItem.Visibility==Visibility.Collapsed) return;
            var targetName = menuItem.CommandParameter?.ToString();
            if(string.IsNullOrEmpty(targetName))
            {
                 AlertPopup($"未实现或创建对象",MessageType.Error);              
                return;
            }
            RegionManager.RequestNavigate("ContentRegion", targetName);
        });

    }
}
