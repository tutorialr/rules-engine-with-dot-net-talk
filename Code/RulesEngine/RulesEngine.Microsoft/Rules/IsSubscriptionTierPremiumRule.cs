namespace RulesEngine.Microsoft.Rules;

/// <summary>
/// Is Subscription Tier Premium Rule
/// </summary>
internal class IsSubscriptionTierPremiumRule : BaseRule
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsSubscriptionTierPremiumRule() : 
        base (nameof(IsSubscriptionTierPremiumRule),
        "input1.SubscriptionTier == SubscriptionTier.Premium") 
    { }
}