using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

namespace src.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductsController : ControllerBase
  {

    private readonly ILogger<ProductsController> _logger;
    private readonly ApplicationDbContext _context;

    public ProductsController(
      ILogger<ProductsController> logger,
      ApplicationDbContext context
    )
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await this._context.Products
            .Include("movies")
            .ToArrayAsync();
        return products;
    }

    [HttpGet("movieProducts/{movie}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetMovieProducts(String movie)
    {
      var products = await this._context.Products
        .Include("movies")
        .Where(m => m.movies.Any(a => a.headline == movie))
        .ToArrayAsync();
      
      return products;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var product = await this._context.Products
        .Include("movies")
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      if (product is null)
      {
        return NotFound();
      }

      return product;
    }

    [HttpGet("purchaseProduct/{id}")]
    public async Task<ActionResult<Product>> PurchaseProduct(int id) 
    {
      var product = await this._context.Products
        .Include("movies")
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();
      
      if(product is null)
      {
        return NotFound( new {
          message = "product not found"
        });
      }

      if(product.capacity == 0)
      {
        return NotFound( new {
          message = "product not available"
        });
      }

      product.capacity = product.capacity - 1;
      await _context.SaveChangesAsync();
      Console.WriteLine("Capacity of product with id = ", product.Id, "is modified");

      return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        this._context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product product) 
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;
        var localproduct = await this._context.Products.Where(m => m.Id == id).FirstOrDefaultAsync();

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (product is null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return product;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return product;
    }
  }
}