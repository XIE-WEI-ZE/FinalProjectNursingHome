namespace prjFinalProjectApi.Models.Dto
{
    // 前台商品清單用 DTO
    public class ShopProductListDto
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = "";

        public int? OriginalPrice { get; set; }

        public int? SalePrice { get; set; }

        public string? ThumbnailPhotoPath { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = "";

        public string Slug { get; set; } = "";
    }

    // 前台商品詳細頁用 DTO
    public class ShopProductDetailDto
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = "";

        public string Slug { get; set; } = null!;

        public int? OriginalPrice { get; set; }

        public int? SalePrice { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public int? Quantity { get; set; }

        public int? Stock { get; set; }

        public string? LargePhotoPath { get; set; }

        public IEnumerable<string> GalleryLargePaths { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> GalleryThumbPaths { get; set; } = Enumerable.Empty<string>();

        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = "";
    }

    // 後台商品新增/更新用 DTO（可留著以後用）
    public class ShopProductUpsertDto
    {
        public string ProductName { get; set; } = "";

        public int CategoryID { get; set; }

        public int? OriginalPrice { get; set; }

        public decimal? DiscountRate { get; set; }

        public int? SalePrice { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public int? Quantity { get; set; }

        public int? Stock { get; set; }
    }
}
