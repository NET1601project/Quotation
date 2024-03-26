using AutoMapper;
using Domain;
using Infrastructure.Common.Model;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.Common.Security;

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

            CreateMap<CreateRoom, Room>()
            .ForMember(p => p.RoomName, act => act.MapFrom(src => src.RoomName))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
            .ForMember(p => p.Size, act => act.MapFrom(src => src.Size));
            CreateMap<CreateProject, Project>()
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Rooms, act => act.MapFrom(src => src.createRooms))
            .ForMember(p => p.Bargain, act => act.MapFrom(src => src.Bargain))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName));


            //-----------------------------------------------------------------------

            CreateMap<UpdateProject, Project>()
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Bargain, act => act.MapFrom(src => src.Bargain))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName));

            //===============================================================
            CreateMap<CreateRoomDetail, RoomDetail>()
           .ForMember(p => p.Name, act => act.MapFrom(src => src.Name))
           .ForMember(p => p.NumberEquipment, act => act.MapFrom(src => src.NumberEquipment))
           .ForMember(p => p.Description, act => act.MapFrom(src => src.Description));

            //===============================================================
            CreateMap<CreateRoomDetailV2, RoomDetail>()
           .ForMember(p => p.Name, act => act.MapFrom(src => src.Name))
           .ForMember(p => p.RoomId, act => act.MapFrom(src => src.RoomId))
           .ForMember(p => p.NumberEquipment, act => act.MapFrom(src => src.NumberEquipment))
           .ForMember(p => p.Description, act => act.MapFrom(src => src.Description));

            CreateMap<CreateRoomsV2, Room>()
            .ForMember(p => p.RoomName, act => act.MapFrom(src => src.RoomName))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
            .ForMember(p => p.Details, act => act.MapFrom(src => src.CreateRoomDetails))
            .ForMember(p => p.Size, act => act.MapFrom(src => src.Size));
            CreateMap<CreateProjectV2, Project>()
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Rooms, act => act.MapFrom(src => src.createRooms))
            .ForMember(p => p.Rooms, act => act.MapFrom(src => src.createRooms))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName));

            //===============================================================

            CreateMap<Project, ResponseProject>()
            .ForMember(p => p.CustomerId, act => act.MapFrom(src => src.CustomerId))
            .ForMember(p => p.StartDate, act => act.MapFrom(src => src.StartDate))
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
            .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
            .ForMember(p => p.Bargain, act => act.MapFrom(src => src.Bargain))

            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName))
            .ForMember(p => p.RoomList, act => act.MapFrom(src => src.Rooms));

            CreateMap<Room, ResponseRoom>()
            .ForMember(p => p.RoomID, act => act.MapFrom(src => src.RoomID))
            .ForMember(p => p.RoomName, act => act.MapFrom(src => src.RoomName))
            .ForMember(p => p.Size, act => act.MapFrom(src => src.Size))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description));
            //=========================================================================

            CreateMap<Project, ResponseProjectV2>()
            .ForMember(p => p.CustomerId, act => act.MapFrom(src => src.CustomerId))
            .ForMember(p => p.StartDate, act => act.MapFrom(src => src.StartDate))
            .ForMember(p => p.EndDate, act => act.MapFrom(src => src.EndDate))
            .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
            .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
            .ForMember(p => p.ProjectName, act => act.MapFrom(src => src.ProjectName))
            .ForMember(p => p.Bargain, act => act.MapFrom(src => src.Bargain))
            .ForMember(p => p.RoomList, act => act.MapFrom(src => src.Rooms));
            CreateMap<Room, ResponseRoomV2>()
            .ForMember(p => p.RoomID, act => act.MapFrom(src => src.RoomID))
            .ForMember(p => p.RoomName, act => act.MapFrom(src => src.RoomName))
            .ForMember(p => p.Size, act => act.MapFrom(src => src.Size))
            .ForMember(p => p.ResponseRoomDetails, act => act.MapFrom(src => src.Details))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description));
            CreateMap<RoomDetail, ResponseRoomDetail>()
            .ForMember(p => p.Name, act => act.MapFrom(src => src.Name))
            .ForMember(p => p.RoomDetailId, act => act.MapFrom(src => src.RoomDetailId))
            .ForMember(p => p.NumberEquipment, act => act.MapFrom(src => src.NumberEquipment))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
            .ForMember(p => p.DateTime, act => act.MapFrom(src => src.DateTime));

            CreateMap<CreateQuote, Quote>()
                .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID));

            CreateMap<CreateQuoteV2, Quote>()
               .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
               .ForMember(p => p.QuoteDetails, act => act.MapFrom(src => src.CreateQuoteDetails));

            CreateMap<CreateQuoteDetail, QuoteDetails>()
               .ForMember(p => p.MaterialId, act => act.MapFrom(src => src.MaterialId))
               .ForMember(p => p.numberMaterial, act => act.MapFrom(src => src.numberMaterial));

            CreateMap<Quote, ResponseQuote>()
                .ForMember(p => p.QuoteID, act => act.MapFrom(src => src.QuoteID))
                .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
                .ForMember(p => p.NameProject, act => act.MapFrom(src => src.Project.ProjectName))
                .ForMember(p => p.ProjectID, act => act.MapFrom(src => src.ProjectID))
                .ForMember(p => p.TotalAmount, act => act.MapFrom(src => src.TotalAmount))
                .ForMember(p => p.ResponseQuoteDetails, act => act.MapFrom(src => src.QuoteDetails))
                .ForMember(p => p.StaffId, act => act.MapFrom(src => src.StaffId));

            CreateMap<QuoteDetails, ResponseQuoteDetails>()
                .ForMember(p => p.MaterialId, act => act.MapFrom(src => src.MaterialId))
                .ForPath(p => p.MaterialName, act => act.MapFrom(src => src.Material.MaterialName))
                .ForMember(p => p.DateTime, act => act.MapFrom(src => src.DateTime))
                .ForMember(p => p.NumberMaterial, act => act.MapFrom(src => src.numberMaterial))
                .ForMember(p => p.image, act => act.MapFrom(src => src.Material.Image))
                .ForMember(p => p.Price, act => act.MapFrom(src => src.Price));
            //CreateMap<RefreshTokenRequest, RefreshToken>()
            //     .ForMember(p => p.Token, act => act.MapFrom(src => src.RefreshToken));

            CreateMap<AccessToken, AuthenResponseMessToken>()
                .ForMember(p => p.Token, act => act.MapFrom(src => src.Token))
                .ForMember(p => p.Expiration, act => act.MapFrom(src => src.ExpirationTicks))
                .ForMember(p => p.RefreshToken, act => act.MapFrom(src => src.RefreshToken.Token));

        }

    }
}
