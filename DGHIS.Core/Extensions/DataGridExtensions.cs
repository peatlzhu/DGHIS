﻿using DGHIS.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DGHIS.Core.Extensions
{
    /// <summary>
    /// DataGrid扩展方法
    /// </summary>
    public static class DataGridExtensions
    {
        /// <summary>
        /// 动态生成列
        /// </summary>
        /// <param name="dataGrid">DataGrid控件实例</param>
        /// <param name="index">列插入位置</param>
        /// <param name="data">数据源</param>
        /// <param name="operationKey">操作列资源</param>
        /// <param name="operationWidth">操作列宽度</param>
        public static void GenerateColumns(this DataGrid dataGrid, int index, object data, string operationKey, DataGridLength operationWidth)
        {
            IList<BindDescriptionAttribute> list = GetColumns(data);
      
            Page page = GetParentObject<Page>(dataGrid, "page");
            UserControl userControl = GetParentObject<UserControl>(dataGrid, "userControl");
            FrameworkElement frameworkElement = page==null? userControl: page;
            //if (frameworkElement == null) throw new Exception("未获取到当前窗口名称为page的(Page)页面对象 或userControl(UserControl)用户控件，原因：没有为Page设置Name，且名称必须为【page】！或没有为UserControl 设置userControl，且名称必须为【UserControl 】！");

            for (int i = 0; i < list.Count; i++)
            {
                switch (list[i].ShowAs)
                {
                    case ShowScheme.普通文本:
                        dataGrid.Columns.Insert(i + index, new DataGridTextColumn
                        {
                            Header = list[i].HeaderName,
                            Binding = new Binding(list[i].PropertyName),
                            Width = list[i].Width
                        });
                        break;
                    case ShowScheme.自定义:
                        if (frameworkElement.FindResource(list[i].ResourceKey) != null)
                        {
                            DataGridTemplateColumn val = new DataGridTemplateColumn();
                            val.Header = list[i].HeaderName;
                            val.Width = list[i].Width;
                            val.CellTemplate = page.FindResource(list[i].ResourceKey) as DataTemplate;
                            dataGrid.Columns.Insert(i + index, val);
                        }
                        break;
                }
            }
            if (!string.IsNullOrWhiteSpace(operationKey) && frameworkElement != null)
            {
                var resource = frameworkElement.FindResource(operationKey);
                if (resource != null)
                {

                    var col = new DataGridTemplateColumn() { Header = "操作", Width = operationWidth };
                    col.CellTemplate = resource as DataTemplate;
                    dataGrid.Columns.Add(col);
                }
            }
        }

        /// <summary>
        /// 获取数据源对象到列的映射关系
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static IList<BindDescriptionAttribute> GetColumns(object data)
        {
            List<BindDescriptionAttribute> list = new List<BindDescriptionAttribute>();
            var pros = data.GetType().GenericTypeArguments[0].GetProperties();
            foreach (var item in pros)
            {
                var a = item.GetCustomAttribute<BindDescriptionAttribute>();
                if (a != null) { a.PropertyName = item.Name; list.Add(a); }
            }
            return list.OrderBy(x => x.DisplayIndex).ToArray();
        }

        /// <summary>
        /// 查找父级控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T && ((T)parent).Name == name | string.IsNullOrEmpty(name))
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}