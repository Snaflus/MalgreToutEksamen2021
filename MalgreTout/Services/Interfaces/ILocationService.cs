using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.EFServices;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<DistributionPoint> GetLocations(string filter);
        IEnumerable<DistributionPoint> GetLocations();
        void AddLocation(DistributionPoint location);
        void DeleteLocation(DistributionPoint location);
        DistributionPoint GetLocationById(int id);
    }
}
