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
        IMaterialRepository MaterialRepositoryImp { get; }
        IProjectRepository ProjectRepositoryImp { get; }
        IQuoteRepository QuoteRepositoryImp { get; }
        IRoomRepository RoomRepositoryImp { get; }
        IStaffRepository StaffRepositoryImp { get; }
        IRoomDetailRepository RoomDetailRepositoryImp { get; }
        IQuoteDetailRepository QuoteDetailRepositoryImp { get; }
        Task Commit();
        
    }
}
