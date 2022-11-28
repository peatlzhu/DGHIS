using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Identity
{
    /// <summary>
    /// 登录用户上下文
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 用户所在科室
        /// </summary>
        public int[] DepartmentID { get; set; }

        /// <summary>
        /// 用户当前所在科室
        /// </summary>
        public int CurrentDepartmentID { get; set; }

        /// <summary>
        /// 用户当前所在科室名称
        /// </summary>
        public string CurrentDepartmentName { get; set; } = "重症医学科(ICU)";

        /// <summary>
        /// 当前登录用户姓名
        /// </summary>
        public string UserName { get; set; } = "张三封";

        /// <summary>
        /// 当前用户角色ID集合
        /// </summary>
        public int[] RoleID { get; set; }

        /// <summary>
        /// 用户会话token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; } = "玛丽医院";

        /// <summary>
        /// 显示
        /// </summary>
        public string ShowText => "用户：" + UserName + "，科室：【" + CurrentDepartmentName + "】";

        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserImage { get; set; }


        /// <summary>
        /// 获取本机在Internet网络的广域网IP
        /// </summary>
        public string WanIp { get; set; }
    }
}