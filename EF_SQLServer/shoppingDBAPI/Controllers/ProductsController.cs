using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shoppingDBAPI.Models.EF;

namespace shoppingDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShoppingDbContext _context = new ShoppingDbContext();

        //public ProductsController(ShoppingDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsList>>> GetProductsLists()
        {
          if (_context.ProductsLists == null)
          {
              return NotFound();
          }
            return await _context.ProductsLists.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsList>> GetProductsList(int id)
        {
          if (_context.ProductsLists == null)
          {
              return NotFound();
          }
            var productsList = await _context.ProductsLists.FindAsync(id);

            if (productsList == null)
            {
                return NotFound();
            }

            return productsList;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsList(int id, ProductsList productsList)
        {
            if (id != productsList.Pid)
            {
                return BadRequest();
            }

            _context.Entry(productsList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsListExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductsList>> PostProductsList(ProductsList productsList)
        {
          if (_context.ProductsLists == null)
          {
              return Problem("Entity set 'ShoppingDbContext.ProductsLists'  is null.");
          }
            _context.ProductsLists.Add(productsList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductsListExists(productsList.Pid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductsList", new { id = productsList.Pid }, productsList);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsList(int id)
        {
            if (_context.ProductsLists == null)
            {
                return NotFound();
            }
            var productsList = await _context.ProductsLists.FindAsync(id);
            if (productsList == null)
            {
                return NotFound();
            }

            _context.ProductsLists.Remove(productsList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsListExists(int id)
        {
            return (_context.ProductsLists?.Any(e => e.Pid == id)).GetValueOrDefault();
        }
    }
}
