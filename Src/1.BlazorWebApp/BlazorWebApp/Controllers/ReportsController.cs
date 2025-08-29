using BlazorWebApp.Repositories;
using FastReport;
using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApp.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportGenerator _reportGenerator;

    public ReportsController(IReportGenerator reportGenerator)
    {
        _reportGenerator = reportGenerator;
    }
    [HttpGet("orders")]
    public IActionResult GetOrdersReport()
    {
        var reportBytes = _reportGenerator.GenerateOrdersReport();
        return File(reportBytes, "application/pdf", "orders_report.pdf");
    }

    [HttpGet("products")]
    public IActionResult GetProductsReport()
    {
        var reportBytes = _reportGenerator.GenerateProductsReport();
        return File(reportBytes, "application/pdf", "products_report.pdf");
    }

    [HttpGet("StaticReport")]
    public IActionResult GetStaticReport()
    {
        // Create a new report
        Report report = new Report();

        // Load a prepared template (optional)
        // report.Load("Reports/MyReport.frx");

        // Or bind static data manually
        var data = new[]
        {
                new { Id = 1, Name = "Alice", Age = 25 },
                new { Id = 2, Name = "Bob", Age = 30 },
                new { Id = 3, Name = "Charlie", Age = 28 }
            };

        report.RegisterData(data, "People");

        report.Prepare();

        // Export to PDF
        using var ms = new MemoryStream();
        PDFSimpleExport pdfExport = new PDFSimpleExport();
        report.Export(pdfExport, ms);
        ms.Position = 0;

        return File(ms.ToArray(), "application/pdf", "StaticReport.pdf");
    }
}


