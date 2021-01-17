using System.Threading.Tasks;

namespace ICS.WebAppCore
{
	public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        Task<bool> IsValidUserCredentialsAsync(string userName, string password);
        string GetUserRole(string userName);
    }
}
