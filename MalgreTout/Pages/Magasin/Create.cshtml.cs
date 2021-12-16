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
    public class CreateModel : PageModel
    {
        [BindProperty]
        public NoOfMagazine Magazine { get; set; } = new NoOfMagazine();
        public DistributionPoint DistributionPoint { get; set; } = new DistributionPoint();
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        public void OnGet(int id)
        {
            DistributionPoints = distributionService.GetDistributionPoints();
            Magazine.MagasineId = id; 
        }
        IMagasineService magasineService;
        IDistributionService distributionService;
        public CreateModel(IMagasineService service1, IDistributionService service2)
        {
            this.magasineService = service1;
            this.distributionService = service2;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            magasineService.AddMagasine(Magazine);
            return RedirectToPage("GetMagasines");
        }
    }
}