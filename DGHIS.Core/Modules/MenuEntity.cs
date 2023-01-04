using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Modules
{
    /// <summary>
    /// 功能菜單
    /// </summary>
    public class MenuEntity
    {
        /// <summary>
        /// 功能菜單ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 是否分組
        /// </summary>
        public bool IsGroup { get; set; }

        /// <summary>
        /// 上級ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 功能菜單名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子菜單集合
        /// </summary>
        public List<MenuEntity> Children { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// 目标对象名称
        /// </summary>
        public string TargetName { get; set; }
    }
}
