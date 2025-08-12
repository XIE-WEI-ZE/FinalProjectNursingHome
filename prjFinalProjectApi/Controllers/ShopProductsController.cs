using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;

namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopProductsController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;

        public ShopProductsController(DbNursingHomeContext context)
        {
            _context = context;
        }

        // 商品清單 API（含分類名稱）
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ShopProductListDto>>> GetProducts()
        {
            var products = await _context.ShopProducts
                .Include(p => p.Category)
                .Where(p => !p.Discontinued)
                .Select(p => new ShopProductListDto
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName,
                    SalePrice = p.SalePrice,
                    ThumbnailPhotoPath = p.ThumbnailPhotoPath,
                    CategoryID = p.CategoryId ?? 0,
                    CategoryName = p.Category != null ? p.Category.CategoryName : ""
                })
                .ToListAsync();

            return Ok(products);
        }

        // 商品詳細頁 API（含圖片圖庫）
        [HttpGet("detail/{slug}")]
        public async Task<ActionResult<ShopProductDetailDto>> GetProductDetail(string slug)
        {
            var product = await _context.ShopProducts
                .Where(p => p.Slug == slug && !p.Discontinued)
                .Select(p => new ShopProductDetailDto
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName,
                    SalePrice = p.SalePrice,
                    Summary = p.Summary,
                    Content = p.Content,
                    LargePhotoPath = p.LargePhotoPath,
                    GalleryLargePaths = _context.ShopProductPhotos
                        .Where(photo => photo.ProductId == p.ProductId)
                        .Select(photo => photo.LargePhotoPath ?? "")
                        .ToList(),
                    GalleryThumbPaths = _context.ShopProductPhotos
                        .Where(photo => photo.ProductId == p.ProductId)
                        .Select(photo => photo.ThumbnailPhotoPath ?? "")
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
