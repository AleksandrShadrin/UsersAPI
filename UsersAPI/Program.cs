using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;
using UsersAPI.Repository.UsersRep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("UsersDbConnection");
builder.Services.AddDbContext<UsersDbContext>(options => {
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
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
