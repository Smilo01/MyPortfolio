using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using MyPortfolio.Data;
using Microsoft.EntityFrameworkCore;
namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Subject,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.SubmissionDate = DateTime.UtcNow;
                contact.IsRead = false;

                try
                {
                    await _unitOfWork.Contacts.AddAsync(contact);
                    await _unitOfWork.SaveChangesAsync();

                    // Set success message
                    TempData["SuccessMessage"] = "Thank you for your message! I'll get back to you soon.";

                    // Redirect to prevent form resubmission
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the error (you should implement proper logging)
                    ModelState.AddModelError("", "Unable to save your message. Please try again later.");
                }
            }

            // If we got this far, something failed, redisplay form
            TempData["ErrorMessage"] = "Please correct the errors and try again.";
            return View("Index", contact);
        }
    }
}
