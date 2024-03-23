using BLL.DTO;
using BLL.IoCResolver;

namespace BLL.Services;

[InterfaceForDI]
public interface IUserService : IDisposable
{
    public Task<IEnumerable<UserDTO>> GetUsersList();

    public Task<UserDTO?> GetUserInfo(int id);
}
