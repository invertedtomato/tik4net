﻿using InvertedTomato.TikLink.RosRecords;
using System;

namespace InvertedTomato.TikLink {
    public class LinkIpDhcpServerConfig {
        private readonly Link Link;

        internal LinkIpDhcpServerConfig(Link link) {
            Link = link;
        }

        public IpDhcpServerConfig Get(string[] properties = null) {
            return Link.Get<IpDhcpServerConfig>(properties);
        }

        public void Update(IpDhcpServerConfig record, string[] properties = null) {
            Link.Update(record, properties);
        }
    }
}
