using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.EFServices;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.Interfaces
{
    public interface IOpeningHourService
    {
        void AddOpeningHour(OpeningHour openingHour);
        void DeleteOpeningHour(OpeningHour openingHour);
        void UpdateOpeningHour(OpeningHour openingHour);
        OpeningHour GetOpeningHourByLocationId(int id);
        OpeningHour GetLastOpeningHour();
    }
}
