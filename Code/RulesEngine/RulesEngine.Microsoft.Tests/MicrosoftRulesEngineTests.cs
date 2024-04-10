namespace RulesEngine.Microsoft.Tests;

/// <summary>
/// Microsoft Rules Engine Tests
/// </summary>
public class MicrosoftRulesEngineTests
{
    [TestCase("01-Jan-2024 12:00:00", "01-Jan-2023 12:00:00", SubscriptionTier.Premium, 30, true)]
    [TestCase("01-Jan-2024 12:00:00", "01-Jan-2023 12:00:00", SubscriptionTier.Basic, 30, false)]
    [TestCase("01-Jan-2024 12:00:00", "12-Dec-2023 12:00:00", SubscriptionTier.Premium, 30, false)]
    public async Task IsEligibleForContent_Valid(DateTime currentDate, DateTime registrationDate, 
        SubscriptionTier subscriptionTier, int registrationDateMinimumDaysOld, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddSingleton<IRulesConfig>(s => new RulesConfig(() => currentDate, 0, registrationDateMinimumDaysOld))
        .AddMicrosoftRulesEngine()
        .BuildServiceProvider();
        // Act
        var factory = services.GetRequiredService<IEligibleForContentFactory>();
        var model = new UserModel("username", registrationDate, DateTime.MinValue, subscriptionTier);
        var actual = await factory.Evaluate(model);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("01-Jan-2024 12:00:00", "01-Jan-2023 12:00:00", "18-Mar-1980", SubscriptionTier.Premium, 30, 25, true)]
    [TestCase("01-Jan-2024 12:00:00", "01-Jan-2023 12:00:00", "18-Mar-1980", SubscriptionTier.Basic, 30, 25, false)]
    [TestCase("01-Jan-2024 12:00:00", "12-Dec-2023 12:00:00", "18-Mar-1980", SubscriptionTier.Premium, 30, 25, false)]
    [TestCase("01-Jan-2024 12:00:00", "01-Jan-2023 12:00:00", "18-Mar-1980", SubscriptionTier.Premium, 30, 55, false)]
    public async Task IsEligibleForPrize_Valid(DateTime currentDate, DateTime registrationDate, DateTime dateOfBirth, 
        SubscriptionTier subscriptionTier, int registrationDateMinimumDaysOld, int dateOfBirthMinimumAge, bool expected)
    {
        // Arrange
        var services = new ServiceCollection()
        .AddSingleton<IRulesConfig>(s => new RulesConfig(() => currentDate, dateOfBirthMinimumAge, registrationDateMinimumDaysOld))
        .AddMicrosoftRulesEngine()
        .BuildServiceProvider();
        // Act 
        var factory = services.GetRequiredService<IEligibleForPrizeFactory>();
        var model = new UserModel("username", registrationDate, dateOfBirth, subscriptionTier);
        var actual = await factory.Evaluate(model);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
