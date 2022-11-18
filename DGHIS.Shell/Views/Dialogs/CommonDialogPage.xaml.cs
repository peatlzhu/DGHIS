using DGHIS.Constants;
using DGHIS.Core.Events;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DGHIS.Shell.Views.Dialogs
{
    /// <summary>
    /// CommonDialogPage.xaml 的交互逻辑
    /// </summary>
    public partial class CommonDialogPage : Page
    {
        IRegionManager _regionManager;
        IEventAggregator _ea;
        public CommonDialogPage(IRegionManager regionManager, IEventAggregator ea)
        {
            InitializeComponent();
            _ea = ea;
            _regionManager = regionManager;
            RegionManager.SetRegionName(pages, RegionNames.DialogRegin);    
            _regionManager.Regions.Remove("DialogRegin");
            RegionManager.SetRegionManager(pages, _regionManager);

            ConstrolStateEvent controlEvent = _ea.GetEvent<ConstrolStateEvent>();
            //  controlEvent.Subscriptions.Clear();  //不能使用clear ,会清除主窗体注册事件
            if(controlEvent.Subscriptions.Count>1)
                controlEvent.Subscriptions.Remove(controlEvent.Subscriptions.ElementAt(1));   //移除对话窗体注册事件
            controlEvent.Subscribe(SetSaveButton);          

            DisableDialogPageButtonEvent disableEvent = _ea.GetEvent<DisableDialogPageButtonEvent>();
            disableEvent.Subscriptions.Clear();
            disableEvent.Subscribe(() => { saveArea.Visibility = Visibility.Collapsed; });
        }

        private void SetSaveButton(ControlState state)
        {
            SaveButton.IsEnabled = state.IsEnabled;
            maskGrid.Visibility = state.IsEnabled ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
