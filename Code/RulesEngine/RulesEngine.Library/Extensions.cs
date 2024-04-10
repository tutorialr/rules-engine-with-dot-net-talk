namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add Services
    /// <param name="services">Service Collection</param>
    /// <param name="currentDateTime">Current Date Time</param>
    /// <param name="dateOfBirthMinimumAge">Date Of Birth Minimum Age</param>
    /// <param name="registrationDateMinimumDays">Registration Date Minimum Days</param>
    /// <returns>Service Collection</returns>
    public static IServiceCollection AddServices(this IServiceCollection services,
        Func<DateTime> currentDateTime, int dateOfBirthMinimumAge, int registrationDateMinimumDays) =>
        services
        .AddMicrosoftRulesEngine()
        .AddSingleton<IRulesConfig>(new RulesConfig(currentDateTime, dateOfBirthMinimumAge, registrationDateMinimumDays))
        .AddScoped<IEligibility, Eligibility>()
        .AddScoped<IUsers, Users>();
}