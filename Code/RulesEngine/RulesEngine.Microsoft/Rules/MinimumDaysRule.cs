namespace RulesEngine.Microsoft.Rules;

/// <summary>
/// Minimum Days Rule
/// </summary>
internal class MinimumDaysRule : BaseRule
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MinimumDaysRule() : base(nameof(MinimumDaysRule),
        $"Helper.GetDays(input1.RegistrationDate, input2.CurrentDate) >= input2.RegistrationDateMinimumDays") 
    { }
}

