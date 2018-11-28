
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using her_care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

    namespace her_care.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HerCareContext context;
        public IndexModel(HerCareContext context)
        {
            this.context = context;
        }
        public async Task OnGet()
        {
            /*
            // How to Search
            var users = context.Tests.Where(x => x.Name == "Sean").OrderBy(x => x.Id);
            var user = context.Tests.FirstOrDefault(x => x.Name == "Sean");

            //How to add New Data
            var m1 = new Test();
            m1.Name = "Some New Cool Thing";
            var models = context.Tests.Add(m1);

            await context.SaveChangesAsync();
            */
        }

        // public ActionResult Intake(){
        //     return View();
        // }
            
        


    }
}
