using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShermansLittleSecretWardrobe.Data;
using ShermansLittleSecretWardrobe.Models;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    WebRootPath = "wwwroot",
    Args = args
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)

//  .AddEntityFrameworkStores<ApplicationDbContext>();

  //  .AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Apply authorisation policies to Folders and Pages
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Roles", "RequireAdministratorRole");
    options.Conventions.AuthorizePage("/Admin", "RequireAdministratorRole");
    options.Conventions.AuthorizeFolder("/Orders", "RequireAuthentication");
});

/*builder.Services.AddRazorPages();*/

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});


builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    // Changed requiredlength to 8
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});


builder.Services.AddIdentity<IdentityUser, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// Create authorisation policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireAuthentication",
        policy => policy.RequireAuthenticatedUser());
});
/*builder.Services.AddAuthorization();*/

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();


//> dotnet ef migrations add [migration name]
//d> dotnet ef database update