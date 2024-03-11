using Application;
using Application.IRepository;
using Application.IRepository.Imp;
using Domain;
using Infrastructure.Common.Mapper;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.Service;
using Infrastructure.Service.Imp;
using Infrastructure.Service.Imp.Security;
using Infrastructure.Service.Security;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using QuotionSystemSolution.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
builder.Services.DependencyInjection(configuration);

ODataConventionModelBuilder oData = new ODataConventionModelBuilder();
oData.EntitySet<Customer>("Customers");
oData.EntitySet<Account>("Accounts");
oData.EntitySet<Project>("Projects");
oData.EntitySet<Quote>("Quotes");
oData.EntitySet<Room>("Rooms");
oData.EntitySet<Staff>("Staffs");

var edmModel = oData.GetEdmModel();
builder.Services.AddControllers().AddOData(c => c.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100).AddRouteComponents("odata", edmModel));

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IUnitofWork, UnitofWork>();

builder.Services.AddTransient<IAccountService, AccountServiceImp>();
builder.Services.AddTransient<ICustomerServices, CustomerServiceImp>();
builder.Services.AddTransient<IMaterialService, MaterialServiceImp>();
builder.Services.AddTransient<IProjectService, ProjectServiceImp>();
builder.Services.AddTransient<IQuoteService, QuoteServiceImp>();
builder.Services.AddTransient<IRoomService, RoomServiceImp>();
builder.Services.AddTransient<IStaffService, StaffServiceImp>();
builder.Services.AddTransient<IAccountRepository, AccountRepositoryImp>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepositoryImp>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepositoryImp>();
builder.Services.AddTransient<IProjectRepository, ProjectRepositoryImp>();
builder.Services.AddTransient<IQuoteRepository, QuoteRepositoryImp>();
builder.Services.AddTransient<IRoomRepository, RoomRepositoryImp>();
builder.Services.AddTransient<IStaffRepository, StaffRepositoryImp>();
builder.Services.AddTransient<IQuoteDetailRepository, QuoteDetailRepository>();
builder.Services.AddTransient<IRoomDetailRepository, RoomDetailRepository>();
builder.Services.AddScoped<ITokensHandler, TokensHandler>();
builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddCors(c => c
//            .AddDefaultPolicy(b => b
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowAnyOrigin()));
builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseODataBatching();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
