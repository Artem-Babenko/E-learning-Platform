using Infrastructure.Attributes;
using BLL.DTO;

namespace BLL.Services;

[InterfaceForDI]
public interface IUserService : IDisposable
{
    public Task<IEnumerable<UserDTO>> GetUsersList();

    public Task<UserDTO?> GetUserInfo(int id);
}
