﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDA
    {
        UserModel Login(string taikhoan, string matkhau);
        UserModel GetUserById(int userId);
        List<UserModel> GetAllUsers();
        UserModel AddUser(UserModel userModel);
        UserModel UpdateUser(UserModel userModel);
        bool DeleteUser(int userId);
        bool ChangePassword(string tenTaiKhoan, string matKhauCu, string matKhauMoi);
        public bool ForgotPassword(string email, out string password);
    }
}
