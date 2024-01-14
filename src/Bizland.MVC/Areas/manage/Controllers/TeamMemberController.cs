using Bizland.Core.Entities;
using Bziland.Business.Exceptions.TeamMemberExceptions;
using Bziland.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bizland.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _teamMemberService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return View(teamMember);
            }
            try
            {
                await _teamMemberService.CreateAsync(teamMember);

            }
            catch(TeamMemberInvalidImageFileException ex) 
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View(teamMember);
            }
            catch (NullReferenceException ex)
            {
              
                return View("error");
            }

            catch (Exception ex)
            {

                ModelState.AddModelError("",ex.Message);
                return View(teamMember);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
    