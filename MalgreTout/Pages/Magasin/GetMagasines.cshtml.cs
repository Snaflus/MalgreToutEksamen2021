using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MalgreTout.Models;
using MalgreTout.Services.Interfaces;

namespace MalgreTout.Pages.Magasin
{
    public class GetMagasinesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int FilterCriteria { get; set; }
        public IEnumerable<NoOfMagazine> Magazines { get; set; }
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        IMagasineService magasineService { get; set; }
        IDistributionService distributionService { get; set; }
        public GetMagasinesModel(IMagasineService service, IDistributionService service2)
        {
            magasineService = service;
            distributionService = service2;
        }
        public void OnGet()
        {
            DistributionPoints = distributionService.GetDistributionPoints();
            //FilterCriteriaString = FilterCriteria.ToString();
            //if (!String.IsNullOrEmpty(FilterCriteriaString))
            if(FilterCriteria != 0)
            {
                Magazines = magasineService.GetMagazines(FilterCriteria);
            }
            else
                Magazines = magasineService.GetMagazines();
        }
    }
}
