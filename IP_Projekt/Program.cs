using IP_Projekt;
using IP_Projekt.DB;
using IP_Projekt.DB.Models;
using IP_Projekt.DB.Repositories.ChatRepositories;
using IP_Projekt.DB.Repositories.DLoginRepositories;
using IP_Projekt.DB.Repositories.WizytaRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IP_Projekt.Hubs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IpprojContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ipprojCS"))
    );
builder.Services.AddTransient<IDLoginRepository, DLoginRepository>();
builder.Services.AddTransient<IChatRepository, ChatRepository>();
builder.Services.AddTransient<IWizytaRepository, WizytaRepository>();
builder.Services.AddDefaultIdentity<User>(options => { options.User.AllowedUserNameCharacters += @" "; }).AddEntityFrameworkStores<IpprojContext>();
//builder.Services.AddIdentity<User<string>, IdentityRole<string>>()
//                    .AddEntityFrameworkStores<IpprojContext>();
builder.Services.AddSignalR();


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
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");
app.Run();
