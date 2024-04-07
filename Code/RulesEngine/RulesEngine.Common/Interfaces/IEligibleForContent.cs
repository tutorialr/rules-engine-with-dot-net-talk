namespace RulesEngine.Common.Interfaces;

/// <summary>
/// Eligible for Content
/// </summary>
public interface IEligibleForContent
{
    /// <summary>
    /// Registration Date
    /// </summary>
    public DateTime RegistrationDate { get; }

    /// <summary>
    /// Subscription Tier
    /// </summary>
    public SubscriptionTier SubscriptionTier { get; }
}

