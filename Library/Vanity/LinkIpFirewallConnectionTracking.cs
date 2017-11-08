﻿using InvertedTomato.TikLink.Records;
using System;

namespace InvertedTomato.TikLink.Vanity {
    public class LinkIpFirewallConnectionTracking {
        private readonly Link Link;

        internal LinkIpFirewallConnectionTracking(Link link) {
            Link = link;
        }

        public IpFirewallConnectionTracking Get(string[] properties = null) {
            return Link.Get<IpFirewallConnectionTracking>(properties);
        }

        public void Update(IpFirewallConnectionTracking record, string[] properties = null) {
            Link.Update(record, properties);
        }
    }
}