namespace RulesEngine.Library.Interfaces;

/// <summary>
/// Users
/// </summary>
public interface IUsers
{
    /// <summary>
    /// Get User
    /// </summary>
    /// <param name="username">Username</param>
    /// <returns>User Model</returns>
    ValueTask<UserModel> GetUser(string username);

    /// <summary>
    /// List Users
    /// </summary>
    /// <returns>Enumerable of UserModel</returns>
    ValueTask<IEnumerable<UserModel>> ListUsers();
}
