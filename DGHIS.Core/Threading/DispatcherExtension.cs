using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DGHIS.Core.Threading
{

    /// <summary>
    /// dispatcher 默认设置在render 呈现页面时执行.
    /// </summary>
    public static class DispatcherExtension
    {
        public static void RunOnUIThreadAsync(Func<Task> execute, DispatcherPriority priority= DispatcherPriority.Render)
        {
            Dispatcher.CurrentDispatcher.InvokeAsync(execute, priority);
        }

        public static void RunOnUIThreadAsync<T>(Func<Task<T>> execute, DispatcherPriority priority = DispatcherPriority.Render)
        {            
            Dispatcher.CurrentDispatcher.InvokeAsync(execute, priority);
        }

    }
}
