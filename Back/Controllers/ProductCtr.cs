using Inmemory_Collection.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inmemory_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCtr : ControllerBase
    {
        ProductContext context;
        public ProductCtr(ProductContext _context)
        {
            context = _context;
        }
        [HttpPost("categoryins")]
        public async Task<ActionResult<CategoryModel>> catins(CategoryModel ca)
        {
            var ty = await context.categories.AddAsync(ca);
            await context.SaveChangesAsync();
            return Ok("ins" + ty);
        }
        [HttpPost("productins")]
        public async Task<ActionResult<ProductModel>> pradd(ProductModel pr)
        {
            var ty = await context.AddAsync(pr);
            await context.SaveChangesAsync();
            return Ok("ins" + ty);
        }
        [HttpGet("caget")]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> cadis()
        {
            var ty = await context.categories.ToListAsync();
            return ty;
        }
        [HttpGet("proget")]
        public async Task<ActionResult<object>> prdis()
        {
            var ty = await (from p in context.products
                            join
                            c in context.categories on
                            p.CategoryId equals c.CategoryId
                            select new
                            {
                                ProductName = p.ProductName,
                                ProductPrice = p.ProductPrice,
                                Qty = p.Qty,
                                ProductTotalPrice = p.ProductTotalPrice,
                                CategoryName = c.CategoryName,
                                ProductId = p.ProductId,
                                CategoryId = p.CategoryId,

                            }
                            ).ToListAsync();
            return ty;
        }
        [HttpPut("prupd/{id}")]
        public async Task<ActionResult<ProductModel>> prupd(int id, ProductModel pl)
        {
            var ty = context.products.FirstOrDefault(c => c.ProductId == id);
            ty.ProductName = pl.ProductName;
            ty.ProductPrice = pl.ProductPrice;
            ty.Qty = pl.Qty;
            ty.CategoryId = pl.CategoryId;
            context.Update(ty);
            await context.SaveChangesAsync();
            return Ok("upd" + ty);
        }
        [HttpGet("prgetid/{id}")]
        public async Task<ActionResult<ProductModel>> pridget(int id)
        {
            var ty = await context.products.FirstOrDefaultAsync(c => c.ProductId == id);
            var gh = await (from p in context.products
                            join c in context.categories
                            on p.CategoryId equals c.CategoryId
                            where p.ProductId == id
                            select new
                            {
                                ProductName = p.ProductName,
                                ProductPrice = p.ProductPrice,
                                Qty = p.Qty,
                                ProductTotalPrice = p.ProductTotalPrice,
                                CategoryName = c.CategoryName,
                                ProductId = p.ProductId,
                                CategoryId = p.CategoryId
                            }
                            ).FirstOrDefaultAsync();
            return Ok(gh);
        }
        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult<ProductModel>> del(int id)
        {
            var ty = context.products.FirstOrDefault(c => c.ProductId == id);
            context.products.Remove(ty);
            await context.SaveChangesAsync();
            return Ok("sel");
        }
        [HttpGet("getbyname/{name}")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> getbyname(string name)
        {
            var ty = await context.products.Where(c => c.ProductName == name).ToListAsync();
            var gh = await (from p in context.products
                            join c in context.categories
                            on p.CategoryId equals c.CategoryId
                            where p.ProductName == name
                            select new
                            {
                                ProductName = p.ProductName,
                                ProductPrice = p.ProductPrice,
                                Qty = p.Qty,
                                ProductTotalPrice = p.ProductTotalPrice,
                                CategoryName = c.CategoryName,
                                ProductId = p.ProductId,
                                CategoryId = p.CategoryId
                            }
                            ).ToListAsync();
            return Ok(gh);

        }
    }
}
