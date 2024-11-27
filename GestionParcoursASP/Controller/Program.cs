using Application;
using Application.UseCases.Parcours;
using Application.UseCases.Personne;
using Application.UseCases.Session;
using Domain;
using Infrastructure.EF;
using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var corsPolicyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProfileMapper));

builder.Services.AddDbContext<GestionParcoursDbContext>(cfg => 
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")
    ));

builder.Services.AddScoped<IPersonneRepository, PersonneRepository>();
builder.Services.AddScoped<IParcoursRepository, ParcoursRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();

builder.Services.AddScoped<UseCaseFetchAllPersonnes>();
builder.Services.AddScoped<UseCaseCreatePersonne>();

builder.Services.AddScoped<UseCaseFetchAllParcours>();
builder.Services.AddScoped<UseCaseCreateParcours>();

builder.Services.AddScoped<UseCaseCreateSession>();
builder.Services.AddScoped<UseCaseCalculateAverageTime>();
builder.Services.AddScoped<UseCaseFetchByPersonneId>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(corsPolicyName);

app.UseResponseCaching();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();