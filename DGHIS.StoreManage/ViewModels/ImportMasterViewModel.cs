
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
using DGHIS.StoreManage.Views;
using DGHIS.StoreManage.Models;
using Prism.Services.Dialogs;
using DGHIS.Core.Threading;
using DGHIS.Entity.DomainModels;

namespace DGHIS.StoreManage.ViewModels
{
    public class ImportMasterViewModel : BaseManageUserControlViewModel
    {
        private string _title = "入库管理";
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
        public ImportMasterViewModel(IContainerExtension container) : base(container)
        {
            PagingData.PageSize = 15;
            DispatcherExtension.RunOnUIThreadAsync(BindPagingData);
           // Dispatcher.CurrentDispatcher.InvokeAsync(async () => await BindPagingData(), DispatcherPriority.Render);
        }


        private ImportMasterCondition query = new ImportMasterCondition();

        /// <summary>
        /// 查询条件
        /// </summary>
        public ImportMasterCondition Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
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

        /// <summary>
        /// 处理新增事件
        /// </summary>
        public override DelegateCommand AddCommand => new DelegateCommand(() =>
        {
            this.ShowDialog(typeof(AddOrEditImport).FullName, IconEnum.Add, "新增入库记录", callback: async (d) =>
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
            this.ShowDialog(typeof(AddOrEditImport).FullName, IconEnum.Edit, "修改入库记录", args: item, callback: async (d) =>
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


        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="page"></param>
        public async override void UserControlLoaded(UserControl page)
        {

            await LoadDictionary();
            await Task.CompletedTask;
           
            //  await BindPagingData();
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


        /// <summary>
        /// 绑定分页数据
        /// </summary>
        // [WaitComplete]
        protected override async Task<object> BindPagingData()
        {          
            return await SetBusyAsync(async () =>
            {
                if (!IsDevelopment)
                {
                    var request = this.GetQueryParameter(Query);
                    var response = await RestService.For<IAdministrationDicApi>(AuthClient).GetPageDataAsync(request);
                    if (string.IsNullOrEmpty(response.msg))
                    {
                        PageData = response.rows;
                        this.PagingData.Total = response.total;
                    }
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

        /// <summary>
        /// 更改状态
        /// </summary>
        public DelegateCommand<StatusComboBox> SelectionChangedCommand => new DelegateCommand<StatusComboBox>((c) =>
        {
            this.ChangeStatus<StatusComboBox, ReservationOutputDto>(c, "预约挂号记录", p => nameof(p.Status));
        });

        /// <summary>
        /// 通用更改状态方法
        /// </summary>
        /// <typeparam name="TEntity">待更改状态实体</typeparam>
        /// <param name="entity">当前对象</param>
       // [WaitComplete]
        protected override async Task<object> UpdateDataStatus<TEntity>(TEntity entity)
        {
            if (!IsDevelopment)
            {
                var model = entity as ReservationOutputDto;
                var response = await RestService.For<IReservationApi>(AuthClient).ChangeStatus(model.Id, model.Status);
                AlertPopup(response.Message, response.Succeeded ? MessageType.Success : MessageType.Error, async (d) =>
                {
                    if (response.Succeeded) await BindPagingData();
                });
                return response.Succeeded;
            }
            return null;
        }
    }
}
