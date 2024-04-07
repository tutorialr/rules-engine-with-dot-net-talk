namespace RulesEngine.Microsoft.Interfaces;

/// <summary>
/// Eligible for Content Factory
/// </summary>
public interface IEligibleForContentFactory
{
    /// <summary>
    /// Evaluate
    /// </summary>
    /// <param name="model">User Model</param>
    ///  <returns>True if Pass, False if Fail</returns>
    ValueTask<bool> Evaluate(UserModel model);
}