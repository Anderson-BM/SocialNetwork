using Microsoft.EntityFrameworkCore;

using SocialNetwork.Core.Application;
using SocialNetwork.Infrastruture.Persistence;
using SocialNetwork.Infrastruture.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Registra todos los servicios aquí:
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();

// Añade también el HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Después que ya registraste todo:
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
