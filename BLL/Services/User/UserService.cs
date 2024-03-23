using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IRepository<User> userRepository;

    public UserService(IUnitOfWork unitOfWork)
    {
        mapper = AutoMapper.Mapper;
        this.unitOfWork = unitOfWork;
        userRepository = unitOfWork.GetRepository<User>();
    }

    // Отримання інформації про користувача.
    public async Task<UserDTO?> GetUserInfo(int id)
    {
        var user = await userRepository.GetAll()
                    .Include(user => user.Role)
                    .FirstOrDefaultAsync(user => user.Id == id);

        return user != null ? mapper.Map<UserDTO>(user) : null;
    }

    // Отримання списку користувачів.
    public async Task<IEnumerable<UserDTO>> GetUsersList()
    {
        var users = await userRepository.GetAll()
                    .Include(user => user.Role)
                    .ToListAsync();

        return mapper.Map<List<UserDTO>>(users);
    }

    // Утилізація сервісу.
    public void Dispose()
    {
        unitOfWork.Dispose();
    }
}
