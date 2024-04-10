namespace RulesEngine.Microsoft.Factories;

/// <summary>
/// Eligible for Prize Factory
/// </summary>
internal class EligibleForPrizeFactory : BaseFactory, IEligibleForPrizeFactory
{
    private readonly IRulesConfig _config;
    private readonly IEligibleForContentFactory _factory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="engine">Rules Engine</param>
    /// <param name="config">Rules Config</param>
    /// <param name="factory">Eligible for Content Factory</param>
    public EligibleForPrizeFactory(IRulesEngine engine, IRulesConfig config, 
        IEligibleForContentFactory factory) : base(engine)
    {        
        ArgumentNullException.ThrowIfNull(config);
        ArgumentNullException.ThrowIfNull(factory);
        _config = config;
        _factory = factory;
        AddWorkflows(new IsEligibleForPrizeWorkflow());
    }

    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Pass, False if Fail</returns>
    public async ValueTask<bool> Evaluate(UserModel model) =>
        await _factory.Evaluate(model) && 
            await ExecuteWorkflowAnySuccess(nameof(IsEligibleForPrizeWorkflow), model, _config);
}
