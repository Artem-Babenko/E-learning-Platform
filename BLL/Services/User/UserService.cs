using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BLL.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly ILogger<UserService> logger;
    private readonly IUnitOfWork unitOfWork;
    private readonly IRepository<User> userRepository;

    public UserService(ILogger<UserService> logger)
    {
        mapper = AutoMapper.Mapper;
        unitOfWork = new UnitOfWork();
        this.logger = logger;
        userRepository = unitOfWork.GetRepository<User>();
        logger.LogInformation("UserService: Створення сервісу.");
    }

    // Отримання інформації про користувача.
    public async Task<UserDTO?> GetUserInfo(int id)
    {
        var user = await userRepository.GetAll()
                    .Include(user => user.Role)
                    .FirstOrDefaultAsync(user => user.Id == id);

        if(user == null)
        {
            logger.LogWarning("UserService: Не отримано дані користувача.");
            return null;
        }
        else
        {
            logger.LogInformation("UserService: Успішне отримання інформації прокористувача з репозиторію.");
            return mapper.Map<UserDTO>(user);
        }
    }

    // Отримання списку користувачів.
    public async Task<IEnumerable<UserDTO>> GetUsersList()
    {
        var users = await userRepository.GetAll()
                    .Include(user => user.Role)
                    .ToListAsync();

        logger.LogInformation("UserService: Успішне отримання списку користувачів з репозиторію.");
        return mapper.Map<List<UserDTO>>(users);
    }

    // Утилізація сервісу.
    public void Dispose()
    {
        unitOfWork.Dispose();
        logger.LogInformation("UserService: Утилізація сервісу та одиниці роботи.");
    }
}
