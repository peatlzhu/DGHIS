using DGHIS.Constants;
using DGHIS.Core.Modules;
using DGHIS.StoreManage.Views;
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

namespace DGHIS.StoreManage.Controls
{
    /// <summary>
    /// ImportMasterQuery.xaml 的交互逻辑
    /// </summary>
    [QueryLocator(RegionNames.QueryRegin, typeof(ImportMaster))]
    public partial class ImportMasterQuery : UserControl
    {
        public ImportMasterQuery()
        {
            InitializeComponent();
        }
    }
}
