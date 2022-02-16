using DeloitteProject.DataAccess;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using DeloitteProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IGetAllHotelsQuery, GetAllHotelsQuery>();
builder.Services.AddScoped<KeywordFilter>();
builder.Services.AddScoped<NameFilter>();
builder.Services.AddScoped<RatingFilter>();

builder.Services.AddTransient<Func<FilterType, IFilterService>>(serviceProvider => filterType =>
{
    switch (filterType)
    {
        case FilterType.Keyword:
            return serviceProvider.GetService<KeywordFilter>();

        case FilterType.Rating:
            return serviceProvider.GetService<RatingFilter>();

        default:
            return serviceProvider.GetService<NameFilter>();
    }
});

builder.Services.AddMvc();

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
    pattern: "{controller=Hotel}/{action=Index}");

app.Run();
