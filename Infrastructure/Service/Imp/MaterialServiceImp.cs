using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class MaterialServiceImp : IMaterialService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

        public MaterialServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseMaterial> Add(CreateMaterial create)
        {
            
            var material = _mapper.Map<Material>(create);
            material.CreateDate = DateTime.Now;
            await _unitofWork.MaterialRepositoryImp.Add(material);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseMaterial>(material);
        }

        public async Task<List<ResponseMaterial>> GetMaterial()
        {
            return _mapper.Map<List<ResponseMaterial>>(await _unitofWork.MaterialRepositoryImp.GetAll());
        }
    }
}
