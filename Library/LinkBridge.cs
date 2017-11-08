﻿using InvertedTomato.TikLink.RosRecords;
using System;

namespace InvertedTomato.TikLink {
    public class LinkBridge {
        public readonly LinkBridgeFilter Filter;
        public readonly LinkBridgeNat Nat;
        public readonly LinkBridgePort Port;

        private readonly Link Link;

        internal LinkBridge(Link link) {
            Link = link;

            Filter = new LinkBridgeFilter(Link);
            Nat = new LinkBridgeNat(Link);
            Port = new LinkBridgePort(Link);
        }

        public BridgeSettings GetSettings() {
            throw new NotImplementedException();
        }
    }
}
