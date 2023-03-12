using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NT_TECH.Areas.Identity.Data;
using NT_TECH.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NT_TECHContextConnection") ?? throw new InvalidOperationException("Connection string 'NT_TECHContextConnection' not found.");

builder.Services.AddDbContext<NT_TECHContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<NT_TECHUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<NT_TECHContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 app.MapRazorPages();


app.Run();
