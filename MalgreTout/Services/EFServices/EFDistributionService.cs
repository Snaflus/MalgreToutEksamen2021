using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.EFServices
{
    public class EFDistributionService : IDistributionService
    {
        MalgretoutContext context;
        public EFDistributionService(MalgretoutContext service)
        {
            context = service;
        }

        public IEnumerable<DistributionPoint> GetDistributionPoints(string filter)
        {
            return context.DistributionPoints
                .Include(s => s.ZipcodeNavigation)
                .Include(c => c.OpeningHours)
                .Include(v => v.Contactpeople)
                .Where(s => s.Company.ToUpper().Contains(filter.ToUpper())).AsNoTracking().ToList();
        }

        public IEnumerable<DistributionPoint> GetDistributionPointsId(int filter)
        {
            return context.DistributionPoints
                .Include(s => s.ZipcodeNavigation)
                .Include(c => c.OpeningHours)
                .Include(v => v.Contactpeople)
                .Where(s => s.LocationId.Equals(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<DistributionPoint> GetDistributionPoints()
        {
            return context.DistributionPoints
                .Include(s => s.ZipcodeNavigation)
                .Include(c => c.OpeningHours)
                .Include(v => v.Contactpeople);
        }

        public void AddDistributionPoint(DistributionPoint distributionPoint)
        {
            context.DistributionPoints.Add(distributionPoint);
            context.SaveChangesAsync();
        }

        public void DeleteDistributionPoint(DistributionPoint distributionPoint)
        {
            context.DistributionPoints.Remove(distributionPoint);
            context.SaveChangesAsync();
        }

        public void UpdateDistributionPoint(DistributionPoint distributionPoint)
        {
            context.DistributionPoints.Update(distributionPoint);
            context.SaveChangesAsync();
        }

        public DistributionPoint GetDistributionPointById(int id)
        {
            //return context.DistributionPoints.Find(id);
            DistributionPoint distributionPoint = context.DistributionPoints
                .Include(s => s.ZipcodeNavigation)
                .Include(c => c.OpeningHours)
                .Include(v => v.Contactpeople)
                .AsNoTracking()
                .FirstOrDefault(m => m.LocationId == id);
            return distributionPoint;
        }

        public DistributionPoint GetLastDistributionPoint()
        {
            return context.DistributionPoints.OrderBy(i => i.LocationId).Last();
        }
    }
}
