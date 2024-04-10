await new ServiceCollection().AddServices(
() => DateTime.UtcNow,
Constants.DateOfBirthMinimumAge,
Constants.RegistrationDateMinimumDays)
.AddScoped<Application>()
.BuildServiceProvider()
.GetService<Application>()!.Run();