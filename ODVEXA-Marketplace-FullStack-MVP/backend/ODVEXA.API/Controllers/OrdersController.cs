using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using System.Security.Claims;using ODVEXA.API.Data;using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/orders")]
public class OrdersController(AppDbContext db):ControllerBase{
 [Authorize(Roles="Admin")][HttpGet] public async Task<IActionResult> Get()=>Ok(await db.Orders.Include(x=>x.Items).OrderByDescending(x=>x.CreatedAt).ToListAsync());
 [Authorize(Roles="Admin")][HttpGet("{id:int}")] public async Task<IActionResult> GetOne(int id){var o=await db.Orders.Include(x=>x.Items).FirstOrDefaultAsync(x=>x.Id==id);return o is null?NotFound():Ok(o);}
 [Authorize(Roles="Admin")]
 [Authorize][HttpPost] public async Task<IActionResult> Create(CreateOrderRequest request){var customerEmail=User.FindFirst(ClaimTypes.Email)?.Value ?? "";if(string.IsNullOrWhiteSpace(customerEmail)||request.Items.Count==0||request.Items.Any(x=>x.Quantity<1||x.UnitPrice<0))return BadRequest(new{message="Valid customer email and order items are required."});var order=new CustomerOrder{OrderNumber="ODV-"+Guid.NewGuid().ToString("N")[..8].ToUpper(),CustomerEmail=customerEmail,Status="Processing",CreatedAt=DateTime.UtcNow,Items=request.Items.Select(x=>new OrderItem{ProductId=x.ProductId,ProductName=x.ProductName,VendorName=x.VendorName,UnitPrice=x.UnitPrice,Quantity=x.Quantity}).ToList()};order.Total=order.Items.Sum(x=>x.UnitPrice*x.Quantity);db.Orders.Add(order);await db.SaveChangesAsync();return Ok(order);}
 [Authorize(Roles="Admin")]
 [Authorize(Roles="Admin")][HttpPatch("{id:int}/status")] public async Task<IActionResult> UpdateStatus(int id,[FromBody]string status){var allowed=new[]{"Processing","Confirmed","Shipped","Delivered","Cancelled"};if(!allowed.Contains(status))return BadRequest(new{message="Invalid status."});var x=await db.Orders.FindAsync(id);if(x is null)return NotFound();x.Status=status;await db.SaveChangesAsync();return NoContent();}
}
