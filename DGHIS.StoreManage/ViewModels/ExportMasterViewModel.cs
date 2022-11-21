
using DGHIS.Core.Apis;
using DGHIS.Core.Controls.DropDown;
using DGHIS.Core.Enums;
using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;

using Prism.Commands;
using Prism.Ioc;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Regions;
using System.Windows.Threading;
using System.Windows;

namespace DGHIS.StoreManage.ViewModels
{
    public class ExportMasterViewModel : BaseManageUserControlViewModel
    {
        private string _title = "出库管理";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        /// <summary>
        /// 
        /// 构造函数
        /// </summary>
        /// <param name="container"></param>
        public ExportMasterViewModel(IContainerExtension container) : base(container)
        {
            PagingData.PageSize = 15;
         
        }
             
        public override DelegateCommand AddCommand => throw new NotImplementedException();


        public async override void UserControlLoaded(UserControl page)
        {
            await Task.CompletedTask;
        }

        protected async override Task<object> BindPagingData()
        {
          return    await Task.FromResult(true);
        }   

        protected async override Task<object> UpdateDataStatus<TEntity>(TEntity entity)
        {
               return await Task.FromResult(true);
         }
    }
}
