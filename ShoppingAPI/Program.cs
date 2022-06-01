using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using ShoppingAPI.Services;
using ShoppingAPI.Data;

using ShoppingAPI.Data.Repositories;

using ShoppingAPI.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<shoppingContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICrudRepository<shoppingItem, int>, shoppingRepository>();

builder.Services.AddScoped<ICrudService<shoppingItem, int>, shoppingService>();



builder.Services.AddDbContext<shoppingContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICrudRepository<productItem, int>, productRepository>();

builder.Services.AddScoped<ICrudService<productItem, int>, productService>();



builder.Services.AddCors(options =>

{

    options.AddPolicy(name: MyAllowSpecificOrigins,

    policy =>

    {

        policy.AllowAnyOrigin()

    .AllowAnyHeader()

    .AllowAnyMethod();

    });

});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c =>

{

    c.SwaggerDoc("v1", new OpenApiInfo

    {

        Title = "TodoRestAPI",

        Version =

    "v1"

    });

});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);//To EnableCors - CrossOrigin

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI();

}

app.UseAuthorization();

app.MapControllers();

app.Run();