using System.ComponentModel.DataAnnotations;

namespace CustomerOrdersManagement.Models;

/// <summary>
/// Represents a single customer order shown in the Syncfusion DataGrid.
/// </summary>
public class Order
{
    [Display(Name = "Order ID")]
    public int OrderID { get; set; }

    [Required(ErrorMessage = "Customer name is required")]
    [StringLength(80)]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Product is required")]
    [StringLength(80)]
    [Display(Name = "Product")]
    public string Product { get; set; } = string.Empty;

    [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10000")]
    [Display(Name = "Quantity")]
    public int Quantity { get; set; }

    [Range(0.01, 1_000_000.00, ErrorMessage = "Price must be greater than 0")]
    [Display(Name = "Unit Price")]
    public decimal Price { get; set; }

    /// <summary>
    /// Computed property: Quantity * Price. Calculated at runtime.
    /// </summary>
    [Display(Name = "Total Amount")]
    public decimal TotalAmount => Quantity * Price;

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// One of: Pending, Processing, Shipped, Delivered, Cancelled.
    /// </summary>
    [Required]
    [Display(Name = "Status")]
    public string Status { get; set; } = OrderStatus.Pending;
}

public static class OrderStatus
{
    public const string Pending    = "Pending";
    public const string Processing = "Processing";
    public const string Shipped    = "Shipped";
    public const string Delivered  = "Delivered";
    public const string Cancelled  = "Cancelled";

    public static readonly string[] All = { Pending, Processing, Shipped, Delivered, Cancelled };
}
