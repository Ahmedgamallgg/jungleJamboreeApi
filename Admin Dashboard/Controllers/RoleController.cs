using Admin_Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin_Dashboard.Controllers
{
    [Authorize]

    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if(ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Name);
                if(roleExists)
                {
                    ModelState.AddModelError("Name", "This role Already Exists");
                    return RedirectToAction("Index", await _roleManager.Roles.ToListAsync());
                }
                await _roleManager.CreateAsync(new IdentityRole { Name = model.Name.Trim() });
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", await _roleManager.Roles.ToListAsync());

        }
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var mappedRole = new RoleViewModel { Id = role.Id, Name= role.Name };
            return View(mappedRole);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Name);
                if (roleExists)
                {
                    ModelState.AddModelError("Name", "This role Already Exists");
                    return RedirectToAction("Index", await _roleManager.Roles.ToListAsync());
                }
                var role = await _roleManager.FindByIdAsync(model.Id);
                role.Name = model.Name.Trim();
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View(model);

        }

    }
}
