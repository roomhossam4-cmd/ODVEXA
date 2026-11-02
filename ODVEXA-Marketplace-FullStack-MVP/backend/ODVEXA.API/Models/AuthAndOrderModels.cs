namespace ODVEXA.API.Models;
public class AppUser { public int Id{get;set;} public string Name{get;set;}=""; public string Email{get;set;}=""; public string PasswordHash{get;set;}=""; public string Role{get;set;}="Customer"; public DateTime CreatedAt{get;set;}=DateTime.UtcNow; }
public class OrderItem { public int Id{get;set;} public int OrderId{get;set;} public CustomerOrder? Order{get;set;} public int ProductId{get;set;} public string ProductName{get;set;}=""; public string VendorName{get;set;}=""; public decimal UnitPrice{get;set;} public int Quantity{get;set;} }
public class ProductReview { public int Id{get;set;} public int ProductId{get;set;} public string CustomerName{get;set;}=""; public int Rating{get;set;} public string Comment{get;set;}=""; public DateTime CreatedAt{get;set;}=DateTime.UtcNow; }
public record RegisterRequest(string Name,string Email,string Password);
public record LoginRequest(string Email,string Password);
public record OrderItemRequest(int ProductId,string ProductName,string VendorName,decimal UnitPrice,int Quantity);
public record CreateOrderRequest(string CustomerEmail,List<OrderItemRequest> Items);
