﻿using InvertedTomato.TikLink.RosRecords;
using System;

namespace InvertedTomato.TikLink {
    public class LinkBridgeSettings {
        private readonly Link Link;

        internal LinkBridgeSettings(Link link) {
            Link = link;
        }

        public BridgeSettings Get(string[] properties = null) {
            throw new NotImplementedException(); // TODO
            //return Link.Get<BridgeFilter>(id, properties);
        }

        public void Put(BridgeSettings record, string[] properties = null) {
            throw new NotImplementedException(); // TODO
            //Link.Put(record, properties);
        }
    }
}
