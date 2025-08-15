using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;

namespace prjFinalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopCategoriesController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;

        public ShopCategoriesController(DbNursingHomeContext context)
        {
            _context = context;
        }

        // GET: api/ShopCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopCategoryDto>>> GetCategories()
        {
            var categories = await _context.ShopCategories
                .Select(c => new ShopCategoryDto
                {
                    CategoryID = c.CategoryId,
                    CategoryName = c.CategoryName,
                })
                .ToListAsync();

            return Ok(categories);
        }
    }
}
