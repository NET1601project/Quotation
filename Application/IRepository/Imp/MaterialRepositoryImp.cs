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
    public class MaterialRepositoryImp : GenericRepositoryImp<Material>, IMaterialRepository
    {
        public MaterialRepositoryImp(AppDBContext context) : base(context)
        {
        }

        public async Task<List<Material>> GetAll()
        {
            return await _context.Set<Material>().ToListAsync();
        }

        public async Task<Material> GetMaterialById(Guid id)
        {
            var check = await _context.Set<Material>().Include(c => c.QuoteDetails).FirstOrDefaultAsync(c => c.MaterialID == id);
            if (check == null)
            {
                throw new Exception("not found");
            }
            return check;
        }

        public async Task<List<Material>> GetMaterialsWithGTStock0()
        {
            return await _context.Set<Material>().Where(c => c.Stock > 0).ToListAsync();
        }
    }
}
