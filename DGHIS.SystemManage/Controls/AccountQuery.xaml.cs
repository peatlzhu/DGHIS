using DGHIS.Constants;
using DGHIS.Core.Modules;
using DGHIS.SystemManage.Views;
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

namespace DGHIS.SystemManage.Controls
{
    /// <summary>
    /// AccountQuery.xaml 的交互逻辑
    /// </summary>
    [QueryLocator(RegionNames.QueryRegin, typeof(AccountList))]
    public partial class AccountQuery : UserControl
    {
        public AccountQuery()
        {
            InitializeComponent();
        }
    }
}
