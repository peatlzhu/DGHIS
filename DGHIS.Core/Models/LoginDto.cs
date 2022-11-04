using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Models
{
    /// <summary>
    /// 登錄dto
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用戶名
        /// </summary>
        public string Name { get; set; } = "https://DGHIS.com";

        /// <summary>
        /// 登錄密碼
        /// </summary>
        public string Password { get; set; }
    }
}
