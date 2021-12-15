using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.EFServices;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.Interfaces
{
    public interface IContactPeopleService
    {
        IEnumerable<Contactperson> GetContactPeople(int filter);
        IEnumerable<Contactperson> GetContactPeople();
        void AddContactperson(Contactperson contactperson);
        void DeleteContactperson(Contactperson contactperson);
        void UpdateContactperson(Contactperson contactperson);
        Contactperson GetContactpersonByContactId(int id);
        Contactperson GetContactpersonByLocationId(int id);
        Contactperson GetLastContactperson();
    }
}
