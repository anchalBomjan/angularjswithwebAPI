using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Interface;
using TodoList.Mappings;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Register ApplicationDbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDo")));



builder.Services.AddTransient<DapperContext>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<ITodo, ToDoRepository>();
builder.Services.AddCors();

builder.Services.AddControllers();

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

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
.AllowCredentials()
.WithOrigins("http://127.0.0.1:5500/"));
app.UseAuthorization();

app.MapControllers();

app.Run();
