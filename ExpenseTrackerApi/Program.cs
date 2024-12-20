using System.Text;
using System.Text.Json.Serialization;
using DataLayer;
using ExpenseTrackerApi.Authentication;
using ExpenseTrackerApi.Authentication.Models;
using ExpenseTrackerApi.Interfaces;
using ExpenseTrackerApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });


builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IExpense, ExpenseService>();

builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AuthDbContext>();

builder.Services.AddIdentityCore<AppUserModel>() //Service Collection
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(options =>
    {
        string? secret = builder.Configuration["JwtConfig:Secret"];
        string? issuer = builder.Configuration["JwtConfig:ValidIssuer"];
        string? audience = builder.Configuration["JwtConfig:ValidAudiences"];

        if (secret is null || issuer is null || audience is null)
        {
            throw new ApplicationException("Jwt is not set in the configuration");
        }

        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidIssuer = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        };
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Check if the roles exist, if not, create them 
using (IServiceScope serviceScope = app.Services.CreateScope())
{
    IServiceProvider services = serviceScope.ServiceProvider;
    
    //ensure the database is created
    DbContext dbContext = services.GetRequiredService<AuthDbContext>();
    //dbContext.Database.EnsureDeleted()
    dbContext.Database.EnsureCreated();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    if(!await roleManager.RoleExistsAsync(AppRoles.Admin))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.VipUser))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.VipUser));
    }

    if (!await roleManager.RoleExistsAsync(AppRoles.User))
    {
        await roleManager.CreateAsync(new IdentityRole(AppRoles.User));
    }
    
}

app.MapControllers();

app.Run();