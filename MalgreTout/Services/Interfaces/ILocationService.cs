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
        IEnumerable<Lokationer> GetLocations(string filter);
        IEnumerable<Lokationer> GetLocations();
        void AddLocation(Lokationer location);
        void DeleteLocation(Lokationer location);
        Lokationer GetLocationById(int id);
    }
}
