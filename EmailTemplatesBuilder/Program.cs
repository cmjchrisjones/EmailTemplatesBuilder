using EmailTemplatesBuilder.Data;
using EmailTemplatesBuilder.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
  
builder.Services.AddDbContext<EmailDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmailTemplatesBuilderContext")));

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IContentDescriptor, ContentDescriptorRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
