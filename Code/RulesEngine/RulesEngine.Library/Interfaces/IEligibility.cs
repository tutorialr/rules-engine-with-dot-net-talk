namespace RulesEngine.Library.Interfaces;

/// <summary>
/// Eligibility
/// </summary>
public interface IEligibility
{
    /// <summary>
    /// Is Eligible for Prize
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    ValueTask<bool> IsEligibleForPrize(UserModel model);

    /// <summary>
    /// Is Eligible for Promotion
    /// </summary>
    /// <param name="model">User Model</param>
    /// <returns>True if Is, False if Not</returns>
    ValueTask<bool> IsEligibleForContent(UserModel model);
}
