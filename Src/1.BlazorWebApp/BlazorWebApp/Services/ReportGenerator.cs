using BlazorWebApp.Repositories;
using FastReport;
//using FastReport.Export.Pdf;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using System.Drawing;

namespace BlazorWebApp.Services;

public class ReportGenerator : IReportGenerator
{
    private readonly IReportDataService _dataService;

    public ReportGenerator(IReportDataService dataService)
    {
        _dataService = dataService;
    }

    public byte[] GenerateOrdersReport()
    {
        using var report = new Report();

        // Register data
        report.RegisterData(_dataService.GetOrders(), "Orders");
        report.RegisterData(_dataService.GetProducts(), "Products");

        // Design a simple report programmatically
        DesignSimpleReport(report);

        report.Prepare();

        using var ms = new MemoryStream();
        // Use PDFExport instead of PDFExport
        report.Export(new PDFSimpleExport(), ms);
        return ms.ToArray();
    }

    public byte[] GenerateProductsReport()
    {
        using var report = new Report();

        report.RegisterData(_dataService.GetProducts(), "Products");

        // Design products report
        DesignProductsReport(report);

        report.Prepare();

        using var ms = new MemoryStream();
        report.Export(new PDFSimpleExport(), ms);
        return ms.ToArray();
    }

    private void DesignSimpleReport(Report report)
    {
        // Create a simple page
        ReportPage page = new ReportPage();
        report.Pages.Add(page);

        // Create title band
        page.ReportTitle = new ReportTitleBand();
        page.ReportTitle.Height = Units.Centimeters * 2;
        page.ReportTitle.Name = "ReportTitle1";

        // Add title text
        TextObject titleText = new TextObject();
        titleText.Bounds = new RectangleF(0, 0, Units.Centimeters * 15, Units.Centimeters * 1);
        titleText.Text = "Orders Report";
        titleText.HorzAlign = HorzAlign.Center;
        titleText.Font = new Font("Arial", 16, FontStyle.Bold);
        page.ReportTitle.Objects.Add(titleText);

        // Create data band for orders
        DataBand dataBand = new DataBand();
        dataBand.Height = Units.Centimeters * 2;
        dataBand.DataSource = report.GetDataSource("Orders");
        page.Bands.Add(dataBand);

        // Add order details
        AddOrderDetails(dataBand);
    }

    private void AddOrderDetails(DataBand dataBand)
    {
        // Order ID
        TextObject orderIdText = new TextObject();
        orderIdText.Bounds = new RectangleF(0, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);
        orderIdText.Text = "Order ID: [Orders.OrderId]";
        orderIdText.Font = new Font("Arial", 10, FontStyle.Bold);
        dataBand.Objects.Add(orderIdText);

        // Customer Name
        TextObject customerText = new TextObject();
        customerText.Bounds = new RectangleF(Units.Centimeters * 4, 0, Units.Centimeters * 5, Units.Centimeters * 0.5f);
        customerText.Text = "Customer: [Orders.CustomerName]";
        dataBand.Objects.Add(customerText);

        // Order Date
        TextObject dateText = new TextObject();
        dateText.Bounds = new RectangleF(Units.Centimeters * 10, 0, Units.Centimeters * 5, Units.Centimeters * 0.5f);
        dateText.Text = "Date: [Orders.OrderDate]";
        dataBand.Objects.Add(dateText);

        // Total Amount
        TextObject totalText = new TextObject();
        totalText.Bounds = new RectangleF(0, Units.Centimeters * 0.6f, Units.Centimeters * 5, Units.Centimeters * 0.5f);
        totalText.Text = "Total: $[Orders.TotalAmount]";
        totalText.Font = new Font("Arial", 10, FontStyle.Bold);
        dataBand.Objects.Add(totalText);
    }

