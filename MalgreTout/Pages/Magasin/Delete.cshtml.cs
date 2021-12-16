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
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public NoOfMagazine Magazine { get; set; }
        [BindProperty]
        public DistributionPoint DistributionPoint { get; set; }
        IMagasineService magasineService;
        IDistributionService distributionService;
        public DeleteModel(IMagasineService service1, IDistributionService service2)
        {
            this.magasineService = service1;
            this.distributionService = service2;
            Magazine = new NoOfMagazine();
        }
        public void OnGet(int id)
        {
            DistributionPoint = distributionService.GetDistributionPointById(id);
            Magazine = magasineService.GetMagasineByLocationId(id);
        }
        public IActionResult OnPost()
        {
            magasineService.DeleteMagasine(Magazine);

            return RedirectToPage("GetMagasines");
        }
    }
}