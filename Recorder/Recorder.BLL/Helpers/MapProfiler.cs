using AutoMapper;
using Recorder.DAL.Entities.Models;
using Recorder.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorder.BLL.Helpers
{
    public class MapProfiler : Profile
    {
        public MapProfiler()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, AddOrderDTO>().ReverseMap();
            CreateMap<Order, GetOrderDTO>().ForMember(
                getOrderDTO => getOrderDTO.ClientName, opt => opt.MapFrom(c => $"{c.Client.FirstName} {c.Client.SecondName}"));
        }
    }
}
