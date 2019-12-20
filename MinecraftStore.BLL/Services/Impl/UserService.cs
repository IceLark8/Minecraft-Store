using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using BLL.DTOs;
using AutoMapper;
using DAL.Models.Entities;
using DAL.UnitOfWork;
using DAL.Repositories;

namespace BLL.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        
        public UserService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(UserDTO dto)
        {
            try
            {
                User user = _mapper.Map<User>(dto);
                await _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            User user = await _unitOfWork.UserRepository.GetById(id);
            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.Save();
        }

        public async Task<UserDTO> Get(int id)
        {
            var res = await _unitOfWork.UserRepository.GetById(id);
            return _mapper.Map<User, UserDTO>(res);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var res = await _unitOfWork.UserRepository.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(res);
        }

        public async Task<UserDTO> Update(UserDTO dto)
        {
            User user = _mapper.Map<User>(dto);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();
            return await Get(user.Id);
        }
    }
}
