using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManament.Mvc.Models;
using TaskManament.Mvc.Services;

namespace TaskManament.Mvc.Controllers
{


    [Authorize]
    public class TenantsController : Controller
    {
        public TenantService _tenantService;
        public TenantsController(TenantService tenantService) => _tenantService = tenantService;


        // GET: TenantController
        public async Task<IActionResult> Index()
        {
            var tenants = await _tenantService.GetTenantsAsync();
            return View(tenants);
        }

        // GET: TenantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TenantController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TenantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                var tenant = new Tenant
                {
                    TenantDescription = collection["TenantDescription"],
                    Date_Created = DateTime.Now,
                    Date_Modified = DateTime.Now
                };

                await _tenantService.CreateTenantAsync(tenant, User, new CancellationToken());

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
