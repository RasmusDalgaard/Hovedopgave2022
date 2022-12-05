﻿using EMSuiteVisualConfigurator.CoreBusiness.Primitives;

namespace EMSuiteVisualConfigurator.CoreBusiness.Entities
{
    public class Channel : Entity
    {
        public bool IsAuthorized { get; protected set; } = true;

        public int ChannelNumber { get; protected set; }

        public int ChannelType { get; protected set; }

        public Channel(bool isAuthorized, int temperature)
        {
            IsAuthorized = isAuthorized;
            Temperature = temperature;
        }
        public Channel()
        {

        }
    }
}