# Customer Orders Management

A sample ASP.NET Core Razor Pages application that demonstrates how to build a fully interactive, exportable, and visually rich data grid with **Syncfusion ASP.NET Core Grid** — without any controller or repository layer. Data is bound directly to the Grid from the Razor Page model.

> **Tech stack:** .NET 10 · ASP.NET Core · Razor Pages · Syncfusion.AspNetCore.Grid 34.2.x · Syncfusion.AspNetCore.Themes 34.2.x · Bootstrap 5

---

## ✨ Features

- **Full CRUD** — Add, edit, delete, and inline-update orders directly inside the grid.
- **Filtering ** — Excel-like `FilterBar`.
- **Excel & PDF export** — Export visible (or all) rows to `.xlsx` or `.pdf` with one click.
- **Hero section + feature list** — An `<h1>` title and a responsive `<p>` of feature describe what the grid supports at a glance.

---

## 🖼️ Page structure

Above the grid the page renders:

1. **`<h1>`** — "ASP.NET Core with Grid Component" with a subtitle describing the demo.
2. **`<p>`** — six feature cards (filtering, inline editing, Excel export, PDF export).

> **Note:** Application styles are used for demo purposes; you can customize them based on your need. All demo styles live in [`wwwroot/css/site.css`](wwwroot/css/site.css).

---

## 📁 Project structure

```
CustomerOrdersManagement/
├── CustomerOrdersManagement.csproj   # NuGet refs + TargetFramework
├── Program.cs                        # Razor Pages startup (no Syncfusion DI needed)
├── appsettings.json / .Development.json
├── Models/
│   └── Order.cs                      # POCO with validation attributes + computed TotalAmount
├── Pages/
│   ├── Index.cshtml                  # The grid markup + toolbar/click
│   ├── Index.cshtml.cs               # Seeds 20 deterministic sample orders
│   ├── Privacy.cshtml(.cs)           # Boilerplate privacy page
│   ├── Error.cshtml(.cs)             # Boilerplate error page
│   ├── _ViewImports.cshtml           # Adds Syncfusion.AspNetCore.* tag helpers
│   ├── _ViewStart.cshtml
│   └── Shared/
│       └── _Layout.cshtml            # Loads EJ2 styles/scripts from NuGet _content/ + <ejs-scripts>
├── wwwroot/
│   └── css/site.css                  # Layout + cell-coloring + status-pill styles
└── Properties/launchSettings.json
```

---

## 🚀 Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A modern browser (Chrome / Edge / Firefox / Safari)

### Run

```bash
git clone <your-repo-url>
cd CustomerOrdersManagement
dotnet restore
dotnet run
```

Open `https://localhost:5001` (or whichever port `launchSettings.json` specifies).

> To register a Syncfusion license (Community License or commercial), add the following to the top of `Program.cs`:
>
> ```csharp
> Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR-LICENSE-KEY");
> ```
>
> **Note:** The `Syncfusion.Licensing` assembly ships transitively with `Syncfusion.AspNetCore.Grid`, so no extra package is required.

---

## 🧩 How the grid is wired (split packages, v34.2.x)

Starting with Syncfusion v34.2, the monolithic `Syncfusion.EJ2.AspNet.Core` package has been split into per-control packages. This project uses **two** of them:

### NuGet references — `CustomerOrdersManagement.csproj`

```xml
<ItemGroup>
    <PackageReference Include="Syncfusion.AspNetCore.Grid"   Version="*" />
    <PackageReference Include="Syncfusion.AspNetCore.Themes" Version="*" />
</ItemGroup>
```

The `*` floating version lets `dotnet restore` pick the latest 34.2.x patch. Pin to a specific version (e.g. `34.2.8`) in production.

### Tag helpers — `Pages/_ViewImports.cshtml`

```csharp
@using CustomerOrdersManagement
@using CustomerOrdersManagement.Models
@namespace CustomerOrdersManagement.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

@* Syncfusion split-package tag helpers (v34.2+) *@
@addTagHelper *, Syncfusion.AspNetCore.Base
@addTagHelper *, Syncfusion.AspNetCore.Grid
```

### Stylesheet & scripts — `Pages/Shared/_Layout.cshtml`

Static web assets are served from the NuGet packages via the `_content/` path. **Do not** reference the Syncfusion CDN — the static assets ship inside the NuGet package, and a CDN reference would skip them entirely.

