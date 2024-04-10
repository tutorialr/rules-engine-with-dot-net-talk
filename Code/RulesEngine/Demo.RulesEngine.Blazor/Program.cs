var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
.AddServices(() => DateTime.UtcNow, Constants.DateOfBirthMinimumAge, Constants.RegistrationDateMinimumDays)
.AddScoped<Application>();

await builder.Build().RunAsync();
