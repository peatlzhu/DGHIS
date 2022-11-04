﻿using DGHIS.Core.Controls.Common;
using DGHIS.Core.Enums;
using DGHIS.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Controls.DropDown
{
    /// <summary>
    /// 通用業務狀態下拉框
    /// </summary>
    public class StatusComboBox : BaseComboBox
    {
        /// <summary>
        /// 初始化業務狀態
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnInitialized(object sender, EventArgs e)
        {
            SelectedValuePath = "Value";
            DisplayMemberPath = "Name";
            Data = (IList)EnumExtensions.GetEnumEntities<EntityStatus>();
        }
    }
}