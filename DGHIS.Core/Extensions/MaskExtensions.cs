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

namespace DGHIS.Core.Extensions
{
    /// <summary>
    /// 蒙层效果扩展
    /// </summary>
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
