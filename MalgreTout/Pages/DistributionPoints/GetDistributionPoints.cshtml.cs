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
    public class GetDistributionPointsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        IDistributionService distributionService { get; set; }
        public GetDistributionPointsModel(IDistributionService service)
        {
            distributionService = service;
        }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                DistributionPoints = distributionService.GetDistributionPoints(FilterCriteria);
            }
            else
                DistributionPoints = distributionService.GetDistributionPoints();
        }
    }
}
