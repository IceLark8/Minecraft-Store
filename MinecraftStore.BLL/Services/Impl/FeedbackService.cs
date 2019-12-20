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
    public class FeedbackService : IFeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(FeedbackDTO dto)
        {
            try
            {
                Feedback teacher = _mapper.Map<Feedback>(dto);
                await _unitOfWork.FeedbackRepository.Insert(teacher);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            Feedback feedback = await _unitOfWork.FeedbackRepository.GetById(id);
            _unitOfWork.FeedbackRepository.Delete(feedback);
            await _unitOfWork.Save();
        }

        public async Task<FeedbackDTO> Get(int id)
        {
            var res = await _unitOfWork.FeedbackRepository.GetById(id);
            return _mapper.Map<Feedback, FeedbackDTO>(res);
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAll()
        {
            var res = await _unitOfWork.FeedbackRepository.GetAll();
            return _mapper.Map<IEnumerable<Feedback>, IEnumerable<FeedbackDTO>>(res);
        }

        public async Task<FeedbackDTO> Update(FeedbackDTO dto)
        {
            Feedback feedback = _mapper.Map<Feedback>(dto);
            _unitOfWork.FeedbackRepository.Update(feedback);
            await _unitOfWork.Save();
            return await Get(feedback.Id);
        }
    }
}
