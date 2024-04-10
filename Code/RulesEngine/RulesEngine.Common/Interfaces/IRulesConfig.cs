namespace RulesEngine.Common.Interfaces;

/// <summary>
/// Rules Config
/// </summary>
public interface IRulesConfig
{
    /// <summary>
    /// Current Date
    /// </summary>
    public DateTime CurrentDate { get; }

    /// <summary>
    /// Date Of Birth Minimum Age
    /// </summary>
    public int DateOfBirthMinimumAge { get; }

    /// <summary>
    /// Registration Date Minimum Days
    /// </summary>
    public int RegistrationDateMinimumDays { get; }
}