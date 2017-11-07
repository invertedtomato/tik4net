﻿namespace InvertedTomato.TikLink {
    public class LinkIp {
        public readonly LinkIpArp Arp;
        public readonly LinkIpDhcpServer DhcpServer;

        private readonly Link Link;

        internal LinkIp(Link link) {
            Link = link;

            Arp = new LinkIpArp(Link);
            DhcpServer = new LinkIpDhcpServer(Link);
        }
    }
}
