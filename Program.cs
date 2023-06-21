using ASPNetCoreIdentityCustomFields.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Vidly2;
using Vidly2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config =>
{
	var policy = new AuthorizationPolicyBuilder()
									 .RequireAuthenticatedUser()
									 .Build();
	config.Filters.Add(new AuthorizeFilter(policy));
	config.Filters.Add(new RequireHttpsAttribute());
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//options => options.SignIn.RequireConfirmedAccount = true

builder.Services
	.AddDefaultIdentity<ApplicationUser>()
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
		{
			facebookOptions.AppId = "925413788567516";
			facebookOptions.AppSecret = "58c5dbdf978a19ac7a3859850ae3b890";
		});

builder.Services.AddControllersWithViews();

Mapper.Initialize(c => c.AddProfile<MappingProfile>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
