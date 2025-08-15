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

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<object>>> GetCategories()
        {
            var categories = await _context.ShopCategories
                .AsNoTracking()
                .Select(c => new {
                    CategoryID = c.CategoryId,
                    CategoryName = c.CategoryName
                })
                .ToListAsync();

            return Ok(categories);
        }

        // 商品清單（前台用）：只帶第一張縮圖與分類名稱
        [HttpGet("list")]
        public async Task<ActionResult<object>> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 9, [FromQuery] int? categoryId = null)
        {
            var query = _context.ShopProducts
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => !p.Discontinued);

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var totalCount = await query.CountAsync();

            var products = await query
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ShopProductListDto
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName,
                    OriginalPrice = p.OriginalPrice,
                    SalePrice = p.SalePrice,
                    ThumbnailPhotoPath = $"{Request.Scheme}://{Request.Host}{p.ThumbnailPhotoPath}",
                    CategoryID = p.CategoryId ?? 0,
                    CategoryName = p.Category != null ? p.Category.CategoryName : "",
                    Slug = p.Slug
                })
                .ToListAsync();

            return Ok(new { items = products, totalCount });
        }




        // 商品詳細頁（前台用）：主商品一次取，圖庫再單次查詢塞入（效能好、可讀性佳）
        [HttpGet("detail/{slug}")]
        public async Task<ActionResult<ShopProductDetailDto>> GetProductDetail(string slug)
        {
            // 先撈商品主檔（不在 Select 內再用 _context）
            var dto = await _context.ShopProducts
                .AsNoTracking()
                .Include(p => p.Category)
                .Where(p => p.Slug == slug && !p.Discontinued)
                .Select(p => new ShopProductDetailDto
                {
                    ProductID = p.ProductId,
                    ProductName = p.ProductName,
                    Slug = p.Slug,
                    OriginalPrice = p.OriginalPrice,
                    SalePrice = p.SalePrice,
                    Summary = p.Summary,
                    Content = p.Content,
                    Quantity = p.Quantity,
                    Stock = p.Stock,
                    //LargePhotoPath = p.LargePhotoPath,
                    LargePhotoPath = $"{Request.Scheme}://{Request.Host}{p.LargePhotoPath}",
                    CategoryID = p.CategoryId ?? 0,
                    CategoryName = p.Category != null ? p.Category.CategoryName : ""
                })
                .FirstOrDefaultAsync();

            if (dto == null) return NotFound();

            // 再單次查詢相簿並塞回 DTO（一次 I/O，不重複 _context 子查詢）
            var photos = await _context.ShopProductPhotos
                .AsNoTracking()
                .Where(ph => ph.ProductId == dto.ProductID)
                .Select(ph => new { ph.LargePhotoPath, ph.ThumbnailPhotoPath })
                .ToListAsync();

            //dto.GalleryLargePaths = photos.Select(x => x.LargePhotoPath ?? "");
            dto.GalleryLargePaths = photos.Select(x => $"{Request.Scheme}://{Request.Host}{x.LargePhotoPath}" ?? "");
            //dto.GalleryThumbPaths = photos.Select(x => x.ThumbnailPhotoPath ?? "");
            dto.GalleryThumbPaths = photos.Select(x => $"{Request.Scheme}://{Request.Host}{x.ThumbnailPhotoPath}" ?? "");

            return Ok(dto);
        }

        // （備用）僅取某商品圖片清單（詳細頁若要分次載入可用）
        [HttpGet("{productId}/photos")]
        public async Task<ActionResult<IEnumerable<object>>> GetProductPhotos(int productId)
        {
            var photos = await _context.ShopProductPhotos
                .AsNoTracking()
                .Where(p => p.ProductId == productId)
                .Select(p => new
                {
                    p.ProductPhotoId,
                    p.ThumbnailPhotoPath,
                    p.LargePhotoPath
                })
                .ToListAsync();

            if (photos.Count == 0)
                return NotFound(new { message = "找不到圖片" });

            return Ok(photos);
        }
    }
}
