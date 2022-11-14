using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Identity
{
    /// <summary>
    /// 会话token
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// 访客token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public long RefreshUctExpires { get; set; }
    }
}
