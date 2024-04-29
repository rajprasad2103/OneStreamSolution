using OneStreamBlazor.Components;
using OneStreamBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<ITokenServices, TokenServices>(s =>
{
    s.BaseAddress = new Uri(@"https://localhost:7141/");
});

builder.Services.AddHttpClient<IEmployeeServices, EmployeeServices>(s =>
{
    s.BaseAddress = new Uri(@"https://localhost:7017/");
});

builder.Services.AddHttpClient<IDepartmentService, DepartmentServices>(s =>
{
    s.BaseAddress = new Uri(@"https://localhost:7189/"); 
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
