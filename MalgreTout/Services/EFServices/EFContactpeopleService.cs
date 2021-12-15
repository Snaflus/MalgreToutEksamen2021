using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.EFServices
{
    public class EFContactpeopleService : IContactPeopleService
    {
        MalgretoutContext context;
        public EFContactpeopleService(MalgretoutContext service)
        {
            context = service;
        }

        public IEnumerable<Contactperson> GetContactPeople(int filter)
        {
            return context.Contactpeople
                .Include(f => f.Location.OpeningHours)
                .Include(c => c.Location).Where(s => s.LocationId.Equals(filter)).AsNoTracking().ToList();
        }

        public IEnumerable<Contactperson> GetContactPeople()
        {
            context.Contactpeople
                .Include(f => f.Location.OpeningHours)
                .Include(s => s.Location);
            return context.Contactpeople;

        }

        public void AddContactperson(Contactperson contactperson)
        {
            context.Contactpeople.Add(contactperson);
            context.SaveChangesAsync();
        }

        public void DeleteContactperson(Contactperson contactperson)
        {
            context.Contactpeople.Remove(contactperson);
            context.SaveChangesAsync();
        }

        public void UpdateContactperson(Contactperson contactperson)
        {
            context.Contactpeople.Update(contactperson);
            context.SaveChangesAsync();
        }

        public Contactperson GetContactpersonByContactId(int id)
        {
            Contactperson contactperson = context.Contactpeople
                .Include(f => f.Location.OpeningHours)
                .Include(s => s.Location)
                .AsNoTracking()
                .FirstOrDefault(m => m.ContactId == id);
            return contactperson;
        }

        public Contactperson GetContactpersonByLocationId(int id)
        {
            //return context.DistributionPoints.Find(id);
            Contactperson contactperson = context.Contactpeople
                .Include(f => f.Location.OpeningHours)
                .Include(s => s.Location)
                .AsNoTracking()
                .FirstOrDefault(m => m.LocationId == id);
            return contactperson;
        }
        public Contactperson GetLastContactperson()
        {
            return context.Contactpeople.OrderBy(i => i.ContactId).Last();
        }
    }
}
