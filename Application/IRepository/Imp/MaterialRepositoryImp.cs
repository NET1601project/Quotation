﻿using Application.IGenericRepository.Imp;
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
            return await _context.Set<Material>().Include(c=>c.QuoteDetails).FirstOrDefaultAsync(c=>c.MaterialID==id);
        }
    }
}
