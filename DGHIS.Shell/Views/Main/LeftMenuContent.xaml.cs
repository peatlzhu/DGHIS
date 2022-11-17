using HandyControl.Controls;
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

namespace DGHIS.Shell.Views
{
    /// <summary>
    /// LeftMenuContent.xaml 的交互逻辑
    /// </summary>
    public partial class LeftMenuContent : UserControl
    {
        public LeftMenuContent()
        {
            InitializeComponent();
        }

        //private void SearchBar_OnSearchStarted(object sender, HandyControl.Data.FunctionEventArgs<string> e)
        //{
        //    var items = sideMenu.Items;
        //    sideMenu.ItemsSource = items.OfType<SideMenuItem>().Where(x => x.Header.ToString().Contains(e.Info.ToString())).ToList();
         
        //}


    }
}
