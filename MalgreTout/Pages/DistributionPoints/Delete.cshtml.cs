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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public DistributionPoint DistributionPoint { get; set; }
        [BindProperty]
        public Contactperson Contactperson { get; set; }
        [BindProperty]
        public OpeningHour OpeningHour { get; set; }
        IDistributionService distributionService;
        IContactPeopleService contactPeopleService;
        IOpeningHourService openingHourService;
        public DeleteModel(IDistributionService service1, IContactPeopleService service2, IOpeningHourService service3)
        {
            this.distributionService = service1;
            this.contactPeopleService = service2;
            this.openingHourService = service3;
            DistributionPoint = new DistributionPoint();
        }
        public void OnGet(int id)
        {
            DistributionPoint = distributionService.GetDistributionPointById(id);
            Contactperson = contactPeopleService.GetContactpersonByLocationId(id);
            OpeningHour = openingHourService.GetOpeningHourByLocationId(id);
        }
        public IActionResult OnPost()
        {
            distributionService.DeleteDistributionPoint(DistributionPoint);

            return RedirectToPage("GetDistributionPoints");
        }
    }
}