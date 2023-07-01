﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp_ControleDeGastos.Models;

namespace WebApp_ControleDeGastos.Repository.Interface
{
    public interface IUser
    {
        List<User> GetAllUser();
        User GetUserById(long id);
        Task<User> AddUser(User user, IFormFile avatar);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(long id);
    }
}
