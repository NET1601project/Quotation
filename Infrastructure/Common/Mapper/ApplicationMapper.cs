using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CreateMaterial, Material>()
            .ForMember(p => p.MaterialName, act => act.MapFrom(src => src.MaterialName))
            .ForMember(p => p.Stock, act => act.MapFrom(src => src.Stock))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
            .ForMember(p => p.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(p => p.Image, act => act.MapFrom(src => src.Image));

            CreateMap<Material, ResponseMaterial>()
            .ForMember(p => p.MaterialName, act => act.MapFrom(src => src.MaterialName))
            .ForMember(p => p.MaterialID, act => act.MapFrom(src => src.MaterialID))
            .ForMember(p => p.Stock, act => act.MapFrom(src => src.Stock))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
            .ForMember(p => p.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(p => p.Image, act => act.MapFrom(src => src.Image));


            CreateMap<Account, ResponseAccount>()
            .ForMember(p => p.AccountID, act => act.MapFrom(src => src.AccountID))
            .ForMember(p => p.Role, act => act.MapFrom(src => src.Role))
            .ForMember(p => p.Username, act => act.MapFrom(src => src.Username))
            .ForMember(p => p.Password, act => act.MapFrom(src => src.Password));

            CreateMap<Customer, ResponseCustomer>()
            .ForMember(p => p.Email, act => act.MapFrom(src => src.Email))
            .ForMember(p => p.CustomerID, act => act.MapFrom(src => src.CustomerID))
            .ForMember(p => p.LastName, act => act.MapFrom(src => src.LastName))
            .ForMember(p => p.FirstName, act => act.MapFrom(src => src.FirstName))
            .ForMember(p => p.CreateDate, act => act.MapFrom(src => src.CreateDate))
            .ForMember(p => p.Address, act => act.MapFrom(src => src.Address))
            .ForMember(p => p.Phone, act => act.MapFrom(src => src.Phone))
            .ForMember(p => p.Account, act => act.MapFrom(src => src.Account));

            CreateMap<Staff, ResponseStaff>()
            .ForMember(p => p.StaffName, act => act.MapFrom(src => src.StaffName))
            .ForMember(p => p.StaffId, act => act.MapFrom(src => src.StaffId))
            .ForMember(p => p.CreateDate, act => act.MapFrom(src => src.CreateDate))
            .ForMember(p => p.Contact, act => act.MapFrom(src => src.Contact))
            .ForMember(p => p.Account, act => act.MapFrom(src => src.Account));

            CreateMap<CreateProject, Project>()
            .ForMember(p => p.StaffId, act => act.MapFrom(src => src.StaffId))
            .ForMember(p => p.CustomerId, act => act.MapFrom(src => src.CustomerId))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName))
            .ForMember(p => p.Status, act => act.MapFrom(src => src.Status));

            CreateMap<Project, ResponseProject>()
            .ForMember(p => p.StaffId, act => act.MapFrom(src => src.StaffId))
            .ForMember(p => p.CustomerId, act => act.MapFrom(src => src.CustomerId))
            .ForMember(p => p.StartDate, act => act.MapFrom(src => src.StartDate))
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
            .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName));

            CreateMap<Room, ResponseRoom>()
            .ForMember(p => p.ProjectId, act => act.MapFrom(src => src.ProjectId))
            .ForMember(p => p.RoomID, act => act.MapFrom(src => src.RoomID))
            .ForMember(p => p.RoomName, act => act.MapFrom(src => src.RoomName))
            .ForMember(p => p.Size, act => act.MapFrom(src => src.Size))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description));

            CreateMap<CreateQuote, QuoteDetail>()
                .ForMember(p => p.MaterialID, act => act.MapFrom(src => src.MaterialID))
                .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
                .ForMember(p => p.QuoteNumber, act => act.MapFrom(src => src.QuoteNumber));

            CreateMap<QuoteDetail, ResponseQuote>()
                .ForMember(p => p.MaterialID, act => act.MapFrom(src => src.MaterialID))
                .ForMember(p => p.QuoteID, act => act.MapFrom(src => src.QuoteID))
                .ForMember(p => p.QuoteDate, act => act.MapFrom(src => src.QuoteDate))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
                .ForMember(p => p.TotalAmount, act => act.MapFrom(src => src.TotalAmount))
                .ForMember(p => p.QuoteNumber, act => act.MapFrom(src => src.QuoteNumber));
        }

    }
}
