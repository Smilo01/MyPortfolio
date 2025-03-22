using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _unitOfWork.Projects
               .GetAllAsync();
            return View(projects);
        }

        public async Task<ActionResult<Project>> GetProjectWithDetails(int id)
        {    
            var project = await _unitOfWork.Projects.GetProjectWithDetailsAsync(id);
            if (project == null)
                return NotFound();
           
            return View(project);
        }
       
    }
}
