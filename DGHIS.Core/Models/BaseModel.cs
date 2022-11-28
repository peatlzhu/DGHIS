using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Models
{
    public class BaseModel: IDataErrorInfo
    {
        /// <summary>
        /// 错误集合
        /// </summary>
        private Dictionary<string, string> dataErrors = new Dictionary<string, string>();

        
        /// <summary>
        /// IDataErrorInfo的固定实现,Modify By DG
        /// </summary>
        public string Error
        {
            get => string.Join("', '", new List<string>(dataErrors.Values));
        }
        
        /// <summary>
        /// 是否存在错误 (Add by DG)
        /// </summary>
        public bool HasError
        {
            get 
            { 
                return dataErrors.Count > 0;
            }              
        }

        public string this[string columnName]
        {
            get
            {
                ValidationContext vc = new ValidationContext(this, null, null);
                vc.MemberName = columnName;
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0)
                {
                    string error = string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                    AddDic(dataErrors, vc.MemberName, error);
                    return error;
                }
                RemoveDic(dataErrors, vc.MemberName);
                return null;
            }
        }

        /// <summary>
        /// 移除错误信息
        /// </summary>
        /// <param name="dics"></param>
        /// <param name="dicKey"></param>
        private void RemoveDic(Dictionary<string, string> dics, string dicKey)
        {
            dics.Remove(dicKey);
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="dics"></param>
        /// <param name="dicKey"></param>
        private void AddDic(Dictionary<string, string> dics, string dicKey, string dicValue)
        {
            if (dics.ContainsKey(dicKey))
            {
                dics.Remove(dicKey);
                dics.Add(dicKey, dicValue);
            }
            else
                dics.Add(dicKey, dicValue);
        }
    }
}
