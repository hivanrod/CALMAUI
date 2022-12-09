//global using ApiCalCore2.Services.UserService;
using ApiCalcoreMAUI.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//.AddNewtonsoftJson(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          //builder.WithOrigins("https://localhost:7296",
                          //                    "https://localhost:7119",
                          //                    "https://localhost:7080",
                          //                    "https://calendario",
                          //                    "http://calendario",
                          //                    "https://apicalcore",
                          //                    "http://apicalcore",
                          //                    "https://calendario:443");
                          builder
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                      });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

//app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);


//app.UseAuthorization();




//app.MapRazorPages();
app.MapControllers();
//.RequireCors(MyAllowSpecificOrigins);
//app.MapFallbackToFile("index.html");


app.Run();