```html
<head>
    ...
    <link rel="stylesheet"
          href="_content/Syncfusion.AspNetCore.Themes/styles/fluent2.css" />
    <script src="_content/Syncfusion.AspNetCore.Grid/scripts/sf-grid.min.js"></script>
</head>
<body>
    ...

    <!-- Syncfusion Script Manager — emits the per-page client-side init script. -->
    <ejs-scripts></ejs-scripts>

    @await RenderSectionAsync("Scripts", required: false)
</body>
```

### Service registration — `Program.cs`

The split packages do **not** require any service registration. `Program.cs` is the standard Razor Pages startup:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();
// ...standard middleware (UseHttpsRedirection, UseRouting, MapStaticAssets, MapRazorPages)
app.Run();
```
### The grid itself — `Pages/Index.cshtml`

```csharp
<ejs-grid id="OrdersGrid"
          dataSource="@Model.Orders"
          allowFiltering="true"
          allowExcelExport="true"
          allowPdfExport="true"
          toolbarClick="toolbarClick"
          toolbar="@(new List<string> {
              "Add", "Edit", "Delete", "Update", "Cancel",
              "ExcelExport", "PdfExport" })">
    <e-grid-filtersettings type="FilterBar"></e-grid-filtersettings>
    <e-grid-editSettings allowAdding="true"
                         allowEditing="true"
                         allowDeleting="true"
                         mode="Normal"></e-grid-editSettings>
    <e-grid-columns>
        <e-grid-column field="OrderID"      headerText="Order ID"      isPrimaryKey="true" width="110" textAlign="Center"></e-grid-column>
        <e-grid-column field="CustomerName" headerText="Customer Name" width="160" validationRules="@(new { required = true })"></e-grid-column>
        <e-grid-column field="Product"      headerText="Product"       width="170"></e-grid-column>
        <e-grid-column field="Quantity"     headerText="Quantity"      width="110" editType="NumericTextBox" textAlign="Right"></e-grid-column>
        <e-grid-column field="Price"        headerText="Unit Price"    width="130" format="C2" editType="NumericTextBox" textAlign="Right"></e-grid-column>
        <e-grid-column field="TotalAmount"  headerText="Total"         width="140" format="C2" textAlign="Right" allowEditing="false"></e-grid-column>
        <e-grid-column field="OrderDate"    headerText="Order Date"    width="140" format="yMd" type="Date" editType="DatePicker" textAlign="Center"></e-grid-column>
        <e-grid-column field="Status"       headerText="Status"        width="150" editType="DropdownEdit" textAlign="Center"></e-grid-column>
    </e-grid-columns>
</ejs-grid>
```

### Export handlers

```javascript
function toolbarClick(args) {
    var grid = document.getElementById("OrdersGrid").ej2_instances[0];
    if (args.item.id === 'OrdersGrid_pdfexport')  grid.pdfExport();
    if (args.item.id === 'OrdersGrid_excelexport') grid.excelExport();
}
```

## ⚠️ Common pitfalls when migrating from the monolithic package

If you previously used `Syncfusion.EJ2.AspNet.Core`, the following must change:

| Old (≤ v34.1)                                       | New (≥ v34.2)                                          |
|-----------------------------------------------------|--------------------------------------------------------|
| `<PackageReference Include="Syncfusion.EJ2.AspNet.Core" Version="..." />` | `Syncfusion.AspNetCore.Grid` + `Syncfusion.AspNetCore.Themes` |
| `@addTagHelper *, Syncfusion.EJ2`                   | `@addTagHelper *, Syncfusion.AspNetCore.Base`<br>`@addTagHelper *, Syncfusion.AspNetCore.Grid` |
| `https://cdn.syncfusion.com/ej2/<ver>/dist/ej2.min.js` | `_content/Syncfusion.AspNetCore.Grid/scripts/sf-grid.min.js` |
| `https://cdn.syncfusion.com/ej2/<ver>/fluent2.css` | `_content/Syncfusion.AspNetCore.Themes/styles/fluent2.css` |
| `builder.Services.AddSyncfusionScriptManager()`     | **(removed)** — not present in the split packages; use `<ejs-scripts></ejs-scripts>` in the layout instead |

## 🧪 Try it out

1. Run the project (`dotnet run`).
2. Use the **ExcelExport** / **PdfExport** toolbar buttons to download the grid.
3. Click the **+** toolbar button (Add) to insert a new row; double-click a row to edit; click the trash icon to delete.
4. Notice how `Quantity`, `Price`, `TotalAmount`, and `OrderDate` cells are color-coded, and how the `Status` column shows colored pills with row-edge tints.

---

## 📝 License

This sample is provided as-is for demonstration purposes. Syncfusion is commercial software; see [Syncfusion's licensing terms](https://www.syncfusion.com/sales/communitylicense) for Community License eligibility.
