using Wallets.Api.AppDependenciesConfiguration;
using Wallets.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.ConfigureDependencies();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.Run();
