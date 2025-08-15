using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Models.Dto;

namespace prjFinalProjectApi.Controllers.Supplies
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesProductsController : ControllerBase
    {
        private readonly DbNursingHomeContext _context;

        public SuppliesProductsController(DbNursingHomeContext context)
        {
            _context = context;
        }

        // GET: api/SuppliesProducts
        // 將供應商ID與供應品類別ID的名稱加入後端API回傳
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuppliesProduct>>> GetSuppliesProducts()
        {
            var suppliesProducts = await (
                                from SuppliesProducts in _context.SuppliesProducts
                                join SuppliesSupplierName in _context.SuppliesSuppliers on SuppliesProducts.SupplierId equals SuppliesSupplierName.SuppliesSupplierId
                                join SuppliesCategoryName in _context.SuppliesCategories on SuppliesProducts.SuppliesCategoryId equals SuppliesCategoryName.SuppliesCategoryId
                                select new SupplieslistDto
                                {
                                    SuppliesProductID = SuppliesProducts.SuppliesProductId,
                                    SuppliesProductName = SuppliesProducts.SuppliesProductName,
                                    QuantityPerUnit = SuppliesProducts.QuantityPerUnit,
                                    UnitsInStock = SuppliesProducts.UnitsInStock,
                                    PricePerUnit = SuppliesProducts.PricePerUnit,
                                    SuppliesSupplierName = SuppliesSupplierName.SuppliesSupplierName,
                                    SuppliesCategoryName = SuppliesCategoryName.SuppliesCategoryName,
                                    Exist = SuppliesProducts.Exist
                                }).ToListAsync();

            return Ok(suppliesProducts);
        }

        // GET: api/SuppliesProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuppliesProduct>> GetSuppliesProduct(int id)
        {
            var supplieslistDto = await (
                                from SuppliesProducts in _context.SuppliesProducts
                                join SuppliesSupplierName in _context.SuppliesSuppliers on SuppliesProducts.SupplierId equals SuppliesSupplierName.SuppliesSupplierId
                                join SuppliesCategoryName in _context.SuppliesCategories on SuppliesProducts.SuppliesCategoryId equals SuppliesCategoryName.SuppliesCategoryId
                                where SuppliesProducts.SuppliesProductId == id
                                select new SupplieslistDto
                                {
                                    SuppliesProductID = SuppliesProducts.SuppliesProductId,
                                    SuppliesProductName = SuppliesProducts.SuppliesProductName,
                                    QuantityPerUnit = SuppliesProducts.QuantityPerUnit,
                                    UnitsInStock = SuppliesProducts.UnitsInStock,
                                    PricePerUnit = SuppliesProducts.PricePerUnit,
                                    SuppliesSupplierName = SuppliesSupplierName.SuppliesSupplierName,
                                    SuppliesCategoryName = SuppliesCategoryName.SuppliesCategoryName,
                                    Exist = SuppliesProducts.Exist
                                }).FirstOrDefaultAsync();

            if (supplieslistDto == null)
            {
                return NotFound();
            }

            return Ok(supplieslistDto);
        }

        // PUT: api/SuppliesProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuppliesProduct(int id, SuppliesProduct suppliesProduct)
        {
            if (id != suppliesProduct.SuppliesProductId)
            {
                return BadRequest();
            }

            _context.Entry(suppliesProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuppliesProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SuppliesProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuppliesProduct>> PostSuppliesProduct(SuppliesProduct suppliesProduct)
        {
            _context.SuppliesProducts.Add(suppliesProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuppliesProduct", new { id = suppliesProduct.SuppliesProductId }, suppliesProduct);
        }

        // DELETE: api/SuppliesProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuppliesProduct(int id)
        {
            var suppliesProduct = await _context.SuppliesProducts.FindAsync(id);
            if (suppliesProduct == null)
            {
                return NotFound();
            }

            _context.SuppliesProducts.Remove(suppliesProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuppliesProductExists(int id)
        {
            return _context.SuppliesProducts.Any(e => e.SuppliesProductId == id);
        }
    }
}
