using DGHIS.Shell.ViewModels.Dialogs;
using DGHIS.Core.Modules;
using DGHIS.Reflection;
using DGHIS.Shell.Views.Dialogs;
using DGHIS.Shell.Views.Login;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Unity;
using DGHIS.Shell.RegionAdptor;
using DGHIS.OutpatientSystem;
using DGHIS.OutpatientSystem.Views;
using DGHIS.OutpatientSystem.ViewModels;
using Prism.Mvvm;
using DGHIS.Core.AutoMapper;
using AutoMapper;

namespace DGHIS.Shell
{
    public partial class App : PrismApplication
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);       
            DispatcherUnhandledException += App_DispatcherUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
		}

		protected override Window CreateShell()
		{
			return Container.Resolve<LoginWindow>();
		}

        /// <summary>
        /// 注册AutoMapper
        /// </summary>
        /// <param name="containerRegistry"></param>
        private  void RegisterAutoMapper(IContainerRegistry containerRegistry)
        {
            IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            containerRegistry.RegisterInstance(mapper);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
            RegisterAutoMapper(containerRegistry);
            containerRegistry.RegisterSingleton<PageManager>();
			containerRegistry.RegisterSingleton<UserControlManager>();
			Type[] pages = AppDomainAllAssemblyFinder.FindAll<Page>();
			var pageManager = containerRegistry.GetContainer().Resolve<PageManager>();
			Type[] array = pages;
			foreach (Type item in array)
			{
				containerRegistry.RegisterForNavigation(item, item.FullName);
				FunctionAttribute function = item.GetAttribute<FunctionAttribute>();
				if (function != null)
				{
					pageManager.Add(function.UniqueName, item);
				}
			}
			Type[] controls = AppDomainAllAssemblyFinder.FindAll<UserControl>();
			var controlManager = containerRegistry.GetContainer().Resolve<UserControlManager>();
			Type[] array2 = controls;
			foreach (Type item2 in array2)
			{
				containerRegistry.RegisterForNavigation(item2, item2.FullName);
				QueryLocatorAttribute locator = item2.GetAttribute<QueryLocatorAttribute>();
				if (locator != null)
				{
					controlManager.Add(item2.FullName, new ControlMapping
					{
						ControlType = item2,
						RegionName = locator.RegionName,
						TargetType = locator.Target
					});               

                }
			}
			containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();
			containerRegistry.RegisterDialog<ConfirmDialog, ConfirmDialogViewModel>();
			containerRegistry.RegisterDialog<ErrorDialog, ErrorDialogViewModel>();
			containerRegistry.RegisterDialog<SuccessDialog, SuccessDialogViewModel>();
			containerRegistry.RegisterDialog<WarningDialog, WarningDialogViewModel>();
			containerRegistry.Register(typeof(IDialogWindow), typeof(Views.Dialogs.DialogWindow), "dialog");
			containerRegistry.RegisterDialog<CommonDialogPage, CommonDialogPageViewModel>();
          
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();          
        }

        /// <summary>
        /// 注册系统模块
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var modules = AppDomainAllAssemblyFinder.FindAll<IModule>();
            foreach (var item in modules)
            {
                moduleCatalog.AddModule(new ModuleInfo
                {
                    ModuleName = item.Name,
                    ModuleType = item.AssemblyQualifiedName,
                    InitializationMode = InitializationMode.OnDemand
                });
            }       
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
     //       regionAdapterMappings.RegisterMapping(typeof(HandyControl.Controls.TabControl), Container.Resolve<TabControlRegionAdptor>());
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }

        /// <summary>
        /// 统一异常处理（非UI线程未捕获异常处理事件(例如自己创建的一个子线程)）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                MessageBox.Show($"程序组件出错，原因：{ex.Message}", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 统一异常处理（UI线程未捕获异常处理事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show($"程序运行出错，原因：{ex.Message}-{ex.InnerException?.Message}", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;//表示异常已处理，可以继续运行
        }

        /// <summary>
        /// 统一异常处理（Task任务异常）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show($"执行任务出错，原因：{ex.Message}", "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
