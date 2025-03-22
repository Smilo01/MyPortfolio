using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Data;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Projects
        
        public async Task<IActionResult> Index()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();

            return View();

            //var allProjects = await _unitOfWork.Projects.GetAllAsync();

            //var featuredProjects = allProjects.Where(p => p.IsFeatured).ToList();

        }

        // GET: Admin/Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _unitOfWork.Projects.GetProjectWithDetailsAsync(id.Value);


            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        //// GET: Admin/Projects/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        //    ViewData["Skills"] = _context.Skills.OrderBy(s => s.Name).ToList();


        //    return View();
        //}

        //// POST: Admin/Projects/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Project project, int[] selectedSkills)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Handle image upload
        //        if (project.ImageFile != null)
        //        {
        //            string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/projects");
        //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + project.ImageFile.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            // Ensure directory exists
        //            Directory.CreateDirectory(uploadsFolder);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await project.ImageFile.CopyToAsync(fileStream);
        //            }

        //            project.ImagePath = "/images/projects/" + uniqueFileName;
        //        }

        //        // Set dates
        //        project.CreatedDate = DateTime.UtcNow;
        //        project.LastModifiedDate = DateTime.UtcNow;

        //        // Save project first to get ID
        //        _context.Add(project);
        //        await _context.SaveChangesAsync();

        //        // Add selected skills
        //        if (selectedSkills != null && selectedSkills.Length > 0)
        //        {
        //            foreach (var skillId in selectedSkills)
        //            {
        //                _context.Add(new ProjectSkill { ProjectId = project.Id, SkillId = skillId });
        //            }
        //            await _context.SaveChangesAsync();
        //        }

        //        TempData["SuccessMessage"] = "Project created successfully!";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    // If we got this far, something failed, redisplay form
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", project.CategoryId);
        //    ViewData["Skills"] = _context.Skills.OrderBy(s => s.Name).ToList();

        //    return View(project);
        //}

        //// GET: Admin/Projects/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects
        //        .Include(p => p.ProjectSkills)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", project.CategoryId);

        //    var allSkills = _context.Skills.OrderBy(s => s.Name).ToList();
        //    ViewData["Skills"] = allSkills;

        //    var selectedSkills = project.ProjectSkills?.Select(ps => ps.SkillId).ToList() ?? new List<int>();
        //    ViewData["SelectedSkills"] = selectedSkills;

        //    return View(project);
        //}

        //// POST: Admin/Projects/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Project project, int[] selectedSkills)
        //{
        //    if (id != project.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Get existing project to update
        //            var existingProject = await _context.Projects
        //                .Include(p => p.ProjectSkills)
        //                .FirstOrDefaultAsync(p => p.Id == id);

        //            if (existingProject == null)
        //            {
        //                return NotFound();
        //            }

        //            // Handle image upload
        //            if (project.ImageFile != null)
        //            {
        //                // Delete old image if exists
        //                if (!string.IsNullOrEmpty(existingProject.ImagePath))
        //                {
        //                    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, existingProject.ImagePath.TrimStart('/'));
        //                    if (System.IO.File.Exists(oldImagePath))
        //                    {
        //                        System.IO.File.Delete(oldImagePath);
        //                    }
        //                }

        //                // Save new image
        //                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images/projects");
        //                string uniqueFileName = Guid.NewGuid().ToString() + "_" + project.ImageFile.FileName;
        //                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //                Directory.CreateDirectory(uploadsFolder);

        //                using (var fileStream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    await project.ImageFile.CopyToAsync(fileStream);
        //                }

        //                existingProject.ImagePath = "/images/projects/" + uniqueFileName;
        //            }

        //            // Update project properties
        //            existingProject.Title = project.Title;
        //            existingProject.Description = project.Description;
        //            existingProject.LiveUrl = project.LiveUrl;
        //            existingProject.SourceUrl = project.SourceUrl;
        //            existingProject.IsFeatured = project.IsFeatured;
        //            existingProject.DisplayOrder = project.DisplayOrder;
        //            existingProject.CategoryId = project.CategoryId;
        //            existingProject.LastModifiedDate = DateTime.UtcNow;

        //            // Update skills (remove and add as needed)
        //            if (existingProject.ProjectSkills != null)
        //            {
        //                _context.RemoveRange(existingProject.ProjectSkills);
        //            }

        //            if (selectedSkills != null)
        //            {
        //                foreach (var skillId in selectedSkills)
        //                {
        //                    _context.Add(new ProjectSkill { ProjectId = existingProject.Id, SkillId = skillId });
        //                }
        //            }

        //            await _context.SaveChangesAsync();
        //            TempData["SuccessMessage"] = "Project updated successfully!";
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectExists(project.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", project.CategoryId);
        //    ViewData["Skills"] = _context.Skills.OrderBy(s => s.Name).ToList();
        //    ViewData["SelectedSkills"] = selectedSkills?.ToList() ?? new List<int>();

        //    return View(project);
        //}

        //// GET: Admin/Projects/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var project = await _context.Projects
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(project);
        //}

        //// POST: Admin/Projects/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var project = await _context.Projects
        //        .Include(p => p.ProjectSkills)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    // Delete associated image file
        //    if (!string.IsNullOrEmpty(project.ImagePath))
        //    {
        //        var imagePath = Path.Combine(_hostEnvironment.WebRootPath, project.ImagePath.TrimStart('/'));
        //        if (System.IO.File.Exists(imagePath))
        //        {
        //            System.IO.File.Delete(imagePath);
        //        }
        //    }

        //    // Remove project and all associated ProjectSkills
        //    _context.Projects.Remove(project);
        //    await _context.SaveChangesAsync();

        //    TempData["SuccessMessage"] = "Project deleted successfully!";
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProjectExists(int id)
        //{
        //    return _unitOfWork.Projects.FindAsync(id);
        //}
    }
}
