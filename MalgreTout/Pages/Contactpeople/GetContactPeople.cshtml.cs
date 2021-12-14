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
        IDistributionService distributionService { get; set; }
        public GetContactPeopleModel(IDistributionService service)
        {
            distributionService = service;
        }
        public void OnGet(int id)
        {
            DistributionPoints = distributionService.GetDistributionPointsId(id);
        }
    }
}
