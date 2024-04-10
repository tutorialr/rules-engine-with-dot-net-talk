namespace RulesEngine.Library.Internal;

/// <summary>
/// Eligibility
/// </summary>
internal class Eligibility : IEligibility
{
    private readonly IEligibleForPrizeFactory _eligibleForPrizeFactory;
    private readonly IEligibleForContentFactory _eligibleForContentFactory;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="eligibleForPrizeFactory">Eligible for Prize Factory</param>
    /// <param name="eligibleForContentFactory">Eligible for Content Factory</param>
    public Eligibility(IEligibleForPrizeFactory eligibleForPrizeFactory, IEligibleForContentFactory eligibleForContentFactory) =>
        (_eligibleForPrizeFactory, _eligibleForContentFactory) = (eligibleForPrizeFactory, eligibleForContentFactory);

    /// <summary>
    /// Is Eligible for Prize
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public ValueTask<bool> IsEligibleForPrize(UserModel model) =>
        _eligibleForPrizeFactory.Evaluate(model);

    /// <summary>
    /// Is Eligible for Content
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    public ValueTask<bool> IsEligibleForContent(UserModel model) =>
        _eligibleForContentFactory.Evaluate(model);
}