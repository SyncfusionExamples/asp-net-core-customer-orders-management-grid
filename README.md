# ASP.NET Core Grid - Customer Orders Management
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#aspnet-core-grid---customer-orders-management)

## Overview
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#overview)
This sample demonstrates how to build a customer orders management view in an ASP.NET Core Razor Pages application using the Syncfusion Data Grid component. The grid is bound directly to a local collection of strongly typed `Order` records provided by the page model. The sample covers local data binding, filter bar filtering, toolbar-driven inline editing (Add, Edit, Delete), and exporting the grid content to Excel and PDF.

## Key Features
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#key-features)

- Uses the Syncfusion ASP.NET Core Data Grid (`ejs-grid` tag helper) as the primary data presentation component.
- Binds the grid to a `List<Order>` from the Razor Pages page model via `dataSource="@Model.Orders"`, demonstrating direct local data binding.
- Enables filter bar filtering to quickly narrow down orders by any column.
- Provides inline editing with `Add`, `Edit`, `Delete`, `Update`, and `Cancel` toolbar commands, with `OrderID` set as the primary key column.
- Exports grid data to Excel and PDF using the built-in `ExcelExport` and `PdfExport` toolbar items.
- Uses a strongly typed `Order` model with data-annotation validation, a computed **Total Amount** column (`Quantity × Price`), currency (`C2`) and date (`yMd`) column formats, and a dropdown editor for order status.
- References the `Syncfusion.AspNetCore.Grid` and `Syncfusion.AspNetCore.Themes` NuGet packages, with Syncfusion tag helpers registered in `Pages/_ViewImports.cshtml` and the Fluent theme, Grid script, and `ejs-scripts` manager wired up in the shared layout.

## Prerequisites
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#prerequisites)

- .NET 10.0 SDK
- Visual Studio 2026 or Visual Studio Code

## How to Run the Project
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#how-to-run-the-project)

**Visual Studio 2026**

1. Clone or download this repository.
2. Open `CustomerOrdersManagement.slnx` in Visual Studio 2026.
3. Restore the NuGet packages.
4. Build the solution.
5. Run the application.
6. Navigate to the home page that hosts the Syncfusion Data Grid sample.
7. Try filtering, adding, editing, or deleting orders from the grid toolbar, and export the results to Excel or PDF.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open the integrated terminal.
3. Navigate to the project directory.

```
dotnet restore
dotnet run
```

## Project Structure
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#project-structure)

- `Pages/` — Contains the Razor Pages that host the Syncfusion Data Grid sample, including the page model that supplies the order records.
- `Pages/Shared/` — Contains `_Layout.cshtml`, which loads the Syncfusion theme stylesheet, the Grid component script, and the `ejs-scripts` script manager.
- `Models/` — Contains the `Order` data model and `OrderStatus` constants used to populate the grid.
- `Program.cs` — Configures application services and the request pipeline for the Razor Pages application.
- `wwwroot/` — Contains static assets (CSS, JavaScript, and client libraries) used by the application.

## Support and Feedback
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#support-and-feedback)

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For ASP.NET Core DataGrid documentation, see: [https://help.syncfusion.com/aspnet-core/grid/getting-started](https://help.syncfusion.com/aspnet-core/grid/getting-started)

## License
[](https://github.com/SyncfusionExamples/asp-net-core-customer-orders-management-grid#license)
This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.
