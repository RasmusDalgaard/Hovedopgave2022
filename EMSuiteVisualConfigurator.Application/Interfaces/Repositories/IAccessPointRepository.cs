﻿using EMSuiteVisualConfigurator.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSuiteVisualConfigurator.Application.Interfaces.Repositories
{
    public interface IAccessPointRepository : IRepository<AccessPoint>
    {
        public Task<IEnumerable<AccessPoint>> GetAllAccessPoints();

    }
}
