using DGHIS.Core.Enums;
using DGHIS.Core.ViewModels;
using DGHIS.Data;
using DGHIS.OutpatientSystem.Views;
using KWT.Core.Aop;
using Prism.Commands;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DGHIS.RegisterManagement.ViewModels
{
    /// <summary>
    /// 挂号时段业务
    /// </summary>
    public class RegisterListViewModel : BaseManagePageViewModel
    {
        /// <summary>
        /// 挂号时段业务构造函数
        /// </summary>
        /// <param name="container"></param>
        public RegisterListViewModel(IContainerExtension container) : base(container)
        {
            PagingData.PageSize = 20;
        }


        /// <summary>
        /// 处理新增事件
        /// </summary>
        public override DelegateCommand AddCommand => new DelegateCommand(() =>
        {
            this.ShowDialog(typeof(AddOrEditReservation).FullName, IconEnum.Add, "新增预约挂号记录", callback: async (d) =>
            {
                if (d.Parameters.GetValue<bool>("success"))
                    await BindPagingData();
            });
        });

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="page"></param>
        public async override void PageLoaded(Page page)
        {
            await BindPagingData();
        }


        //private ObservableCollection<Account> listGrid = new ObservableCollection<Account>();
        ///// <summary>
        ///// 表格数据源
        ///// </summary>
        //public ObservableCollection<Account> ListGrid
        //{
        //    get { return listGrid; }
        //    set { SetProperty(ref listGrid, value); }
        //}

        /// <summary>
        /// 绑定分页数据
        /// </summary>
        [WaitComplete]
        protected async override Task<object> BindPagingData()
        {
            List<Account> list = new List<Account>();
            for (int i = 0; i < 25; i++)
            {
                list.Add(new Account
                {
                    Name = "赵佳仁" + i,
                    RegTime = DateTime.Now.AddDays(i),
                    RoleName = "管理员" + i,
                    Title = "无职" + i,
                    UserID = 100 + i
                });
            }
            PageData = list;
            await Task.Delay(200);
            return true;
        }

        /// <summary>
        /// 通用更改状态方法
        /// </summary>
        /// <typeparam name="TEntity">待更改状态实体</typeparam>
        /// <param name="entity">当前对象</param>
        [WaitComplete]
        protected override async Task<object> UpdateDataStatus<TEntity>(TEntity entity)
        {
            if (!IsDevelopment)
            {
                await Task.Delay(300);
                //var model = entity as ReservationOutputDto;
                //var response = await RestService.For<IReservationApi>(AuthClient).ChangeStatus(model.Id, (EntityStatus)model.Status);
                //AlertPopup(response.Message, response.Succeeded ? MessageType.Success : MessageType.Error, async (d) =>
                //{
                //    if (response.Succeeded) await BindPagingData();
                //});
                //return response.Succeeded;
            }
            return null;
        }
    }

    public class Account
    {
        [BindDescription("用户ID")]
        public int UserID { get; set; }
        [BindDescription("用户名")]
        public string Name { get; set; }
        [BindDescription("注册时间")]
        public DateTime RegTime { get; set; }
        [BindDescription("角色名")]
        public string RoleName { get; set; }
        [BindDescription("职级")]
        public string Title { get; set; }
    }
}
