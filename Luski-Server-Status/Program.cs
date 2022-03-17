WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
}); ;
WebApplication? app = builder.Build();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
