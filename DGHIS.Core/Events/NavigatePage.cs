using DGHIS.Core.Modules;
using System.Windows.Controls;

namespace DGHIS.Core.Events
{
    /// <summary>
    /// wpf頁面导航
    /// </summary>
    public class NavigatePage
    {
        /// <summary>
        /// 功能菜单名称
        /// </summary>
        public MenuEntity Menu
        {
            get;
            set;
        }

        /// <summary>
        /// 功能菜单名称
        /// </summary>
        public string  MenuName
        {
            get;
            set;
        }


        /// <summary>
        /// 功能页面
        /// </summary>
        public Page Page
        {
            get;
            set;
        }
    }

}
