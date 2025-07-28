using Application.Business.Interfaces;
using Application.DTOs;
using Domain.Entities;
using Domain.Repository.Base;
using Domain.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Domain.Business.Services
{
    public class AuthService : IAuthService  
    { 
        IAuthRepository _authRepository;
        IMapper _mapper;
        IPasswordHasher _passwordHasher;

        public AuthService(IAuthRepository authRepository , IMapper mapper , IPasswordHasher passwordHasher)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }


        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _authRepository.LoginAsync(username , password);
            try
            {
                if(user != null)
                {
                    if(!_passwordHasher.VerifyPassword(password , user.Password))
                    {
                        return null;
                    }

                    return user;
                }
            } catch (Exception ex) 
            {
                Console.WriteLine($"hata: {ex.Message}");
            }

            return user;
        }

        public Task RegisterAsync(RegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);
            string hashedPassword = _passwordHasher.HashPassword(dto.Password);
            user.Password = hashedPassword;
            
            return _authRepository.RegisterAsync(user);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _authRepository.GetByUsernameAsync(username);
        }

        
    }
}
