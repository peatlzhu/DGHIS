using DGHIS.Core.Modules;
using System.Windows.Controls;

namespace DGHIS.Core.Events
{
    /// <summary>
    /// wpf頁面導航
    /// </summary>
    public class NavigatePage
    {
        /// <summary>
        /// 功能菜單名稱
        /// </summary>
        public MenuEntity Menu
        {
            get;
            set;
        }

        /// <summary>
        /// 功能頁面
        /// </summary>
        public Page Page
        {
            get;
            set;
        }
    }

}
