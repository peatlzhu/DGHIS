using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DGHIS.Core.Apis;
using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;
using KWT.Core.Aop;
using Prism.Ioc;
using Refit;

namespace DGHIS.StoreManage.ViewModels
{
    /// <summary>
    /// 新增入库,编辑入库功能页面viewmodel,用于处理业务逻辑
    /// 调用web api保存数据
    /// </summary>
    public class AddOrEditImportViewModel : BaseDialogPageViewModel
    {
        /// <summary>
        /// 新增预约挂号业务处理构造函数
        /// </summary>
        /// <param name="container"></param>
        public AddOrEditImportViewModel(IContainerExtension container) : base(container)
        {
            InitData();
        }

        /// <summary>
        /// 编辑模式下初始化界面数据
        /// </summary>
        private void InitData()
        {
            ReservationOutputDto current = this.GetContext<ReservationOutputDto>();
            //不爲null表示处于编辑模式
            if (current != null)
            {
                Dto = new ReservationInputDto
                {
                    DepartmentID = current.DepartmentID,
                    DepartmentName = current.DepartmentName,
                    DoctorName = current.DoctorName,
                    Gender = current.Gender,
                    Index = current.Index,
                    BusinessNumber = current.BusinessNumber,
                    Name = current.Name,
                    ReservationTime = current.ReservationTime,
                    Expire=current.Expire
                };
            }
        }

        private ReservationInputDto _dto = new ReservationInputDto();

        /// <summary>
        /// 界面上输入的信息
        /// </summary>
        public ReservationInputDto Dto
        {
            get { return _dto; }
            set { SetProperty(ref _dto, value); }
        }

        /// <summary>
        /// 新增,编辑保存方法,从viewmodel获取数据保存即可.
        /// </summary>
        /// <returns></returns>
      //  [WaitComplete]
        protected async override Task SaveCommand()
        {
            await SetInputBusyAsync(async () => {
                var current = this.GetContext<ReservationOutputDto>();
                if (current == null)
                {
                    if (!IsDevelopment)
                    {
                        var response = await RestService.For<IReservationApi>(AuthClient).Add(Dto);
                        AlertPopup(response.Message, response.Succeeded ? MessageType.Success : MessageType.Error, (d) =>
                        {
                            if (response.Succeeded)
                                this.CloseDialog(returnValue: "已经添加成功啦，这里可以是任何参数和对象哟，父窗体可以接收到此回传参数。");
                        });
                    }
                }
                else
                {
                    if (!IsDevelopment)
                    {
                        var response = await RestService.For<IReservationApi>(AuthClient).Update(Dto);
                        AlertPopup(response.Message, response.Succeeded ? MessageType.Success : MessageType.Error, (d) =>
                        {
                            if (response.Succeeded)
                                this.CloseDialog(returnValue: "已经修改成功啦，这里可以是任何参数和对象哟，父窗体可以接收到此回传参数。");
                        });
                    }
                }
            });
          
        }
    }
}
