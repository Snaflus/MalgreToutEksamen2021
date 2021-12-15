using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MalgreTout.Services.EFServices
{
    public class EFOpeningHourService : IOpeningHourService
    {
        MalgretoutContext context;
        public EFOpeningHourService(MalgretoutContext service)
        {
            context = service;
        }

        public void AddOpeningHour(OpeningHour openingHour)
        {
            context.OpeningHours.Add(openingHour);
            context.SaveChangesAsync();
        }

        public void DeleteOpeningHour(OpeningHour openingHour)
        {
            context.OpeningHours.Remove(openingHour);
            context.SaveChangesAsync();
        }

        public void UpdateOpeningHour(OpeningHour openingHour)
        {
            context.OpeningHours.Update(openingHour);
            context.SaveChangesAsync();
        }
    }
}
