namespace RulesEngine.Microsoft.Workflows;

/// <summary>
/// Is Eligible for Promotion Workflow
/// </summary>
internal class IsEligibleForContentWorkflow : BaseWorkflow
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsEligibleForContentWorkflow() : base(nameof(IsEligibleForContentWorkflow),
        [new MinimumDaysRule(), new IsSubscriptionTierPremiumRule()]) 
    { }
}
