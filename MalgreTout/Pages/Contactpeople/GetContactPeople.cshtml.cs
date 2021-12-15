using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;

namespace MalgreTout.Pages.Contactpeople
{
    public class GetContactPeopleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        public IEnumerable<Contactperson> Contactpeople { get; set; }
        IDistributionService distributionService { get; set; }
        IContactPeopleService contactPeopleService { get; set; }
        public GetContactPeopleModel(IDistributionService service, IContactPeopleService service2)
        {
            this.distributionService = service;
            this.contactPeopleService = service2;
        }
        public void OnGet(int id)
        {
            Contactpeople = contactPeopleService.GetContactPeople(id);
            DistributionPoints = distributionService.GetDistributionPointsId(id);
        }
    }
}
