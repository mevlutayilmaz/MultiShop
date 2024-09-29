using MultiShop.Image.Extensions;
using MultiShop.Image.Services.Storage.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddImageServices(builder.Configuration);
builder.Services.AddStorage<AzureStorage>();

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

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
