using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODVEXA.API.Data;
using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/products")]
public class ProductsController(AppDbContext db):ControllerBase{
 [HttpGet] public async Task<IActionResult> Get([FromQuery]string? q,[FromQuery]string? category){var x=db.Products.AsNoTracking().Include(p=>p.Offers).ThenInclude(o=>o.Vendor).AsQueryable();if(!string.IsNullOrWhiteSpace(q))x=x.Where(p=>p.Name.Contains(q)||p.Brand.Contains(q)||p.Sku.Contains(q));if(!string.IsNullOrWhiteSpace(category))x=x.Where(p=>p.Category==category);return Ok(await x.ToListAsync());}
 [HttpGet("{id:int}")] public async Task<IActionResult> GetById(int id){var p=await db.Products.Include(x=>x.Offers).ThenInclude(o=>o.Vendor).FirstOrDefaultAsync(x=>x.Id==id);return p is null?NotFound():Ok(p);}
 [Authorize(Roles="Admin")]
 [HttpPost] public async Task<IActionResult> Create(Product p){p.Id=0;db.Products.Add(p);await db.SaveChangesAsync();return CreatedAtAction(nameof(GetById),new{id=p.Id},p);}
 [Authorize(Roles="Admin")]
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,Product input){var p=await db.Products.FindAsync(id);if(p is null)return NotFound();p.Name=input.Name;p.Brand=input.Brand;p.Category=input.Category;p.Sku=input.Sku;p.Description=input.Description;p.ImageUrl=input.ImageUrl;await db.SaveChangesAsync();return NoContent();}
 [Authorize(Roles="Admin")]
 [HttpDelete("{id:int}")] public async Task<IActionResult> Delete(int id){var p=await db.Products.FindAsync(id);if(p is null)return NotFound();db.Products.Remove(p);await db.SaveChangesAsync();return NoContent();}
}
