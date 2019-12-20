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
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ItemDTO dto)
        {
            try
            {
                Item item = _mapper.Map<Item>(dto);
                await _unitOfWork.ItemRepository.Insert(item);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            Item item = await _unitOfWork.ItemRepository.GetById(id);
            _unitOfWork.ItemRepository.Delete(item);
            await _unitOfWork.Save();
        }

        public async Task<ItemDTO> Get(int id)
        {
            var res = await _unitOfWork.ItemRepository.GetById(id);
            return _mapper.Map<Item, ItemDTO>(res);
        }

        public async Task<IEnumerable<ItemDTO>> GetAll()
        {
            var res = await _unitOfWork.ItemRepository.GetAll();
            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(res);
        }

        public async Task<ItemDTO> Update(ItemDTO dto)
        {
            Item item = _mapper.Map<Item>(dto);
            _unitOfWork.ItemRepository.Update(item);
            await _unitOfWork.Save();
            return await Get(item.Id);
        }
    }
}
