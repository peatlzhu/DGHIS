﻿using DGHIS.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.StoreManage.Models
{
    public class ImportMasterCondition
    {
        [QueryRule(FilterOperate.Contains, "AdministrationName")]
        public string AdministrationName
        {
            get;
            set;
        }

        [QueryRule(FilterOperate.Contains, "DeptID", "", FilterOperate.And)]
        public int DepartmentID
        {
            get;
            set;
        }

        [QueryRule(FilterOperate.Contains, "DictionaryID", "", FilterOperate.And)]
        public int DicID
        {
            get;
            set;
        }
    }
}
