using DGHIS.Core.Controls.Common;
using DGHIS.Core.Models;
using System;
using System.Collections.Generic;

namespace DGHIS.Core.Controls.DropDown
{
    /// <summary>
    /// 科室下拉框
    /// </summary>
    public class DepartmentComboBox : BaseComboBox
    {
        /// <summary>
        /// 初始化科室數據，可調用接口獲取數據。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnInitialized(object sender, EventArgs e)
        {
            DisplayMemberPath = "Name";
            SelectedValuePath = "Id";

            //var response = await RestService.For<IDepartmentApi>(AuthHttpClient.Instance).GetAll();
            //if (response.Succeeded)
            //{
            //	Data = response.Data as IList;
            //}

            List<DepartmentOutputDto> list = new List<DepartmentOutputDto>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new DepartmentOutputDto
                {
                    Id = i + 1,
                    Name = $"测试科室{i + 1}"
                });
            }
            Data = list;
        }
    }

}
