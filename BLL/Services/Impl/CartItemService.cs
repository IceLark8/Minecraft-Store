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
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartItemService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(CartItemDTO dto)
        {
            try
            {
                CartItem cartItem = _mapper.Map<CartItem>(dto);
                await _unitOfWork.CartItemRepository.Insert(cartItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            CartItem cartItem = await _unitOfWork.CartItemRepository.GetById(id);
            _unitOfWork.CartItemRepository.Delete(cartItem);
        }

        public async Task<CartItemDTO> Get(int id)
        {
            var res = await _unitOfWork.CartItemRepository.GetById(id);
            return _mapper.Map<CartItem, CartItemDTO>(res);
        }

        public async Task<IEnumerable<CartItemDTO>> GetAll()
        {
            var res = await _unitOfWork.CartItemRepository.GetAll();
            return _mapper.Map<IEnumerable<CartItem>, IEnumerable<CartItemDTO>>(res);
        }

        public async Task<CartItemDTO> Update(CartItemDTO dto)
        {
            CartItem cartItem = _mapper.Map<CartItem>(dto);
            _unitOfWork.CartItemRepository.Update(cartItem);
            return await Get(cartItem.Id);
        }
    }
}
