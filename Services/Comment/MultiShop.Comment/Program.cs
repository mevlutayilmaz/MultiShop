using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommentContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL Server")));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
