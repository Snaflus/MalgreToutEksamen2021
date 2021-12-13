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
        
        IDistributionService distributionService;
       
        public DeleteModel(IDistributionService service)
        {
            this.distributionService = service;
            DistributionPoint = new DistributionPoint();
        }
        public void OnGet(int id)
        {
            DistributionPoint = distributionService.GetDistributionPointById(id);       
        }
        public IActionResult OnPost()
        {
            distributionService.DeleteDistributionPoint(DistributionPoint);

            return RedirectToPage("GetDistributionPoints");
        }
    }
}