using EduSphere.Data;
using EduSphere.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv; // ako koristiš .env fajl
using SendGrid;

var builder = WebApplication.CreateBuilder(args);


Env.Load(".env");


// Add environment variables (za Docker/hosting ili sistemske varijable)
builder.Configuration.AddEnvironmentVariables();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// SendGrid
var sendGridKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY")
                  ?? throw new InvalidOperationException("SENDGRID_API_KEY is not set.");

// SendGridClient singleton
builder.Services.AddSingleton(new SendGridClient(sendGridKey));

// EmailService
builder.Services.AddScoped<IEmailService, SendGridEmailService>();

var app = builder.Build();

// Development middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
