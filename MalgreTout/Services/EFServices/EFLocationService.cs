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

        public IEnumerable<Lokationer> GetLocations(string filter)
        {
            return this.context.Set<Lokationer>().Where(s => s.Firmanavn.StartsWith(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<Lokationer> GetLocations()
        {
            return context.Lokationers;
        }

        public void AddLocation(Lokationer location)
        {
            context.Lokationers.Add(location);
            context.SaveChangesAsync();
        }

        public void DeleteLocation(Lokationer location)
        {
            context.Lokationers.Remove(location);
            context.SaveChangesAsync();
        }

        public Lokationer GetLocationById(int id)
        {
            return context.Lokationers.Find(id);
        }

    }
}
