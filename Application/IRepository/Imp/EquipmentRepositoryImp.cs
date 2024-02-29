using Application.IGenericRepository.Imp;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class EquipmentRepositoryImp : GenericRepositoryImp<Equipment>, IEquipmentRepository
    {
        public EquipmentRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Equipment>> GetEquipments()
        {
            return await _context.Set<Equipment>().ToListAsync();
        }
    }
}