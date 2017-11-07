﻿using InvertedTomato.TikLink.RosRecords;
using System.Collections.Generic;

namespace InvertedTomato.TikLink {
    public class LinkIpDhcpServerNetwork {
        private readonly Link Link;

        internal LinkIpDhcpServerNetwork(Link link) {
            Link = link;
        }

        public IList<IpDhcpServerNetwork> List(string[] properties = null, Dictionary<string, string> filter = null) {
            return Link.List<IpDhcpServerNetwork>(properties, filter);
        }

        public IpDhcpServerNetwork Get(string id, string[] properties = null) {
            return Link.Get<IpDhcpServerNetwork>(id, properties);
        }

        public void Put(IpDhcpServerNetwork record, string[] properties = null) {
            Link.Put(record, properties);
        }

        public void Delete(string id) {
            Link.Delete<IpDhcpServerNetwork>(id);
        }
    }
}
