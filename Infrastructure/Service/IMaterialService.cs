using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IMaterialService
    {
        Task<ResponseMaterial> Add(CreateMaterial create);
        Task<List<ResponseMaterial>> GetMaterial();
        Task<ResponseMaterial> GetMaterialById(Guid id);
    }
}
