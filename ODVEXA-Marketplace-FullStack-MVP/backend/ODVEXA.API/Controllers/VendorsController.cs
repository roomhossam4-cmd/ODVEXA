using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using ODVEXA.API.Data;using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/vendors")]
public class VendorsController(AppDbContext db):ControllerBase{
 [HttpGet] public async Task<IActionResult> Get()=>Ok(await db.Vendors.AsNoTracking().Include(v=>v.Offers).ToListAsync());
 [HttpGet("{id:int}")] public async Task<IActionResult> GetOne(int id){var v=await db.Vendors.Include(x=>x.Offers).ThenInclude(o=>o.Product).FirstOrDefaultAsync(x=>x.Id==id);return v is null?NotFound():Ok(v);}\n [Authorize(Roles="Admin")]
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,Vendor input){var v=await db.Vendors.FindAsync(id);if(v is null)return NotFound();v.Name=input.Name;v.City=input.City;v.Description=input.Description;v.IsVerified=input.IsVerified;await db.SaveChangesAsync();return NoContent();}\n [Authorize(Roles="Admin")]
 [HttpPost] public async Task<IActionResult> Create(Vendor v){v.Id=0;db.Vendors.Add(v);await db.SaveChangesAsync();return Ok(v);}
}
