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
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public NoOfMagazine Magazine { get; set; } = new NoOfMagazine();
        public DistributionPoint DistributionPoint { get; set; } = new DistributionPoint();
        public IEnumerable<DistributionPoint> DistributionPoints { get; set; }
        public void OnGet(int locationId, int id)
        {
            Magazine = magasineService.GetMagazine(id);
            DistributionPoint = distributionService.GetDistributionPointById(Magazine.LocationId);
        }
        IMagasineService magasineService;
        IDistributionService distributionService;
        public UpdateModel(IMagasineService service1, IDistributionService service2)
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
            magasineService.UpdateMagasine(Magazine);
            return RedirectToPage("GetMagasines");
        }
    }
}