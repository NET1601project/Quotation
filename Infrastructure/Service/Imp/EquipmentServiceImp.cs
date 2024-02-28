using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class EquipmentServiceImp : IEquipmentService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public EquipmentServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseEquipment> Add(CreateEquipment create)
        {
            var add = _mapper.Map<Equipment>(create);
            await _unitofWork.EquipmentRepositoryImp.Add(add);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseEquipment>(add);
        }
    }
}
