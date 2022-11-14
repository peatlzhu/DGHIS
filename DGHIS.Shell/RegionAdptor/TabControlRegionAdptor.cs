using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace DGHIS.Shell.RegionAdptor
{
    public class TabControlRegionAdptor : RegionAdapterBase<HandyControl.Controls.TabControl>
    {
        public TabControlRegionAdptor(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }
        protected override void Adapt(IRegion region,HandyControl.Controls.TabControl regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {                     
                        Page page=element as Page;
                        HandyControl.Controls.TabItem tabItem = regionTarget.Items.OfType<HandyControl.Controls.TabItem>().FirstOrDefault(item => item.Header?.ToString() == page.Title);
                        if (tabItem == null)
                        {
                            tabItem = new HandyControl.Controls.TabItem()
                            {
                                Header = page.Title,
                            };
                            var pageFrame = new Frame();
                            pageFrame.Focusable = false;
                            pageFrame.BorderThickness = new Thickness(0);
                            pageFrame.Margin = new Thickness(20);
                            pageFrame.Navigate(element);
                            tabItem.Content = pageFrame;
                            regionTarget.Items.Add(tabItem);
                        }
                        regionTarget.SelectedItem = tabItem; 
                    }
                }

                //handle remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
