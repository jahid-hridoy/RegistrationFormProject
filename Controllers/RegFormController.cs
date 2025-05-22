using Microsoft.AspNetCore.Mvc;
using RegistrationFormProject.Data;
using RegistrationFormProject.Models;

namespace RegistrationFormProject.Controllers;

public class RegFormController : Controller
{
    private readonly RegFormDbContext _context;
    
    public RegFormController(RegFormDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(RegForm RegData)
    {
        if (ModelState.IsValid)
        {
            _context.RegForms.Add(RegData);
            await _context.SaveChangesAsync();

            var emailService = new EmailService();
            await emailService.SendRegistrationEmailAsync(RegData.Email, RegData.Name);

            return RedirectToAction("Index");
        }

        return View(RegData); // re-render the form with validation errors
    }
}