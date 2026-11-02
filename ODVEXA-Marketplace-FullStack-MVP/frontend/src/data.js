export const categories = [
  {name:'Infection Control',icon:'✚',count:1240},
  {name:'Restoratives',icon:'◈',count:860},
  {name:'Endodontics',icon:'⌁',count:540},
  {name:'Impression Materials',icon:'◉',count:420},
  {name:'Dental Instruments',icon:'⚒',count:970},
  {name:'Disposables',icon:'▤',count:1560},
  {name:'Equipment',icon:'▣',count:310},
  {name:'Orthodontics',icon:'⌗',count:290}
];
export const initialProducts = [
 {id:1,name:'Universal Composite Restorative',brand:'3M',sku:'3M-FIL-Z250',category:'Restoratives',desc:'Light-cured universal microhybrid composite for direct anterior and posterior restorations. Natural-looking results with reliable handling.',image:'https://images.unsplash.com/photo-1609840114035-3c981b782dfe?w=900',rating:4.8,reviews:126,offers:[{vendor:'Cairo Dental Supply',price:890,stock:24,shipping:55,city:'Cairo',verified:true},{vendor:'Prime Med Store',price:925,stock:12,shipping:0,city:'Giza',verified:true},{vendor:'Dental House',price:870,stock:0,shipping:45,city:'Alexandria',verified:true}]},
 {id:2,name:'Nitrile Examination Gloves — 100 pcs',brand:'MedCare',sku:'MC-NIT-M',category:'Infection Control',desc:'Powder-free nitrile examination gloves with textured fingertips. Box of 100 pieces.',image:'https://images.unsplash.com/photo-1584744982491-665216d95f8b?w=900',rating:4.7,reviews:89,offers:[{vendor:'Prime Med Store',price:185,stock:80,shipping:0,city:'Giza',verified:true},{vendor:'Cairo Dental Supply',price:199,stock:35,shipping:55,city:'Cairo',verified:true}]},
 {id:3,name:'Endodontic Rotary Files Set',brand:'Dentsply Sirona',sku:'DS-PRO-TAPER',category:'Endodontics',desc:'Rotary endodontic file assortment designed for predictable canal shaping. Multiple sizes included.',image:'https://images.unsplash.com/photo-1606811971618-4486d14f3f99?w=900',rating:4.9,reviews:64,offers:[{vendor:'Dental House',price:1450,stock:8,shipping:70,city:'Alexandria',verified:true},{vendor:'Cairo Dental Supply',price:1520,stock:15,shipping:55,city:'Cairo',verified:true}]},
 {id:4,name:'Alginate Impression Material',brand:'Zhermack',sku:'ZH-ALGINATE-500',category:'Impression Materials',desc:'Fast-setting alginate impression material with smooth mixing and accurate detail reproduction. 500 g pack.',image:'https://images.unsplash.com/photo-1609840114035-3c981b782dfe?w=900',rating:4.6,reviews:42,offers:[{vendor:'Cairo Dental Supply',price:320,stock:42,shipping:55,city:'Cairo',verified:true},{vendor:'Prime Med Store',price:345,stock:19,shipping:0,city:'Giza',verified:true}]},
 {id:5,name:'LED Curing Light',brand:'Woodpecker',sku:'WP-LIGHT-01',category:'Equipment',desc:'Cordless LED curing light with multiple working modes and a compact ergonomic handpiece.',image:'https://images.unsplash.com/photo-1629909613654-28e377c37b09?w=900',rating:4.8,reviews:31,offers:[{vendor:'Prime Med Store',price:3850,stock:5,shipping:0,city:'Giza',verified:true},{vendor:'Dental House',price:3990,stock:3,shipping:70,city:'Alexandria',verified:true}]},
 {id:6,name:'Dental Bibs — 125 pcs',brand:'Crosstex',sku:'CR-BIB-125',category:'Disposables',desc:'Absorbent disposable patient bibs with waterproof backing. Pack of 125.',image:'https://images.unsplash.com/photo-1588776814546-1ffcf47267a5?w=900',rating:4.5,reviews:57,offers:[{vendor:'Cairo Dental Supply',price:145,stock:100,shipping:55,city:'Cairo',verified:true},{vendor:'Prime Med Store',price:152,stock:55,shipping:0,city:'Giza',verified:true}]},
 {id:7,name:'Mouth Mirror Set — 12 pcs',brand:'Medesy',sku:'MD-MIR-12',category:'Dental Instruments',desc:'Stainless-steel dental mouth mirrors suitable for routine examination and diagnosis.',image:'https://images.unsplash.com/photo-1606811841689-23dfddce3e95?w=900',rating:4.7,reviews:28,offers:[{vendor:'Dental House',price:260,stock:17,shipping:70,city:'Alexandria',verified:true},{vendor:'Cairo Dental Supply',price:275,stock:32,shipping:55,city:'Cairo',verified:true}]},
 {id:8,name:'Orthodontic Bracket Kit',brand:'Ormco',sku:'OR-KIT-022',category:'Orthodontics',desc:'Orthodontic bracket assortment kit for professional clinical use. Check prescription and compatibility requirements.',image:'https://images.unsplash.com/photo-1609840114035-3c981b782dfe?w=900',rating:4.6,reviews:19,offers:[{vendor:'Prime Med Store',price:2100,stock:7,shipping:0,city:'Giza',verified:true}]}
];
export const initialVendors = [
 {id:1,name:'Cairo Dental Supply',city:'Cairo',rating:4.8,products:124,verified:true,shipping:55,description:'Professional dental materials and everyday clinic essentials.'},
 {id:2,name:'Prime Med Store',city:'Giza',rating:4.9,products:98,verified:true,shipping:0,description:'Carefully selected dental supplies with free shipping on eligible orders.'},
 {id:3,name:'Dental House',city:'Alexandria',rating:4.7,products:76,verified:true,shipping:70,description:'Dental instruments, endodontic products and clinic equipment.'}
];
