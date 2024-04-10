namespace RulesEngine.Microsoft.Factories;

/// <summary>
/// Eligible for Content Factory
/// </summary>
internal class EligibleForContentFactory : BaseFactory, IEligibleForContentFactory
{
    private readonly IRulesConfig _config;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="engine">Rules Engine</param>
    /// <param name="config">Rules Config</param>
    public EligibleForContentFactory(IRulesEngine engine, IRulesConfig config) : base(engine)
    {
        ArgumentNullException.ThrowIfNull(config);
        _config = config;
        AddWorkflows(new IsEligibleForContentWorkflow());
    }

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Pass, False if Fail</returns>
    public ValueTask<bool> Evaluate(UserModel model) =>
        ExecuteWorkflowAllSuccess(nameof(IsEligibleForContentWorkflow), model, _config);
}