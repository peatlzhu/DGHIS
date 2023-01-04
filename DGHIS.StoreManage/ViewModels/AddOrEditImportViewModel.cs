using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DGHIS.Core.Apis;
using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;
using DGHIS.Entity.DomainModels;
using KWT.Core.Aop;
using Newtonsoft.Json;
using Prism.Ioc;
using Refit;
using VOL.Entity.DomainModels;

namespace DGHIS.StoreManage.ViewModels
{
    /// <summary>
    /// 新增入库,编辑入库功能页面viewmodel,用于处理业务逻辑
    /// 调用web api保存数据
    /// </summary>
    public class AddOrEditImportViewModel : BaseDialogPageViewModel
    {
        IMapper _mapper;
        /// <summary>
        /// 新增预约挂号业务处理构造函数
        /// </summary>
        /// <param name="container"></param>
        public AddOrEditImportViewModel(IContainerExtension container,IMapper mapper) : base(container)      
        {
            this._mapper = mapper; 
            InitData();
        }

        /// <summary>
        /// 编辑模式下初始化界面数据
        /// </summary>
        private void InitData()
        {
            AdministrationDic current = this.GetContext<AdministrationDic>();
            //不爲null表示处于编辑模式
            if (current != null)
            {
                Dto = _mapper.Map<AdministrationDic>(current);              
            }
        }

        private AdministrationDic _dto = new AdministrationDic();

        /// <summary>
        /// 界面上输入的信息
        /// </summary>
        public AdministrationDic Dto
        {
            get { return _dto; }
            set { SetProperty(ref _dto, value); }
        }

        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        private bool ValidateFormData()
        {
            if (Dto.HasError)
            {
                Alert(Dto.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 新增,编辑保存方法,从viewmodel获取数据保存即可.
        /// </summary>
        /// <returns></returns>
      //  [WaitComplete]
        protected async override Task SaveCommand()
        {
            if (!ValidateFormData()) return;
            await SetInputBusyAsync(async () => {
                var current = this.GetContext<AdministrationDic>();
                if (current == null)
                {
                    var mainData = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Dto));
                    var response = await RestService.For<IAdministrationDicApi>(AuthClient).AddAsync(new SaveModel {MainData= mainData });
                    AlertPopup(response.Message, response.Status ? MessageType.Success : MessageType.Error, (d) =>
                    {
                        if (response.Status)
                            this.CloseDialog(returnValue: "已经添加成功啦，这里可以是任何参数和对象哟，父窗体可以接收到此回传参数。");
                    });
                }
                else
                {
                    var mainData = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(Dto));
                    var response = await RestService.For<IAdministrationDicApi>(AuthClient).UpdateAsync(new SaveModel { MainData = mainData });
                    AlertPopup(response.Message, response.Status ? MessageType.Success : MessageType.Error, (d) =>
                    {
                        if (response.Status)
                            this.CloseDialog(returnValue: "已经修改成功啦，这里可以是任何参数和对象哟，父窗体可以接收到此回传参数。");
                    });
                }
            });
          
        }
    }
}
