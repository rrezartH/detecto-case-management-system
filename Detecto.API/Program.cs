using Detecto.API.Case.Services.Implementation;
using Detecto.API.Configurations;
using Detecto.API.Data.Services.Implementation;
using Detecto.API.Data.Services.Implementation.PersonatServices;
using Detecto.API.Data.Services.Implementation.ProvatServices;
using Detecto.API.Data.Services.Interfaces;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DetectoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<CaseService>();
builder.Services.AddScoped<IViktimaService, ViktimaService>();
builder.Services.AddScoped<IDeshmitariService, DeshmitariService>();
builder.Services.AddScoped<IiDyshuariService, iDyshuariService>();
builder.Services.AddScoped<IProvaBiologjikeService, ProvaBiologjikeService>();
builder.Services.AddScoped<IProvaFizikeService, ProvaFizikeService>();
builder.Services.AddScoped<IGjurmaBiologjikeService, GjurmaBiologjikeService>();



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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
