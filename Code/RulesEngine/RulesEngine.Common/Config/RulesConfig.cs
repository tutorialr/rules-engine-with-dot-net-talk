namespace RulesEngine.Common.Config;

/// <summary>
/// Rules Config
/// </summary>
public class RulesConfig : IRulesConfig
{
    private readonly Func<DateTime> _currentDateMethod;

    /// <summary>
    /// Current Date
    /// </summary>
    public DateTime CurrentDate => _currentDateMethod();

    /// <summary>
    /// Date Of Birth Minimum Age
    /// </summary>
    public int DateOfBirthMinimumAge { get; }

    /// <summary>
    /// Registered Date Minimum Days
    /// </summary>
    public int RegistrationDateMinimumDays { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="currentDateMethod">Current Date Method</param>
    /// <param name="dateOfBirthMinimumAge">Date Of Birth Minimum Age</param>
    /// <param name="registrationDateMinimumDays">Registration Date Minimum Days</param>
    public RulesConfig(Func<DateTime> currentDateMethod, int dateOfBirthMinimumAge, int registrationDateMinimumDays) =>
        (_currentDateMethod, DateOfBirthMinimumAge, RegistrationDateMinimumDays) =
        (currentDateMethod, dateOfBirthMinimumAge, registrationDateMinimumDays);
}
