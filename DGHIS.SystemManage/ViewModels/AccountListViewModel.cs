using DGHIS.Core.Apis;
using DGHIS.Core.Controls.DropDown;
using DGHIS.Core.Enums;
using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;
using DGHIS.Entity.DomainModels;
using DGHIS.OutpatientSystem.Models;
using DGHIS.SystemManage.Views;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DGHIS.SystemManage.ViewModels
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class AccountListViewModel : BaseManageUserControlViewModel
    {
        private string _title = "用户管理";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        /// <summary>
        /// 用户管理构造函数
        /// </summary>
        /// <param name="container"></param>
        public AccountListViewModel(IContainerExtension container) : base(container)
        {
            PagingData.PageSize = 20;
        }


        private List<DictionaryData> _dataList = new List<DictionaryData>();

        /// <summary>
        ///字典数据
        /// </summary>
        public List<DictionaryData> DataList
        {
            get { return _dataList; }
            set { SetProperty(ref _dataList, value); }
        }


        private AccountCondition query = new AccountCondition();

        /// <summary>
        /// 查询条件
        /// </summary>
        public AccountCondition Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }

        /// <summary>
        /// 处理新增事件
        /// </summary>
        public override DelegateCommand AddCommand => new DelegateCommand(() =>
        {
            this.ShowDialog(typeof(AddOrEditAccount).FullName, IconEnum.Add, "新增用户记录", callback: async (d) =>
            {
                if (d.Parameters.GetValue<bool>("success"))
                    await BindPagingData();
            });
        });

        /// <summary>
        /// 编辑事件
        /// </summary>
        public DelegateCommand<object> EditCommand => new DelegateCommand<object>((item) =>
        {
            this.ShowDialog(typeof(AddOrEditAccount).FullName, IconEnum.Edit, "修改用户记录", args: item, callback: async (d) =>
            {
                if (d.Parameters.GetValue<bool>("success"))
                    await BindPagingData();
            });
        });


        /// <summary>
        /// 删除事件
        /// </summary>
        public DelegateCommand<object> DeleteCommand => new DelegateCommand<object>((item) =>
        {
            this.Confirm("确认删除记录!", callback: (d) =>
            {
                if (d.Result == ButtonResult.Yes)
                {
                    AlertPopup("已确认删除!");
                }
                else
                {
                    AlertPopup("取消删除!");
                }
            });
        });



        public async override void UserControlLoaded(UserControl page)
        {
            await LoadDictionary();
            await Task.CompletedTask;
        }


        private async Task LoadDictionary()
        {
            List<DictionaryData> list = new List<DictionaryData>();
            list.Add(new DictionaryData { ID = 234, Name = "男" });
            list.Add(new DictionaryData { ID = 235, Name = "女" });
            list.Add(new DictionaryData { ID = 236, Name = "未知" });
            DataList = list;
            await Task.CompletedTask;
        }


        protected async override Task<object> BindPagingData()
        {
            return await SetBusyAsync(async () =>
            {
                if (!IsDevelopment)
                {
                    var request = this.GetQueryRules(Query);
                    var response = await RestService.For<IWsDrugImportMasterApi>(AuthClient).GetPageDataAsync(new PageDataOptions { });
                    //if (response.Succeeded)
                    //{
                    //    PageData = response.Data.Rows;
                    //    this.PagingData.Total = response.Data.Total;
                    //}
                    return response;
                }
                else
                {
                    this.PagingData.Total = 200;
                    int counter = this.PagingData.PageSize;
                    var list = new List<ReservationOutputDto>();
                    for (int i = 0; i < counter; i++)
                    {
                        list.Add(new ReservationOutputDto
                        {
                            BusinessNumber = DateTime.Now.ToString($"GH-yyyyMMdd{i + 1}"),
                            DepartmentID = i + 1,
                            DepartmentName = $"测试科室{i}",
                            DoctorName = $"非诉讼{i}",
                            Expire = i % 2 == 0 ? "上午有效" : "下午有效",
                            Id = i + 1,
                            Index = $"第{i + 1}号",
                            Name = $"柳{i}刀",
                            Gender = 235,
                            ReservationTime = DateTime.Now.AddSeconds(i),
                            Status = i % 5 == 0 ? EntityStatus.停用 : EntityStatus.正常
                        });
                    }
                    PageData = list;
                    return true;
                }
            });

        }

        protected override Task<object> UpdateDataStatus<TEntity>(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
