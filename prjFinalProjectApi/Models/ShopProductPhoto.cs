using System;
using System.Collections.Generic;

namespace prjFinalProjectApi.Models;

public partial class ShopProductPhoto
{
    public int ProductPhotoId { get; set; }

    public int ProductId { get; set; }

    public byte[]? ThumbnailPhoto { get; set; }

    public string? ThumbnailPhotoFileName { get; set; }

    public byte[]? LargePhoto { get; set; }

    public string? LargePhotoFileName { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ThumbnailPhotoPath { get; set; }

    public string? LargePhotoPath { get; set; }

    public virtual ShopProduct Product { get; set; } = null!;

}
