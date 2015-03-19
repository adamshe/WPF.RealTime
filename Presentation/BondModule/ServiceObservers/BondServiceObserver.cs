﻿using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using WPF.RealTime.Data;
using WPF.RealTime.Data.Entities;
using WPF.RealTime.Data.ResourceManager;
using WPF.RealTime.Infrastructure;
using WPF.RealTime.Infrastructure.Interfaces;
using WPF.RealTime.Infrastructure.Messaging;

namespace BondModule.ServiceObservers
{
    [Export(typeof(BaseServiceObserver))]
    public class BondServiceObserver : BaseServiceObserver
    {
        public BondServiceObserver()
        {
            AddEventExploder(EventExploder);
        }

        public override void AddServicesToObserve(IEnumerable<IService> services)
        {
            //pass filter
            base.AddServicesToObserve(services.Where(s => s.AssetType == AssetType.Bond));
        }

        public void EventExploder(IEnumerable<Entity> messages)
        {
            // apply rules
            RuleEngine.ApplyRules(messages);

            // broadcast news or updates using Mediator EventExploder
            Mediator.GetInstance.Broadcast(Topic.BondServiceDataReceived, messages); 
        }
    }
}
