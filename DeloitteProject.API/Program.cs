using DeloitteProject.DataAccess;
using DeloitteProject.Domain.DataAccess;
using DeloitteProject.Domain.Models;
using DeloitteProject.Domain.Services;
using DeloitteProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc();
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


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