    private void DesignProductsReport(Report report)
    {
        ReportPage page = new ReportPage();
        report.Pages.Add(page);

        // Title band
        page.ReportTitle = new ReportTitleBand();
        page.ReportTitle.Height = Units.Centimeters * 2;

        TextObject titleText = new TextObject();
        titleText.Bounds = new RectangleF(0, 0, Units.Centimeters * 15, Units.Centimeters * 1);
        titleText.Text = "Products Report";
        titleText.HorzAlign = HorzAlign.Center;
        titleText.Font = new Font("Arial", 16, FontStyle.Bold);
        page.ReportTitle.Objects.Add(titleText);

        // Column header band
        page.ColumnHeader = new ColumnHeaderBand();
        page.ColumnHeader.Height = Units.Centimeters * 1;

        AddProductColumnHeaders(page.ColumnHeader);

        // Data band
        DataBand dataBand = new DataBand();
        dataBand.Height = Units.Centimeters * 0.8f;
        dataBand.DataSource = report.GetDataSource("Products");
        page.Bands.Add(dataBand);

        AddProductDetails(dataBand);
    }

    private void AddProductColumnHeaders(ColumnHeaderBand headerBand)
    {
        float[] columnWidths = { 2, 5, 3, 2, 3 };
        float[] positions = { 0, 2, 7, 10, 12 };
        string[] headers = { "ID", "Name", "Price", "Qty", "Category" };

        for (int i = 0; i < headers.Length; i++)
        {
            TextObject headerText = new TextObject();
            headerText.Bounds = new RectangleF(
                Units.Centimeters * positions[i],
                0,
                Units.Centimeters * columnWidths[i],
                Units.Centimeters * 0.8f
            );
            headerText.Text = headers[i];
            headerText.Font = new Font("Arial", 10, FontStyle.Bold);
            headerText.Fill = new SolidFill(Color.LightGray);
            headerText.Border = new Border();
            headerText.Border.Lines = BorderLines.All;
            headerBand.Objects.Add(headerText);
        }
    }

    private void AddProductDetails(DataBand dataBand)
    {
        float[] columnWidths = { 2, 5, 3, 2, 3 };
        float[] positions = { 0, 2, 7, 10, 12 };

        // ID
        TextObject idText = new TextObject();
        idText.Bounds = new RectangleF(
            Units.Centimeters * positions[0], 0,
            Units.Centimeters * columnWidths[0], Units.Centimeters * 0.8f
        );
        idText.Text = "[Products.Id]";
        idText.Border = new Border() { Lines = BorderLines.All };
        dataBand.Objects.Add(idText);

        // Name
        TextObject nameText = new TextObject();
        nameText.Bounds = new RectangleF(
            Units.Centimeters * positions[1], 0,
            Units.Centimeters * columnWidths[1], Units.Centimeters * 0.8f
        );
        nameText.Text = "[Products.Name]";
        nameText.Border = new Border() { Lines = BorderLines.All };
        dataBand.Objects.Add(nameText);

        // Price
        TextObject priceText = new TextObject();
        priceText.Bounds = new RectangleF(
            Units.Centimeters * positions[2], 0,
            Units.Centimeters * columnWidths[2], Units.Centimeters * 0.8f
        );
        priceText.Text = "[Products.Price]";
        priceText.Border = new Border() { Lines = BorderLines.All };
        dataBand.Objects.Add(priceText);

        // Quantity
        TextObject qtyText = new TextObject();
        qtyText.Bounds = new RectangleF(
            Units.Centimeters * positions[3], 0,
            Units.Centimeters * columnWidths[3], Units.Centimeters * 0.8f
        );
        qtyText.Text = "[Products.Quantity]";
        qtyText.Border = new Border() { Lines = BorderLines.All };
        dataBand.Objects.Add(qtyText);

        // Category
        TextObject categoryText = new TextObject();
        categoryText.Bounds = new RectangleF(
            Units.Centimeters * positions[4], 0,
            Units.Centimeters * columnWidths[4], Units.Centimeters * 0.8f
        );
        categoryText.Text = "[Products.Category]";
        categoryText.Border = new Border() { Lines = BorderLines.All };
        dataBand.Objects.Add(categoryText);
    }
}
