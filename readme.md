builder.Services.AddScoped<Service>();
برای شناسایه کردن سرویس به DI هست در پروژهای بزگ داخل فایل حداگانه 

# Scoped / Singleton / Transient
Transient → هر بار یک instance جدید
Scoped    → در هر HTTP Request یک instance
Singleton → کل Application یک instance
# DI Lifetime
# Migration
 /dotnet ef migrations add InitialCreate
 /dotnet ef database update
 /dotnet ef migrations list
 # Policy-Based Authorization
 builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanDeleteProducts", policy =>
        policy.RequireRole("Admin"));
});
## !!!OnModelCreating
