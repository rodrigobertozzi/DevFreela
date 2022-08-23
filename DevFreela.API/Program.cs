using DevFreela.Infrastructure.Persistence;
using MediatR;
using DevFreela.Application.Commands.CreateProject;
using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs"); 
builder.Services.AddDbContext<DevFreelaDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(CreateProjectCommand));
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
