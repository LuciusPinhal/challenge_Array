using Microsoft.EntityFrameworkCore;
using APISquare.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder
//    .Services
//    .AddDbContext<SquareContext>(options => options.UseInMemoryDatabase
//    ("dbContracts"));

builder.Services.AddDbContext<SquareContext>(oprions =>
  oprions.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SquareContext, SquareContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
