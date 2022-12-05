﻿using EMSuiteVisualConfigurator.CoreBusiness.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Port : Entity
    {
        public List<Channel> Channels { get; set; } = new List<Channel>();
        public int SensorSerialNumber { get; protected set; }
        public DateTime CreateDate { get; protected set; } = DateTime.Now;
        public Port(List<Channel> channels, int sensorSerialNumber)
        {
            Channels = channels;
            SensorSerialNumber = sensorSerialNumber;
        }
        public Port()
        {
        }
    }
}
