using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShopProject.Application.Admins.Dto
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminDto, Admin>();
            CreateMap<Admin, AdminDto>();
            CreateMap<CreateAdminCommand, Admin>();
            CreateMap<UpdateAdminCommand, Admin>();
        }
    }
}
