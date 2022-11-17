using DGHIS.Core.Enums;
using DGHIS.Core.Events;
using DGHIS.Core.Identity;
using DGHIS.Constants;
using DGHIS.Extensions;
using DGHIS.Filter;
using DGHIS.Http;
using DGHIS.Json;
using DGHIS.Reflection;
using Prism.Events;
using Prism.Ioc;
//using Prism.Logging;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using DGHIS.Core.Extensions;
using System.Threading.Tasks;

namespace DGHIS.Core.ViewModels
{
    /// <summary>
    /// 界面ViewModel基类
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 基类ViewModel构造函数
        /// </summary>
        /// <param name="container">注入容器</param>
        protected BaseViewModel(IContainerExtension container)
        {
            Container = container;
            EventAggregator = container.Resolve<IEventAggregator>();
            _dialogService = container.Resolve<IDialogService>();
           // Logger = container.Resolve<ILoggerFacade>();
            _regionManager = container.Resolve<IRegionManager>();
        }

        /// <summary>
        /// 已授权客户端连接
        /// </summary>
        public static HttpClient AuthClient => AuthHttpClient.Instance;

        /// <summary>
        /// 是否開發環境
        /// </summary>
        public bool IsDevelopment { get { return ConfigurationManager.AppSettings["Development"].CastTo<bool>(); } }

        /// <summary>
        /// 日志对象
        /// </summary>
       // protected ILoggerFacade Logger { get; }

        /// <summary>
        /// 事件汇总器，用于发布或订阅事件
        /// </summary>
        protected IEventAggregator EventAggregator { get; }

        /// <summary>
        /// 区域管理器
        /// </summary>
        protected IRegionManager RegionManager => _regionManager;

        /// <summary>
        /// 依赖注入容器
        /// </summary>
        protected IContainerExtension Container { get; }

        /// <summary>
        /// 当前已登录用户信息
        /// </summary>
        protected static UserContext UserContext { get; set; }

        /// <summary>
        /// 当前弹框上下文传参数据
        /// </summary>
        protected object Context => RegionManager.Regions[RegionNames.DialogRegin].Context;

        /// <summary>
        /// 当前弹框上下文传参数据
        /// </summary>
        protected T GetContext<T>()
        {
            if (Context == null) return default;
            return Context.ToString().FromJsonString<T>();
        }

        /// <summary>
        /// 导航到指定Page
        /// </summary>
        /// <param name="regionName">区域名称</param>
        /// <param name="target">目标Page名称</param>
        /// <param name="navigationCallback">导航回调函数</param>
        protected void Navigate(string regionName, string target, Action<NavigationResult> navigationCallback = null)
        {
            IRegion region = _regionManager.Regions[regionName];
            if (region == null) return;
            region.RemoveAll();
            if (navigationCallback != null)
                region.RequestNavigate(target, navigationCallback);
            else
                region.RequestNavigate(target);
        }

        /// <summary>
        /// 弹框提示
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="callback">回调函数</param>
        protected void Alert(string message, Action<IDialogResult> callback = null)
        {
            _dialogService.ShowDialog("AlertDialog", new DialogParameters($"message={message}"), callback);
        }

        /// <summary>
        /// 弹出消息提示框，1秒钟自动关闭
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="callback">回调函数</param>
        protected void AlertPopup(string message, MessageType messageType = MessageType.Success, Action<IDialogResult> callback = null)
        {
            switch (messageType)
            {
                case MessageType.Success:
                    _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={message}"), callback);
                    break;
                case MessageType.Error:
                    _dialogService.ShowDialog("ErrorDialog", new DialogParameters($"message={message}"), callback);
                    break;
                case MessageType.Question:
                    _dialogService.ShowDialog("WarningDialog", new DialogParameters($"message={message}"), callback);
                    break;
                default:
                    _dialogService.ShowDialog("SuccessDialog", new DialogParameters($"message={message}"), callback);
                    break;
            }
        }

        /// <summary>
        /// 确认框提示
        /// </summary>
        /// <param name="message">确认框消息</param>
        /// <param name="callback">回调函数</param>
        protected void Confirm(string message, Action<IDialogResult> callback = null)
        {
            _dialogService.ShowDialog("ConfirmDialog", new DialogParameters($"message={message}"), callback);
        }

        /// <summary>
        /// 打开模态窗口
        /// </summary>
        /// <param name="page">内容页面</param>
        /// <param name="icon">图标</param>
        /// <param name="pageTitle">页面标题</param>
        /// <param name="args">页面传参</param>
        /// <param name="callback">关闭窗体后执行的回调函数</param>
        /// <param name="disableArea">是否禁用弹框页面的保存，取消区域（即隐藏保存，取消按钮）</param>
        protected void ShowDialog(string page, IconEnum icon, string pageTitle = "未设置标题", object args = null, Action<IDialogResult> callback = null, bool disableArea = false)
        {
            IDialogWindow dialogWindow = Container.Resolve<IDialogWindow>("dialog");
            dialogWindow.ConfigureDialogWindowEvents(callback);

            DialogParameters pars = new DialogParameters();
            pars.Add("page", page);
            pars.Add("icon", icon.ToDescription());
            pars.Add("title", pageTitle);
            if (disableArea) pars.Add("disableArea", true);
            if (args != null) pars.Add("args", args.ToJson());
            dialogWindow.ConfigureDialogWindowContent("CommonDialogPage", pars);
            dialogWindow.ShowDialog();


        }

