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

            CreateMap<CreateEquipment, Equipment>()
            .ForMember(p => p.EquipmentName, act => act.MapFrom(src => src.EquipmentName))
            .ForMember(p => p.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(p => p.Note, act => act.MapFrom(src => src.Note));

            CreateMap<Equipment, ResponseEquipment>()
            .ForMember(p => p.EquipmentID, act => act.MapFrom(src => src.EquipmentID))
            .ForMember(p => p.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(p => p.UnitPrice, act => act.MapFrom(src => src.UnitPrice))
            .ForMember(p => p.Note, act => act.MapFrom(src => src.Note));

        }

    }
}
