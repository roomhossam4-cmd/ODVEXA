using ODVEXA.API.Models;
namespace ODVEXA.API.Data;
public static class SeedData{
 public static void Initialize(AppDbContext db){if(db.Vendors.Any())return;
 var v1=new Vendor{Name="Cairo Dental Supply",City="Cairo",Description="Professional dental materials and clinic essentials.",IsVerified=true};
 var v2=new Vendor{Name="Prime Med Store",City="Giza",Description="Selected dental supplies and equipment.",IsVerified=true};
 var v3=new Vendor{Name="Dental House",City="Alexandria",Description="Instruments, endodontics and equipment.",IsVerified=true};
 db.Vendors.AddRange(v1,v2,v3);
 var p1=new Product{Name="Universal Composite Restorative",Brand="3M",Category="Restoratives",Sku="3M-FIL-Z250",Description="Light-cured universal composite restorative.",ImageUrl=""};
 var p2=new Product{Name="Nitrile Examination Gloves — 100 pcs",Brand="MedCare",Category="Infection Control",Sku="MC-NIT-M",Description="Powder-free nitrile examination gloves."};
 var p3=new Product{Name="Endodontic Rotary Files Set",Brand="Dentsply Sirona",Category="Endodontics",Sku="DS-PRO-TAPER",Description="Rotary endodontic file assortment."};
 db.Products.AddRange(p1,p2,p3);db.SaveChanges();
 db.VendorOffers.AddRange(new VendorOffer{Product=p1,Vendor=v1,Price=890,StockQuantity=24,ShippingFee=55},new VendorOffer{Product=p1,Vendor=v2,Price=925,StockQuantity=12},new VendorOffer{Product=p1,Vendor=v3,Price=870,StockQuantity=0,ShippingFee=45},new VendorOffer{Product=p2,Vendor=v1,Price=199,StockQuantity=35,ShippingFee=55},new VendorOffer{Product=p2,Vendor=v2,Price=185,StockQuantity=80},new VendorOffer{Product=p3,Vendor=v3,Price=1450,StockQuantity=8,ShippingFee=70});
 db.SaveChanges();}
}
