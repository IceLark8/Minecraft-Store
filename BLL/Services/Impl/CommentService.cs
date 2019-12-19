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
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(CommentDTO dto)
        {
            try
            {
                Comment comment = _mapper.Map<Comment>(dto);
                await _unitOfWork.CommentRepository.Insert(comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            Comment comment = await _unitOfWork.CommentRepository.GetById(id);
            _unitOfWork.CommentRepository.Delete(comment);
        }

        public async Task<CommentDTO> Get(int id)
        {
            var res = await _unitOfWork.CommentRepository.GetById(id);
            return _mapper.Map<Comment, CommentDTO>(res);
        }

        public async Task<IEnumerable<CommentDTO>> GetAll()
        {
            var res = await _unitOfWork.CommentRepository.GetAll();
            return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(res);
        }

        public async Task<CommentDTO> Update(CommentDTO dto)
        {
            Comment comment = _mapper.Map<Comment>(dto);
            _unitOfWork.CommentRepository.Update(comment);
            return await Get(comment.Id);
        }
    }
}
