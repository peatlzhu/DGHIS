using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace DGHIS.Core.Extensions
{
    [MarkupExtensionReturnType(typeof(Visibility))]
    public class AuthToVisibilityExtension : MarkupExtension
    {
        /// <summary>
        /// 控件标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public AuthToVisibilityExtension()
        {
            Tag = string.Empty;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="tag">控件标签</param>
        public AuthToVisibilityExtension(string tag)
        {
            Tag = tag;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Tag))
                return Visibility.Collapsed;

            //if (AuthProvider.Instance == null)
            //    return Visibility.Visible;
            //if (AuthProvider.Instance.CheckAccess(Tag))
            //    return Visibility.Visible;
            return Visibility.Collapsed;
        }
    }
}
