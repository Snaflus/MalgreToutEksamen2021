using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.EFServices
{
    public class EFMagasineService : IMagasineService
    {
        MalgretoutContext context;
        public EFMagasineService(MalgretoutContext service)
        {
            context = service;
        }
        public IEnumerable<NoOfMagazine> GetMagazines(int filter)
        {
            return context.NoOfMagazines                
                .Include(s => s.Location)
                .Include(c => c.Location.Contactpeople)
                .Include(v => v.Location.ZipcodeNavigation)
                .Include(i => i.Location.OpeningHours)
                .Where(s => s.MagazineIssue.Equals(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<NoOfMagazine> GetMagazines()
        {
            return context.NoOfMagazines
                .Include(s => s.Location)
                .Include(c => c.Location.Contactpeople)
                .Include(v => v.Location.ZipcodeNavigation)
                .Include(i => i.Location.OpeningHours);
        }
        public void AddMagasine(NoOfMagazine magasine)
        {
            context.NoOfMagazines.Add(magasine);
            context.SaveChanges();
        }

        public void DeleteMagasine(NoOfMagazine magasine)
        {
            context.NoOfMagazines.Remove(magasine);
            context.SaveChanges();
        }

        public void UpdateMagasine(NoOfMagazine magasine)
        {
            context.NoOfMagazines.Update(magasine);
            context.SaveChanges();
        }

        public NoOfMagazine GetMagasineByLocationId(int id)
        {
            NoOfMagazine magazine = context.NoOfMagazines
                .Include(s => s.Location)
                .Include(c => c.Location.Contactpeople)
                .Include(v => v.Location.ZipcodeNavigation)
                .Include(i => i.Location.OpeningHours)
                .AsNoTracking()
                .FirstOrDefault(m => m.LocationId == id);
            return magazine;
        }

        public NoOfMagazine GetMagazine(int id)
        {
            NoOfMagazine magazine = context.NoOfMagazines
                .Include(s => s.Location)
                .Include(c => c.Location.Contactpeople)
                .Include(v => v.Location.ZipcodeNavigation)
                .Include(i => i.Location.OpeningHours)
                .AsNoTracking()
                .FirstOrDefault(m => m.MagasineId == id);
            return magazine;
        }
    }
}
