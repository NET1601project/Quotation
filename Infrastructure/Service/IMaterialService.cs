using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Microsoft.AspNetCore.Http;
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
        Task<ResponseMaterial> Edit(Guid id,CreateMaterial createMaterial);
        //Task<string> UploadImage(IFormFile imageFile);

    }
}
