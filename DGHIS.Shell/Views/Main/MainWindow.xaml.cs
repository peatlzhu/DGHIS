using DGHIS.Core.Events;
using DGHIS.Core.Modules;
using Prism.Events;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Prism.Ioc;
using HandyControl.Controls;
using TabItem = HandyControl.Controls.TabItem;
using Window = HandyControl.Controls.Window;
using Prism.Regions;
using System;

namespace DGHIS.Shell.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {        
            InitializeComponent();
            RegionManager.SetRegionName(MainTabPanel, "ContentRegion");
            ContainerLocator.Container.Resolve<IRegionManager>().Regions.Remove("ContentRegion");
            RegionManager.SetRegionManager(MainTabPanel, ContainerLocator.Container.Resolve<IRegionManager>());
            PageEvent pageEvent = ContainerLocator.Container.Resolve<IEventAggregator>().GetEvent<PageEvent>();
            pageEvent.Subscribe((p) =>
            {
                MenuEntity menu = p.Menu;
                string menuName = menu==null? p.MenuName:menu.Name;
                AddPage(menuName, p.Page);              
            });

            ConstrolStateEvent maskEvent = ContainerLocator.Container.Resolve<IEventAggregator>().GetEvent<ConstrolStateEvent>();
            maskEvent.Subscribe((state) =>
            {               
                maskGrid.Visibility = state.IsEnabled ? Visibility.Collapsed : Visibility.Visible;
            });
          
        }
         

        private void AddPage(string name, Page page)
        {
           HandyControl.Controls.TabItem tabItem = MainTabPanel.Items.OfType<HandyControl.Controls.TabItem>().FirstOrDefault(item => item.Header.ToString() == name);
        
            if (tabItem == null)
            {
                tabItem = new HandyControl.Controls.TabItem()
                {
                    Header = name,
                };
                var pageFrame = new Frame();
                pageFrame.Focusable = false;
                pageFrame.BorderThickness = new Thickness(0);
                pageFrame.Margin = new Thickness(20);
                pageFrame.Navigate(page);
                tabItem.Content = pageFrame;
                MainTabPanel.Items.Add(tabItem);
            }
            MainTabPanel.SelectedItem = tabItem;         
            MainTabPanel.Focus(); 
        }

    }

    public static class ControlHelper
    {
        public static T FindVisualParent<T>(DependencyObject sender) where T : DependencyObject
        {
            do
            {
                sender = VisualTreeHelper.GetParent(sender);
            }
            while (sender != null && !(sender is T));
            return sender as T;
        }
    }

    /// <summary>
    /// 主菜单样式选择器
    /// </summary>
    public class MenuStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            MenuEntity functionItem = item as MenuEntity;
            if (functionItem.IsGroup)
                return ControlHelper.FindVisualParent<Menu>(container).Resources["MainMenuStyle"] as Style;
            else
                return null;
        }
    }
}