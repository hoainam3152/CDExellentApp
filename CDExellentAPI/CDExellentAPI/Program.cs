using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using CDExellentAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ManagementDbContext>(option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("DB")
    ));

//Register Services
builder.Services.AddScoped<IAreaRepository, AreaService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<ITitleRepository, TitleService>();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IDistributorRepository, DistributorService>();
builder.Services.AddScoped<IVisitPlanRepository, VisitPlanService>();
builder.Services.AddScoped<ITaskRepository, TaskService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();
//builder.Services.AddScoped<IAreaRepository, AreaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
