using DGHIS.Core.Controls.Mask;
using HandyControl.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Window = System.Windows.Window;

namespace DGHIS.Core.Extensions
{
    /// <summary>
    /// 蒙层效果扩展 
    /// </summary>
    [Obsolete("快速切换窗体重新加载数据,或快速提交数据时,经常出现异常.修改为显隐显示")]
    public static class MaskExtensions
    {
        private static LoadingWait w = new LoadingWait();
        /// <summary>
        /// 显示蒙层
        /// </summary>
        public static void Show()
        {
            //Window win = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
            //Grid container = win.GetChildObject<Grid>("maskContainer");
            //if (container == null) throw new Exception("界面上未找到名称爲maskContainer的Grid容器控件！");
            //container.Children.Add(w);
        }


        /// <summary>
        /// 关闭蒙层
        /// </summary>
        public static void Close()
        {
            //Window win = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.IsActive);
            //Grid container = win.GetChildObject<Grid>("maskContainer");
            //if (container == null) throw new Exception("界面上未找到名称爲maskContainer的Grid容器控件！");
            //container.Children.Remove(w);
        }
    }
}
