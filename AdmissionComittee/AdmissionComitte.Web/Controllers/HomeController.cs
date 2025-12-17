using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdmissionComitte.Web.Models;
using AdmissionComittee.Entities;
using Services.Contracts;

namespace AdmissionComitte.Web.Controllers;

/// <summary>
/// Контроллер
/// </summary>
public class HomeController : Controller
{
    private readonly IApplicantManager applicantManager;

    /// <summary>
    /// Конструктор контроллера
    /// </summary>
    public HomeController(IApplicantManager applicantManager)
    {
        this.applicantManager = applicantManager;
    }

    /// <summary>
    /// Страница с гридом
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var model = new MainModel
        {
            Applicants = await applicantManager.GetAll(cancellationToken),
            Statistics = await applicantManager.GetStatistics(cancellationToken)
        };
        return View(model);
    }

    /// <summary>
    /// Страница политики
    /// </summary>
    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Страница обновления студентов
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> EditStudentPage(Guid applicantId, CancellationToken cancellationToken)
    {
        var applicant = await applicantManager.GetById(applicantId, cancellationToken);
        if (applicant is null)
        {
            return NotFound();
        }
        return View(nameof(AddStudentPage), applicant);
    }

    /// <summary>
    /// Получить страницу добавления абитуриентов
    /// </summary>
    [HttpGet]
    public IActionResult AddStudentPage()
    {
        return View();
    }

    /// <summary>
    /// Удалить абитуриента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Delete(Guid applicantId, CancellationToken cancellationToken)
    {
        await applicantManager.Delete(applicantId, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Обновить абитуриента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Update(Applicant applicant, CancellationToken cancellationToken)
    {
        await applicantManager.Update(applicant, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Создать абитуриента
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create(Applicant applicant, CancellationToken cancellationToken)
    {
        await applicantManager.Add(applicant, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Ошибка
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
