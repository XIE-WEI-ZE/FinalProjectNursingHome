using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class ShopProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public int OriginalPrice { get; set; }

    public decimal? DiscountRate { get; set; }

    public int SalePrice { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public short Quantity { get; set; }

    public short Stock { get; set; }

    public bool Discontinued { get; set; }

    public string? Summary { get; set; }

    public string? Content { get; set; }

    public string? ThumbnailPhotoPath { get; set; }

    public string? LargePhotoPath { get; set; }

    public virtual ShopCategory? Category { get; set; }

    public string Slug { get; set; } = null!;
}
