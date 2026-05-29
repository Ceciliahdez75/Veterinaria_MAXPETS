using Microsoft.EntityFrameworkCore;
using Veterinaria_MaxPets.Components;
using Veterinaria_MaxPets.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("ApiProfesor", client =>
{
    
  //  client.BaseAddress = new Uri("https://api-udec-pweb-aedec9hxbugye0am.westus3-01.azurewebsites.net/");
// });

client.BaseAddress = new Uri("https://6a195ede489e47157519dc4f.mockapi.io");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
