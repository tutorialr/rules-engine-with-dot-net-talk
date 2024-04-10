namespace RulesEngine.Microsoft.Workflows;

/// <summary>
/// Is Eligible for Prize Workflow
/// </summary>
internal class IsEligibleForPrizeWorkflow : BaseWorkflow
{
    /// <summary>
    /// Constructor
    /// </summary>
    public IsEligibleForPrizeWorkflow() : base(nameof(IsEligibleForPrizeWorkflow), 
        [new MinimumAgeRule()]) 
    { }
}
