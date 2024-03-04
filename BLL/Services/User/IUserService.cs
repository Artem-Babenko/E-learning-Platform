﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services;

public interface IUserService : IDisposable
{
    public Task<IEnumerable<UserDTO>> GetUsersList();

    public Task<UserDTO?> GetUserInfo(int id);
}
