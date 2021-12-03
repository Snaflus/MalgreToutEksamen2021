using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.EFServices
{
    public class EFLocationService:ILocationService
    {
        MalgretoutContext context;
        public EFLocationService(MalgretoutContext service)
        {
            context = service;
        }

        public IEnumerable<DistributionPoint> GetLocations(string filter)
        {
            return this.context.Set<DistributionPoint>().Where(s => s.Company.StartsWith(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<DistributionPoint> GetLocations()
        {
            return context.DistributionPoints;
        }

        public void AddLocation(DistributionPoint location)
        {
            context.DistributionPoints.Add(location);
            context.SaveChangesAsync();
        }

        public void DeleteLocation(DistributionPoint location)
        {
            context.DistributionPoints.Remove(location);
            context.SaveChangesAsync();
        }

        public DistributionPoint GetLocationById(int id)
        {
            return context.DistributionPoints.Find(id);
        }

    }
}
