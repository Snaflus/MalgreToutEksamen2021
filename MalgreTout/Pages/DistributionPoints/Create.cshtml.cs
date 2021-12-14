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
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        public void OnGet(int id)
        {
            DistributionPoints = distributionService.GetDistributionPoints();
            DistributionPoint.LocationId = id;
        }
        IDistributionService distributionService;
        public CreateModel(IDistributionService service)
        {
            this.distributionService = service;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            distributionService.AddDistributionPoint(DistributionPoint);
            return RedirectToPage("GetDistributionPoints");
        }
    }
}