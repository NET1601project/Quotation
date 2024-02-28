using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitOfWork
{
    public interface IUnitofWork
    {
        ICustomerRepository CustomerRepositoryImp { get; }
        IAccountRepository AccountRepositoryImp { get; }
        IEquipmentRepository EquipmentRepositoryImp { get; }
        IMaterialRepository MaterialRepositoryImp { get; }
        IProjectRepository ProjectRepositoryImp { get; }
        IQuoteDetailRepository QuoteRepositoryImp { get; }
        IRoomRepository RoomRepositoryImp { get; }
        IStaffRepository StaffRepositoryImp { get; }
        Task Commit();
        
    }
}