        /// <summary>
        /// 关闭对话框
        /// </summary>
        /// <param name="isClose">是否关闭</param>
        /// <param name="returnValue">返回值</param>
        protected void CloseDialog(bool isClose = true, object returnValue = null)
        {
            if (isClose)
            {
                DialogParameters pars = new DialogParameters();
                pars.Add("success", "true");
                if (returnValue != null) pars.Add("returnValue", returnValue);
                EventAggregator.GetEvent<CloseDialogEvent>().Publish(pars);
            }
        }

        /// <summary>
        /// 获取查询规则
        /// </summary>
        /// <param name="query">当前查询对象</param>
        /// <returns></returns>
        protected virtual PageRequest GetQueryRules(object query)
        {
            PageRequest request = new PageRequest();
            var pros = query.GetType().GetProperties();
            var rules = pros.Select(x => x.GetAttribute<QueryRuleAttribute>()).Where(x => x != null).ToList();
            var groups = rules.Where(x => !string.IsNullOrEmpty(x.Group)).ToList();

            var normal = rules.Except(groups).ToList();

            var filter = new FilterGroup();
            normal.ForEach(x =>
            {
                var p = pros.FirstOrDefault(m => m.GetAttribute<QueryRuleAttribute>().FieldName == x.FieldName && m.GetAttribute<QueryRuleAttribute>().Operate == x.Operate);
                if (!IsIgnore(query, p))
                {
                    filter.AddRule(new FilterRule { Field = x.FieldName, Operate = x.Operate, Value = p.GetValue(query) });
                }
            });

            groups.DistinctBy(x => x.Group).ToList().ForEach(x =>
            {
                FilterGroup g = new FilterGroup(x.GroupOperate);
                groups.Where(m => m.Group == x.Group).ToList().ForEach(m =>
                {
                    var p = pros.FirstOrDefault(m => m.GetAttribute<QueryRuleAttribute>().FieldName == x.FieldName && m.GetAttribute<QueryRuleAttribute>().Operate == x.Operate);
                    if (!IsIgnore(query, p))
                    {
                        g.AddRule(new FilterRule { Field = m.FieldName, Operate = m.Operate, Value = p.GetValue(query) });
                    }
                });
                filter.Groups.Add(g);
            });

            request.FilterGroup = filter;

            return request;
        }

        /// <summary>
        /// 默认值情况下忽略构建查询规则
        /// </summary>
        /// <param name="query">当前查询条件对象实例</param>
        /// <param name="p">当前属性</param>
        /// <returns></returns>
        private bool IsIgnore(object query, PropertyInfo p)
        {
            var v = p.GetValue(query);
            if (p.PropertyType == typeof(int) && 0 >= (int)v) return true;
            if (p.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(v + "")) return true;
            if (p.PropertyType == typeof(DateTime) && v == null) return true;
            if (p.PropertyType == typeof(DateTime) && (DateTime)v == DateTime.MinValue) return true;
            return false;
        }


        #region 加载与执行中 Create by DG
        public async Task<object> SetBusyAsync(Func<Task<object>> func)
        {
            ExecuteBefore();
            try
            {
                await Task.Delay(500);
                return await func();          

            }
            catch (Exception ex)
            {              
                throw;
            }
            finally
            {
                ExecuteAfter();
            }
        }


        public async Task SetBusyAsync(Func<Task> func, int millisecDelay = 0)
        {
            ExecuteBefore();
            try
            {
                await func();
                await Task.Delay(millisecDelay);
            }
            catch (Exception ex)
            {
                var methodName = func?.Method;           
                throw;
            }
            finally
            {
                ExecuteAfter();
            }
        }

        /// <summary>
        /// 执行前
        /// </summary>
        private void ExecuteBefore()
        {
            _isBusy = true;
            MaskExtensions.Show();
        }

        /// <summary>
        /// 执行后
        /// </summary>

        private void ExecuteAfter()
        {
            _isBusy = false;
            MaskExtensions.Close();
        }

        public async Task SetInputBusyAsync(Func<Task> func)
        {           
            ExecuteInputBefore();
            try
            {

                await Task.Delay(500);
                await func();
            }
            catch (Exception ex)
            {
                var methodName = func?.Method;             
                throw;
            }
            finally
            {
                ExecuteInputAfter();
            }
        }

        /// <summary>
        /// 数据录入执行前
        /// </summary>
        private void ExecuteInputBefore()
        {
            _isInputBusy = true;
            MaskExtensions.Show();
        }

        /// <summary>
        /// 数据录入执行后
        /// </summary>

        private void ExecuteInputAfter()
        {
           _isInputBusy = false;
            MaskExtensions.Close();        
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                SetProperty(ref _isBusy,value);
            }
        }

        private bool _isInputBusy;

        public bool IsInputBusy
        {
            get => _isInputBusy;
            set
            {
                _isInputBusy = value;          
               SetProperty(ref _isInputBusy, value);          
            }
        }

        #endregion 加载与执行中 Create by DG
    }
}
