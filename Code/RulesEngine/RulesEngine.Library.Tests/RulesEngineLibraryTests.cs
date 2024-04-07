namespace RulesEngine.Library.Tests;

/// <summary>
/// Rules Engine Library Tests
/// </summary>
public class RulesEngineLibraryTests
{
    [TestCase("recent", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("registered", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("premium", "01-Jan-2024 12:00:00", 24, 30, true)]
    [TestCase("youngrecent", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("youngregistered", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("youngpremium", "01-Jan-2024 12:00:00", 24, 30, true)]
    public async Task IsEligibleForContent_Valid(string username, DateTime currentDate, 
        int dateOfBirthMinimumAge, int registrationDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddServices(() => currentDate, dateOfBirthMinimumAge, registrationDateMinimumDaysOld)
        .BuildServiceProvider();
        // Act
        var eligibility = services.GetRequiredService<IEligibility>();
        var users = services.GetRequiredService<IUsers>();
        var model = await users.GetUser(username);
        var actual = await eligibility.IsEligibleForContent(model);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("recent", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("registered", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("premium", "01-Jan-2024 12:00:00", 24, 30, true)]
    [TestCase("youngrecent", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("youngregistered", "01-Jan-2024 12:00:00", 24, 30, false)]
    [TestCase("youngpremium", "01-Jan-2024 12:00:00", 24, 30, false)]
    public async Task IsEligibleForPrize_Valid(string username, DateTime currentDate, 
        int dateOfBirthMinimumAge, int registrationDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddServices(() => currentDate, dateOfBirthMinimumAge, registrationDateMinimumDaysOld)
        .BuildServiceProvider();
        // Act
        var eligibility = services.GetRequiredService<IEligibility>();
        var users = services.GetRequiredService<IUsers>();
        var model = await users.GetUser(username);
        var actual = await eligibility.IsEligibleForPrize(model);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}