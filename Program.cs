using Imanol_Acosta_AP1_P2.Components;
using Imanol_Acosta_AP1_P2.DAL;
using Imanol_Acosta_AP1_P2.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddRazorPages();

var Constr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContextFactory<Contexto>(options =>
    options.UseSqlServer(Constr));

// Registro de servicios personalizados
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<EntradaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
