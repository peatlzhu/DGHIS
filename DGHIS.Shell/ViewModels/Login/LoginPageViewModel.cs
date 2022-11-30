﻿using DGHIS.Shell;
using DGHIS.Core.Apis;
using DGHIS.Core.Enums;
using DGHIS.Core.Identity;
using DGHIS.Core.Models;
using DGHIS.Core.ViewModels;
using DGHIS.Extensions;
using DGHIS.Http;
using DGHIS.Shell.Views;
using DGHIS.Shell.Views.Login;
using Prism.Commands;
using Prism.Ioc;
using Refit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DGHIS.Entity.DomainModels;
using VOL.Entity.DomainModels;
using Newtonsoft.Json;
using Common.Utility;

namespace DGHIS.Shell.ViewModels.Login
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class LoginPageViewModel : BaseViewModel
    {
        /// <summary>
        /// 登录界面构造函数
        /// </summary>
        /// <param name="container"></param>
        public LoginPageViewModel(IContainerExtension container) : base(container)
        {

        }

        private LoginDto _dto = new LoginDto();

        /// <summary>
        /// 当前登录用户信息（界面输入的）
        /// </summary>
        public LoginDto CurrentUser
        {
            get { return _dto; }
            set { SetProperty(ref _dto, value); }
        }

        public DelegateCommand PageLoadCommand => new DelegateCommand(delegate
        {
        });

        public DelegateCommand PreviewMouseDownCommand => new DelegateCommand(delegate
        {
            Alert("忘记密码了该咋办?", (d) =>
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "msedge";
                process.StartInfo.Arguments = @"https://DGHIS.com";
                process.Start();
            });
        });

        /// <summary>
        /// 登录命令
        /// </summary>
        public DelegateCommand<PasswordBox> LoginCommand => new DelegateCommand<PasswordBox>(async (pwd) =>
        {
            if (string.IsNullOrWhiteSpace(CurrentUser.Name))
            {
                Alert("请输入用户名！");
                return;
            }
            if (string.IsNullOrWhiteSpace(pwd.Password))
            {
                AlertPopup("请输入密码！");
                return;
            }        
            var baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl)) throw new Exception("未配置BaseUrl节点！");

            //开发环境模拟登录，正式环境调接口
            if (ConfigurationManager.AppSettings["Development"].CastTo<bool>())
            {
                //UserContext = new UserContext
                //{
                //    Token = new UserToken { AccessToken = "这是访问token", RefreshToken = "这是刷新token" }
                //};
                //AuthHttpClient.SetHttpClient(baseUrl, UserContext.Token.AccessToken);
                string token = "这是访问token";
                UserContext = new UserContext
                {
                    Token = token,                 
                    WanIp = NetHelper.WANIP
                };
                AuthHttpClient.SetHttpClient(baseUrl, token);
            }
            else
            {
                //var response = await RestService.For<ILoginApi>(baseUrl).Login(CurrentUser);
                //if (!response.Succeeded)
                //{
                //    Alert(response.Message);
                //    return;
                //}
                //UserContext = response.Data;
                //AuthHttpClient.SetHttpClient(baseUrl, response.Data.Token);

                var response = await RestService.For<ISystemUserApi>(baseUrl).Login(new LoginInfo { UserName = CurrentUser.Name, Password = pwd.Password, VerificationCode = "123", UUID = "111" });
                var tokenData = response.Data as dynamic;
                string token = tokenData.token;
                AuthHttpClient.SetHttpClient(baseUrl, token);
                UserContext = new UserContext
                {
                    Token = token,
                    UserName = tokenData.userName,
                    UserImage = tokenData.Img,
                    WanIp = NetHelper.WANIP
                };
            }
            ShellSwitcher.Switch<LoginWindow, MainWindow>();
        });
    }
}
