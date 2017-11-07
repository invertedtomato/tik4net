﻿using InvertedTomato.TikLink.RosRecords;
using System.Collections.Generic;
using System;

namespace InvertedTomato.TikLink {
    public class LinkFirewallFilter {
        private readonly Link Link;

        internal LinkFirewallFilter(Link link) {
            Link = link;
        }

        public IList<IpFirewallFilter> List(string[] properties = null, Dictionary<string, string> filter = null) {
            return Link.List<IpFirewallFilter>(properties, filter);
        }

        public IpFirewallFilter Get(string id, string[] properties = null) {
            return Link.Get<IpFirewallFilter>(id, properties);
        }

        public void Put(IpFirewallFilter record, string[] properties = null) {
            Link.Put(record, properties);
        }

        public void Delete(string id) {
            Link.Delete<IpFirewallFilter>(id);
        }

        public void Delete(IpFirewallFilter record) {
            Link.Delete(record);
        }
    }
}
