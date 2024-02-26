using Application;
using Application.IRepository;
using Application.IRepository.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitOfWork.UnitOfWorkImp
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDBContext _context;

        private readonly ICustomerRepository _customerRepositoryImp;
        private readonly IAccountRepository _accountRepositoryImp;
        private readonly IEquipmentRepository _equipmentRepositoryImp;
        private readonly IMaterialRepository _materialRepositoryImp;
        private readonly IProjectRepository _projectRepositoryImp;
        private readonly IQuoteDetailRepository _quoteRepositoryImp;
        private readonly IRoomRepository _roomRepositoryImp;
        private readonly IStaffRepository _staffRepositoryImp;
        public UnitofWork(AppDBContext context)
        {
            _context = context;
            _customerRepositoryImp = new CustomerRepositoryImp(_context);
            _accountRepositoryImp = new AccountRepositoryImp(_context);
            _equipmentRepositoryImp = new EquipmentRepositoryImp(_context);
            _materialRepositoryImp = new MaterialRepositoryImp(_context);
            _projectRepositoryImp = new ProjectRepositoryImp(_context);
            _quoteRepositoryImp = new QuoteRepositoryImp(_context);
            _roomRepositoryImp = new RoomRepositoryImp(_context);
            _staffRepositoryImp = new StaffRepositoryImp(_context);
        }
        public ICustomerRepository CustomerRepositoryImp => _customerRepositoryImp;

        public IAccountRepository AccountRepositoryImp => _accountRepositoryImp;

        public IEquipmentRepository EquipmentRepositoryImp => _equipmentRepositoryImp;


        public IMaterialRepository MaterialRepositoryImp => _materialRepositoryImp;

        public IProjectRepository ProjectRepositoryImp => _projectRepositoryImp;

        public IQuoteDetailRepository QuoteRepositoryImp => _quoteRepositoryImp;

        public IRoomRepository RoomRepositoryImp => _roomRepositoryImp;

        public IStaffRepository StaffRepositoryImp => _staffRepositoryImp;

        public void Commit()
                       => _context.SaveChanges();

        public void CommitAsync()
                              => _context.SaveChangesAsync();

    }
}
