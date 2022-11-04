﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGHIS.Core.Events
{
    public class CommonSaveEvent : PubSubEvent
    {
        public new ICollection<IEventSubscription> Subscriptions => base.Subscriptions;
    }
}
