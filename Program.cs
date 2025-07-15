using Imanol_Acosta_AP1_P2.Components;
<<<<<<< HEAD
using Imanol_Acosta_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> e68a926ae3039d2226a2d3f355e22311a9a6183d

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

<<<<<<< HEAD

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



=======
>>>>>>> e68a926ae3039d2226a2d3f355e22311a9a6183d
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

<<<<<<< HEAD
app.Run();
=======
app.Run();
>>>>>>> e68a926ae3039d2226a2d3f355e22311a9a6183d
