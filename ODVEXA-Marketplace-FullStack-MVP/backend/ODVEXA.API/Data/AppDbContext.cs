using Microsoft.EntityFrameworkCore;
using ODVEXA.API.Models;
namespace ODVEXA.API.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options){
 public DbSet<Product> Products=>Set<Product>(); public DbSet<Vendor> Vendors=>Set<Vendor>(); public DbSet<VendorOffer> VendorOffers=>Set<VendorOffer>(); public DbSet<CustomerOrder> Orders=>Set<CustomerOrder>(); public DbSet<AppUser> Users=>Set<AppUser>(); public DbSet<OrderItem> OrderItems=>Set<OrderItem>(); public DbSet<ProductReview> Reviews=>Set<ProductReview>();
 protected override void OnModelCreating(ModelBuilder b){b.Entity<Product>().HasMany(p=>p.Offers).WithOne(o=>o.Product).HasForeignKey(o=>o.ProductId);b.Entity<Vendor>().HasMany(v=>v.Offers).WithOne(o=>o.Vendor).HasForeignKey(o=>o.VendorId);b.Entity<VendorOffer>().Property(x=>x.Price).HasPrecision(12,2);}
}
