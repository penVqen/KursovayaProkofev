using Kursovaya.Pages;
using Kursovaya.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<SqliteUserDataService>();
builder.Services.AddScoped<GoalDataService>();
builder.Services.AddScoped<RscCalculatorService>();
builder.Services.AddScoped<GoalHistoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PadService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var baseDirectory = AppContext.BaseDirectory;
    var dbPath = Path.Combine(baseDirectory, "x.db");
    options.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddScoped<CurrentUserService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
