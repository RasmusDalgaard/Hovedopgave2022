﻿using EMSuiteVisualConfigurator.CoreBusiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Features.AccessPoints.Responses
{
    public class AccessPointResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Logger> Loggers { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
