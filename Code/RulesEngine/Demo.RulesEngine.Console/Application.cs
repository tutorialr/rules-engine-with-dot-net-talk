namespace Demo.RulesEngine.Console;

/// <summary>
/// Application
/// </summary>
internal class Application
{
    private const string yes = "Y";
    private const string no = "N";

    private readonly IUsers _users;
    private readonly IEligibility _eligibility;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="users">Users</param>
    /// <param name="eligibility">Eligibility</param>
    public Application(IUsers users, IEligibility eligibility) =>
        (_users, _eligibility) =
        (users ?? throw new ArgumentNullException(nameof(users)),
        eligibility ?? throw new ArgumentNullException(nameof(eligibility)));

    /// <summary>
    /// Run
    /// </summary>
    public async Task Run()
    {
        bool loop;
        do
        {
            ClearOutput();
            SetOutput("Rules Engine Console Demo\n");
            var user = await GetUserByUsername();
            if (user.IsSuccess)
            {
                SetOutput($"Welcome {user.Username}!\n");
                var isEligibleForContent = await _eligibility.IsEligibleForContent(user);
                ViewContent(isEligibleForContent);
                var isEligibleForPrize = await _eligibility.IsEligibleForPrize(user);
                ViewPrize(isEligibleForPrize);
                loop = GetAnswer("Do you want to Continue?");
            }
            else
            {
                loop = GetAnswer("Username does not exist! Do you want to Continue?");
            }
        } while (loop);
    }

    /// <summary>
    /// Clear Output
    /// </summary>
    private static void ClearOutput() =>
        System.Console.Clear();

    /// <summary>
    /// Get Input
    /// </summary>
    /// <returns>String</returns>
    private static string GetInput() =>
        System.Console.ReadLine() ?? string.Empty;

    /// <summary>
    /// Set Output
    /// </summary>
    /// <param name="value">String</param>
    private static void SetOutput(string value) =>
        System.Console.WriteLine(value);

    /// <summary>
    /// Get Answer
    /// </summary>
    /// <param name="prompt">Prompt</param>
    /// <returns>True if Loop, False if not</returns>
    private static bool GetAnswer(string prompt)
    {
        SetOutput($"{prompt} [{yes}/{no}]");
        return GetInput().Equals(yes, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    /// View Content
    /// </summary>
    /// <param name="isEligibleForContent">Is Eligible For Content</param>
    private static void ViewContent(bool isEligibleForContent)
    {
        if (isEligibleForContent)
        {
            SetOutput("Welcome, You can see the Content:");
            SetOutput("- Thanks for Subscribing to Premium!");
        }
        else
            SetOutput("Sorry, You can't see our Content!");
    }

    /// <summary>
    /// View Prize
    /// </summary>
    /// <param name="isEligibleForPrize">Is Eligible for Prize</param>
    private static void ViewPrize(bool isEligibleForPrize)
    {
        if (isEligibleForPrize)
        {
            var isAward = GetAnswer("\nYou can also get our special Prize! Do you want it?");
            if (isAward)
                SetOutput("You have been given our special Prize!");
        }
    }

    /// <summary>
    /// Get User by Username
    /// </summary>
    /// <returns>User Model</returns>
    private async ValueTask<UserModel> GetUserByUsername()
    {
        SetOutput($"Enter Username:");
        var username = GetInput();
        return await _users.GetUser(username);
    }
}
