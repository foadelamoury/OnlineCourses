using Application;
using Application.Interfaces;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;


//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(opt =>
//{
//    opt.IdleTimeout = TimeSpan.FromSeconds(100000);
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.IsEssential = true;
//});







builder.Services.AddMvc();

//.AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
//.AddDataAnnotationsLocalization();



builder.Services.AddControllersWithViews();

//fluent Validation


//fluent Validation
//builder.Services.AddFluentValidationAutoValidation();

//fluent Validation
//builder.Services.AddValidatorsFromAssemblyContaining<Program>();


builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

builder.Services
  .AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);




var app = builder.Build();

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
//app.UseRequestLocalization(locOptions.Value);

if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseHsts();
}






app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
    await next();
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Country}/{action=Index}/{id?}");



});


app.Run();
