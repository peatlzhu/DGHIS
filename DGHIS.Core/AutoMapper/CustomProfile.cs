﻿using AutoMapper;
using DGHIS.Core.Models;

namespace DGHIS.Core.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<ReservationOutputDto, ReservationInputDto>(); 
   ;
            //CreateMap<SysUserInfoDto, SysUserInfo>()
            //    .ForMember(a => a.Id, o => o.MapFrom(d => d.uID))
            //    .ForMember(a => a.Address, o => o.MapFrom(d => d.addr))
            //    .ForMember(a => a.RIDs, o => o.MapFrom(d => d.RIDs))
            //    .ForMember(a => a.Age, o => o.MapFrom(d => d.age))
            //    .ForMember(a => a.Birth, o => o.MapFrom(d => d.birth))
            //    .ForMember(a => a.Status, o => o.MapFrom(d => d.uStatus))
            //    .ForMember(a => a.UpdateTime, o => o.MapFrom(d => d.uUpdateTime))
            //    .ForMember(a => a.CreateTime, o => o.MapFrom(d => d.uCreateTime))
            //    .ForMember(a => a.ErrorCount, o => o.MapFrom(d => d.uErrorCount))
            //    .ForMember(a => a.LastErrorTime, o => o.MapFrom(d => d.uLastErrTime))
            //    .ForMember(a => a.LoginName, o => o.MapFrom(d => d.uLoginName))
            //    .ForMember(a => a.LoginPWD, o => o.MapFrom(d => d.uLoginPWD))
            //    .ForMember(a => a.Remark, o => o.MapFrom(d => d.uRemark))
            //    .ForMember(a => a.RealName, o => o.MapFrom(d => d.uRealName))
            //    .ForMember(a => a.Name, o => o.MapFrom(d => d.name))
            //    .ForMember(a => a.IsDeleted, o => o.MapFrom(d => d.tdIsDelete))
            //    .ForMember(a => a.RoleNames, o => o.MapFrom(d => d.RoleNames));
        }
    }
}
