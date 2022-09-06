using IP_Projekt;
using IP_Projekt.DB;
using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.ChatRepositories;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IpprojContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ipprojCS"))
    );
builder.Services.AddTransient<IDLoginRepository, DLoginRepository>();
builder.Services.AddTransient<IChatRepository, ChatRepository>();
builder.Services.AddDefaultIdentity<User>(options => { options.User.AllowedUserNameCharacters += @" "; }).AddEntityFrameworkStores<IpprojContext>();
//builder.Services.AddIdentity<User<string>, IdentityRole<string>>()
//                    .AddEntityFrameworkStores<IpprojContext>();



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

app.Run();
