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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public DistributionPoint DistributionPoint { get; set; } = new DistributionPoint();
        public Contactperson Contactperson { get; set; } = new Contactperson();
        public void OnGet(int id)
        {
            DistributionPoint.LocationId = id;
        }
        IDistributionService distributionService;
        IContactPeopleService contactPeopleService;
        public CreateModel(IDistributionService service, IContactPeopleService service2)
        {
            this.distributionService = service;
            this.contactPeopleService = service2;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            contactPeopleService.AddContactperson(Contactperson);
            distributionService.AddDistributionPoint(DistributionPoint);
            return RedirectToPage("GetDistributionPoints");
        }
    }
}