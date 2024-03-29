﻿using HandyControl.Controls;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TabControl = HandyControl.Controls.TabControl;
using TabItem = HandyControl.Controls.TabItem;

namespace DGHIS.Core.Helpers
{
    public static class TabSwitchOrAddHelper
    {
        private static string _mainTabControlName = "MainTabControlName";
        public static IRegionManager RegionManager { get; set; }
        public static TabControl MainTabItemNode { get; set; }
        public static IRegion MainRegion { get; set; }
        private static NavigationParameters _parameters;

        public static List<string> TabViewNames { get; set; } = new List<string>();

        static TabSwitchOrAddHelper()
        {

        }
        public static void SetSwitchOrAddTabItemdependency(IRegionManager regionManager, TabControl mainTabItemNode)
        {
            RegionManager = regionManager;
            MainTabItemNode = mainTabItemNode;
            MainRegion = regionManager.Regions[_mainTabControlName];
            MainTabItemNode.SelectionChanged += MainTabItemSelectionChanged;
        }

        private static void MainTabItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (MainTabItemNode.SelectedItem != null)
            {
                TabItem tabItem = MainTabItemNode.SelectedItem as TabItem;
                object content = tabItem?.Content;
                string itemViewName_1 = (content as IViewName)?.ViewName;
                string itenViewName_2 = ((content as FrameworkElement)?.DataContext as IViewName)?.ViewName;
                string viewName = itemViewName_1 != null ? itemViewName_1 : itenViewName_2;
                if (viewName != null)
                {
                    MainRegion.RequestNavigate(new Uri(viewName, UriKind.Relative), _parameters);
                }

                _parameters = null;

            }
        }

        public static void SwitchTab(string viewName)
        {
            TabItem item = null;
            for (var i = 0; i < MainTabItemNode.Items.Count; ++i)
            {
                item = (TabItem)MainTabItemNode.Items[i];

                object content = item?.Content;
                string itemViewName_1 = (item?.Content as IViewName)?.ViewName;
                string itenViewName_2 = ((item?.Content as FrameworkElement)?.DataContext as IViewName)?.ViewName;
                if (itemViewName_1 == viewName || itenViewName_2 == viewName)
                {
                    MainTabItemNode.SelectedItem = item;

                }
            }
        }

        public static void AddTab(string viewName, Type viewType)
        {

            TabViewNames.Add(viewName);
            // 由于 Prism MVVM 的设置，因为此方法创造的实例，也能够直接 自动绑定 ViewModel
            object content = System.Activator.CreateInstance(viewType);

            var v = ((content as FrameworkElement) as IViewName);
            if (v != null)
            {
                v.ViewName = viewName;

            }
            var vm = ((content as FrameworkElement)?.DataContext as IViewName);
            if (vm != null)
            {
                vm.ViewName = viewName;
            }


            // object content = Container.Resolve(viewType);

            TabItem tabItem = new TabItem { Header = viewName, Content = content };
            tabItem.Closed += TabItemClosed;
            MainRegion.Add(content, viewName);
            MainTabItemNode.Items.Add(tabItem);

            MainTabItemNode.SelectedItem = tabItem;
        }

        public static void SwitchOrAddTab(string viewName, Type viewType = null, NavigationParameters navigationParameters = null)
        {

            if (viewType == null)
            {
                throw new ArgumentNullException("页面类型为空");
            }

            if (TabViewNames.Contains(viewName))
            {
                SwitchTab(viewName);
            }
            else
            {
                AddTab(viewName, viewType);
            }

            _parameters = navigationParameters;
        }


        private static void TabItemClosed(object sender, EventArgs e)
        {
            // 移除 TabItem 时，同时也移除 view 
            // TabItem 在点击关闭按钮时，会被自动移除，因此无需手动移除

            TabItem tabItem = (TabItem)sender;
            object content = tabItem?.Content;

            string itemViewName_1 = (content as IViewName)?.ViewName;
            string itenViewName_2 = ((content as FrameworkElement)?.DataContext as IViewName)?.ViewName;
            string viewName = itemViewName_1 ?? itenViewName_2 ?? itenViewName_2;
            if (tabItem != null && content != null && viewName != null)
            {
                TabViewNames.Remove(TabViewNames.Find(t => t == viewName));
                MainRegion.Remove(content);
                MainTabItemNode.Items.Remove(tabItem);
            }
        }
    }
}
