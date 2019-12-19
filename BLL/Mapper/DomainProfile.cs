using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using BLL.DTOs;
using DAL.Models.Entities;

namespace BLL.Mapper
{
    class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();

            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();

            CreateMap<CartItem, CartItemDTO>();
            CreateMap<CartItemDTO, CartItem>();

            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<FeedbackDTO, Feedback>();
        }
    }
}
