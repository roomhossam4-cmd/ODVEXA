# ODVEXA Dental Marketplace — Full-stack MVP

A new ODVEXA-branded dental-supplies marketplace inspired by multi-vendor dental marketplaces.

## Frontend
React 19 + Vite. Includes responsive storefront, catalog, category navigation, search, sorting, store filter, product detail offer comparison, cart, demo checkout, customer order history, store directory and admin workspace.

Run:
```bash
cd frontend
npm install
npm run dev
```

## Backend
ASP.NET Core 10 Web API + EF Core SQLite. Includes:
- Product catalog CRUD
- Vendor CRUD/listing
- Vendor offer create/update
- Customer registration/login with PBKDF2 password hashing and JWT
- Admin-seeded account
- Order creation/list/status update
- Product reviews endpoints
- Seeded sample products, vendors and offers
- Swagger in Development

Run:
```bash
cd backend/ODVEXA.API
dotnet restore
dotnet run --urls http://localhost:5080
```
Swagger: `http://localhost:5080/swagger`

Frontend API configuration:
Copy `frontend/.env.example` to `frontend/.env` and set `VITE_API_URL=http://localhost:5080/api`.

## Seeded admin account
- Email: `admin@odvexa.com`
- Password: `Odvexa@123`

Change both the admin password and JWT signing key before any shared deployment. The current frontend still uses local demo state for storefront/cart/admin rendering; the API is implemented separately and the `src/api.js` client is provided for wiring remaining screens. Do not treat demo checkout as a real payment transaction.

## Important before production
This is a runnable MVP foundation, not a production-certified commerce platform. Real payment collection, shipping integrations, email/SMS, image uploads, full API-to-UI integration, customer-owned order authorization, vendor-specific fulfillment, tax/invoice rules, audit logs, security review, automated tests, backups and deployment configuration remain required. Do not use sample products/prices as real medical-product offers. Verify regulatory requirements, product registrations, expiry/lot tracking and vendor authorization for the operating market.
