﻿using InvertedTomato.TikLink.RosRecords;
using System.Collections.Generic;
using System;

namespace InvertedTomato.TikLink {
    public class LinkIpArp {
        private readonly Link Link;

        internal LinkIpArp(Link link) {
            Link = link;
        }

        public IList<IpArp> List(string[] properties = null, Dictionary<string, string> filter = null) {
            return Link.List<IpArp>(properties, filter);
        }

        public IpArp Get(string id, string[] properties = null) {
            return Link.Get<IpArp>(id, properties);
        }

        public void Put(IpArp record, string[] properties = null) {
            Link.Put(record, properties);
        }
        
        public void Delete(string id) {
            Link.Delete<IpArp>(id);
        }

        public void Delete(IpArp record) {
            Link.Delete(record);
        }
    }
}
