using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using ODVEXA.API.Data;using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/offers")]
public class OffersController(AppDbContext db):ControllerBase{
 [Authorize(Roles="Admin")]
 [HttpPost] public async Task<IActionResult> Create(VendorOffer offer){offer.Id=0;if(!await db.Products.AnyAsync(x=>x.Id==offer.ProductId)||!await db.Vendors.AnyAsync(x=>x.Id==offer.VendorId))return BadRequest("Product or vendor does not exist.");db.VendorOffers.Add(offer);await db.SaveChangesAsync();return Ok(offer);}
 [Authorize(Roles="Admin")]
 [HttpPut("{id:int}")] public async Task<IActionResult> Update(int id,VendorOffer input){var x=await db.VendorOffers.FindAsync(id);if(x is null)return NotFound();x.Price=input.Price;x.StockQuantity=input.StockQuantity;x.ShippingFee=input.ShippingFee;x.IsActive=input.IsActive;await db.SaveChangesAsync();return NoContent();}
}
