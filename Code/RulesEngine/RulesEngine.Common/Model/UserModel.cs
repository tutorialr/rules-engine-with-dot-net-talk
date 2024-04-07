namespace RulesEngine.Common.Model;

/// <summary>
/// User Model
/// </summary>
/// <param name="Username">User Name</param>
/// <param name="RegistrationDate">Registration Date</param>
/// <param name="DateOfBirth">Date of Birth</param>
/// <param name="SubscriptionTier">Subscription Tier</param>
public record UserModel(
    string Username, 
    DateTime RegistrationDate, 
    DateTime DateOfBirth, 
    SubscriptionTier SubscriptionTier) : 
    IEligibleForPrize, IEligibleForContent
{
    /// <summary>
    /// Empty
    /// </summary>
    public static UserModel Empty =>
        new(string.Empty, DateTime.MinValue, DateTime.MinValue, SubscriptionTier.Basic);

    /// <summary>
    /// Is Success
    /// </summary>
    public bool IsSuccess => 
        !string.IsNullOrEmpty(Username);
}
