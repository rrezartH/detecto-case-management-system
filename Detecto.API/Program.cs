using Detecto.API.Case.Services;
using Detecto.API.Case.Services.Implementation;
using Detecto.API.Case.Services.Interfaces;
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

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<CaseService>();
builder.Services.AddScoped<IViktimaService, ViktimaService>();
builder.Services.AddScoped<IDeshmitariService, DeshmitariService>();
builder.Services.AddScoped<IiDyshuariService, iDyshuariService>();
builder.Services.AddScoped<IProvaBiologjikeService, ProvaBiologjikeService>();
builder.Services.AddScoped<IProvaService, ProvaService>();
builder.Services.AddScoped<IProvaFizikeService, ProvaFizikeService>();
builder.Services.AddScoped<IGjurmaBiologjikeService, GjurmaBiologjikeService>();
builder.Services.AddScoped<IDeklarataService, DeklarataService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IPala, PalaService>();
builder.Services.AddScoped<ICaseService, CaseService>();
builder.Services.AddScoped<IFileService, FileService>();

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

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
