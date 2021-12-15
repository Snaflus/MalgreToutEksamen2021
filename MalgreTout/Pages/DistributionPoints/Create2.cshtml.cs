using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;

namespace MalgreTout.Pages.DistributionPoints
{
    public class Create2Model : PageModel
    {
        [BindProperty]
        public DistributionPoint DistributionPoint { get; set; } = new DistributionPoint();
        public Contactperson Contactperson { get; set; } = new Contactperson();
        public OpeningHour OpeningHour { get; set; } = new OpeningHour();
        public void OnGet()
        {
            DistributionPoint = distributionService.GetLastDistributionPoint();
            Contactperson.LocationId = DistributionPoint.LocationId;
            contactPeopleService.AddContactperson(Contactperson);
            OpeningHour.LocationId = DistributionPoint.LocationId;
            openingHourService.AddOpeningHour(OpeningHour);
        }
        IDistributionService distributionService;
        IContactPeopleService contactPeopleService;
        IOpeningHourService openingHourService;
        public Create2Model(IDistributionService service1, IContactPeopleService service2, IOpeningHourService service3)
        {
            this.distributionService = service1;
            this.contactPeopleService = service2;
            this.openingHourService = service3;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            contactPeopleService.UpdateContactperson(Contactperson);
            openingHourService.UpdateOpeningHour(OpeningHour);
            return RedirectToPage("GetDistributionPoints");
        }
    }
}