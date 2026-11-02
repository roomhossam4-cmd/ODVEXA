using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using ODVEXA.API.Data;using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/products/{productId:int}/reviews")]
public class ReviewsController(AppDbContext db):ControllerBase{
 [HttpGet] public async Task<IActionResult> Get(int productId)=>Ok(await db.Reviews.Where(x=>x.ProductId==productId).OrderByDescending(x=>x.CreatedAt).ToListAsync());
 [HttpPost] public async Task<IActionResult> Create(int productId,ProductReview review){if(review.Rating<1||review.Rating>5||string.IsNullOrWhiteSpace(review.Comment))return BadRequest();if(!await db.Products.AnyAsync(x=>x.Id==productId))return NotFound();review.Id=0;review.ProductId=productId;review.CreatedAt=DateTime.UtcNow;db.Reviews.Add(review);await db.SaveChangesAsync();return Ok(review);}
}
