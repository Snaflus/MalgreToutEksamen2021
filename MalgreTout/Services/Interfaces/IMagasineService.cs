using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.EFServices;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.Interfaces
{
    public interface IMagasineService
    {
        IEnumerable<NoOfMagazine> GetMagazines(int filter);
        IEnumerable<NoOfMagazine> GetMagazines();
        void AddMagasine(NoOfMagazine magasine);
        void DeleteMagasine(NoOfMagazine magasine);
        void UpdateMagasine(NoOfMagazine magasine);
        NoOfMagazine GetMagasineByLocationId(int id);
        NoOfMagazine GetMagazine(int id);
    }
}
