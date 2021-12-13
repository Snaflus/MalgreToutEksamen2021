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
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public DistributionPoint DistributionPoint { get; set; } = new DistributionPoint();
        public void OnGet(int id)
        {
            DistributionPoint = distributionService.GetDistributionPointById(id);
        }
        IDistributionService distributionService;
        public UpdateModel(IDistributionService service)
        {
            this.distributionService = service;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            distributionService.UpdateDistributionPoint(DistributionPoint);
            return RedirectToPage("GetDistributionPoints");
        }
    }
}