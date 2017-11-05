﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvertedTomato.TikLink.RosRecords {
    /// <summary>
    /// ip/arp: Even though IP packets are addressed using  IP addresses, hardware addresses must be used to actually transport data from one host to another.Address Resolution Protocol is used to map OSI level 3 IP addresses to OSI level 2 MAC addreses. Router has a table of currently used ARP entries.Normally the table is built dynamically, but to increase network security, it can be partialy or completely built statically by means of adding static entries.
    /// </summary>
    [RosRecord("/ip/arp")]
    public class IpArp : IHasId {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [RosProperty(".id", RosDataType.Id, IsRequired = true)]
        public string Id { get; set; }

        /// <summary>
        /// IP Address
        /// </summary>
        [RosProperty("address", RosDataType.String)]
        public string Address { get; set; }

        /// <summary>
        /// Interface name the IP address is assigned to
        /// </summary>
        [RosProperty("interface", RosDataType.String)]
        public string Interface { get; set; }

        /// <summary>
        /// MAC address to be mapped to
        /// </summary>
        [RosProperty("mac-address", RosDataType.MacAddress, DefaultValue = "00:00:00:00:00:00")]
        public string MacAddress { get; set; }

        /// <summary>
        /// IP Address
        /// </summary>
        [RosProperty("comment", RosDataType.String)]
        public string Comment { get; set; }

        /// <summary>
        /// Whether ARP entry is added by DHCP server
        /// </summary>
        [RosProperty("dhcp", RosDataType.Boolean, IsReadOnly = true)]
        public bool Dhcp { get; private set; }

        /// <summary>
        /// Whether entry is dynamically created
        /// </summary>
        [RosProperty("dynamic", RosDataType.Boolean, IsReadOnly = true)]
        public bool Dynamic { get; private set; }

        /// <summary>
        /// Whether entry is not valid
        /// </summary>
        [RosProperty("invalid", RosDataType.Boolean, IsReadOnly = true)]
        public bool Invalid { get; private set; }
    }

}