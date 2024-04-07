namespace Demo.RulesEngine.Blazor;

/// <summary>
/// Application
/// </summary>
internal class Application
{
    private const string login = "/";
    private const string index = "/index";

    private readonly IUsers _users;
    private readonly IEligibility _eligibility;
    private readonly NavigationManager _navigation;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="users">Users</param>
    /// <param name="eligibility">Eligibility</param>
    /// <param name="navigation">Navigation</param>
    public Application(IUsers users, IEligibility eligibility, NavigationManager navigation) =>
        (_users, _eligibility, _navigation) =
        (users ?? throw new ArgumentNullException(nameof(users)),
        eligibility ?? throw new ArgumentNullException(nameof(eligibility)),
        navigation ?? throw new ArgumentNullException(nameof(navigation)));

    /// <summary>
    /// Login Model
    /// </summary>
    public LoginModel LoginModel { get; private set; } = new();

    /// <summary>
    /// User Model
    /// </summary>
    public UserModel UserModel { get; private set; } = UserModel.Empty;

    /// <summary>
    /// User Models
    /// </summary>
    public IEnumerable<UserModel> UserModels { get; private set; } = [];

    /// <summary>
    /// Is Eligible For Content
    /// </summary>
    public bool IsEligibleForContent { get; private set; }

    /// <summary>
    /// Is Eligible For Prize
    /// </summary>
    public bool IsEligibleForPrize { get; private set; }

    /// <summary>
    /// Is Prize Claimed
    /// </summary>
    public bool IsPrizeClaimed { get; private set; }

    /// <summary>
    /// Is Logged In
    /// </summary>
    public bool IsLoggedIn => UserModel.IsSuccess;

    /// <summary>
    /// Login
    /// </summary>
    public async Task Login()
    {
        UserModel = await _users.GetUser(LoginModel.Username);
        if (UserModel.IsSuccess)
        {
            IsPrizeClaimed = false;
            IsEligibleForContent = await _eligibility.IsEligibleForContent(UserModel);
            IsEligibleForPrize = await _eligibility.IsEligibleForPrize(UserModel);
            _navigation.NavigateTo(index);
        }
    }

    /// <summary>
    /// Fetch
    /// </summary>
    public async Task Fetch() =>
        UserModels = await _users.ListUsers();

    /// <summary>
    /// Logout
    /// </summary>
    public void Logout()
    {
        LoginModel = new();
        UserModel = UserModel.Empty;
        _navigation.NavigateTo(login);
    }

    /// <summary>
    /// Claim
    /// </summary>
    public void Claim() =>
        IsPrizeClaimed = !IsPrizeClaimed;
}