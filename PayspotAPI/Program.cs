using PayspotAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddIdentityServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Payspot API",
        Version = "v1",
        Description = "Middleware for Payspot Userinterface",
        Contact = new OpenApiContact {
            Name = "Prashant Kumar Snehi"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// startup tasks
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(userManager, roleManager);
}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
