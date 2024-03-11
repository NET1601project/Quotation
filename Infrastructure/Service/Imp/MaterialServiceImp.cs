using AutoMapper;
using Domain;
using Infrastructure.Common.Model.Request;
using Infrastructure.Common.Model.Response;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Security;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using static Infrastructure.Service.Imp.MaterialServiceImp;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;

namespace Infrastructure.Service.Imp
{
    public class MaterialServiceImp : IMaterialService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        private const string ApiUrl = "https://freeimage.host/api/1/upload";
        private const string ApiKey = "6d207e02198a847aa98d0a2a901485a5";
        private readonly HttpClient _httpClient;

        public MaterialServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler, HttpClient httpClient)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
            _httpClient = httpClient;
        }

        public async Task<ResponseMaterial> Add(CreateMaterial create)
        {
            var material = _mapper.Map<Material>(create);
            var image = await UploadImageAsync(create.Image);

            material.CreateDate = DateTime.Now;
            material.Image = image;
            await _unitofWork.MaterialRepositoryImp.Add(material);
            await _unitofWork.Commit();
            return _mapper.Map<ResponseMaterial>(material);
        }

        public async Task<List<ResponseMaterial>> GetMaterial()
        {
            return _mapper.Map<List<ResponseMaterial>>(await _unitofWork.MaterialRepositoryImp.GetAll());
        }

        public async Task<ResponseMaterial> GetMaterialById(Guid id)
        {
            return _mapper.Map<ResponseMaterial>(await _unitofWork.MaterialRepositoryImp.GetMaterialById(id));

        }
        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length <= 0)
            {
                throw new ArgumentException("Image cannot be null or empty", nameof(image));
            }


            using (var memoryStream = new MemoryStream())
            {
                var requestData = new MultipartFormDataContent();
                requestData.Add(new StringContent(ApiKey), "key");
                requestData.Add(new StringContent("upload"), "action");
                requestData.Add(new StreamContent(image.OpenReadStream()), "source", image.FileName);
                requestData.Add(new StringContent("json"), "format");

                var response = await _httpClient.PostAsync(ApiUrl, requestData);


                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonDocument.Parse(responseContent);
                var imageUrl = jsonResponse.RootElement.GetProperty("image").GetProperty("url").GetString();

                return imageUrl;
            }
        }
    }
}
