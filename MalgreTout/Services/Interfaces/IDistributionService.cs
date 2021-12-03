﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.EFServices;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.Interfaces
{
    public interface IDistributionService
    {
        IEnumerable<DistributionPoint> GetDistributionPoints(string filter);
        IEnumerable<DistributionPoint> GetDistributionPoints();
        void AddDistributionPoint(DistributionPoint distributionPoint);
        void DeleteDistributionPoint(DistributionPoint distributionPoint);
        void UpdateDistributionPoint(DistributionPoint oldDistributionPoint, DistributionPoint newDistributionPoint);
        DistributionPoint GetDistributionPointById(int id);
    }
}