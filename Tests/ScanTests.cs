﻿using InvertedTomato.TikLink;
using InvertedTomato.TikLink.Records;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Tests {
    public class ScanTests {
        [Fact]
        public void Scan_Interfaces() {
            using (var link = Link.Connect(Credentials.Current.Host, Credentials.Current.Username, Credentials.Current.Password)) {
                var interfaces = link.Scan<Interface>();
                Assert.True(interfaces.Count > 1);

                var eth1 = interfaces.Single(a => a.DefaultName == "ether1");
                Assert.Equal("*1", eth1.Id);
                Assert.Equal("ether", eth1.Type);
            }
        }


        [Fact]
        public void Scan_IpArp() {
            using (var link = Link.Connect(Credentials.Current.Host, Credentials.Current.Username, Credentials.Current.Password)) {
                var ipArt = link.Scan<IpArp>();
                Assert.True(ipArt.Count >= 1);
            }
        }
    }
}
