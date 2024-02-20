using Application.IRepository;
using Application.IRepository.Imp;
using Domain;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.Service;
using Infrastructure.Service.Imp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IUnitofWork, UnitofWork>();

builder.Services.AddTransient<IAccountService, AccountServiceImp>();
builder.Services.AddTransient<ICustomerService, CustomerServiceImp>();
builder.Services.AddTransient<IEquipmentService, EquipmentServiceImp>();
builder.Services.AddTransient<IMaterialService, MaterialServiceImp>();
builder.Services.AddTransient<IProjectService, ProjectServiceImp>();
builder.Services.AddTransient<IQuoteDetailService, QuoteDetailServiceImp>();
builder.Services.AddTransient<IRoomService, RoomServiceImp>();
builder.Services.AddTransient<IStaffService, StaffServiceImp>();
builder.Services.AddTransient<IAccountRepository, AccountRepositoryImp>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepositoryImp>();
builder.Services.AddTransient<IEquipmentRepository, EquipmentRepositoryImp>();
builder.Services.AddTransient<IMaterialRepository, MaterialRepositoryImp>();
builder.Services.AddTransient<IProjectRepository, ProjectRepositoryImp>();
builder.Services.AddTransient<IQuoteDetailRepository, QuoteRepositoryImp>();
builder.Services.AddTransient<IRoomRepository, RoomRepositoryImp>();
builder.Services.AddTransient<IStaffRepository, StaffRepositoryImp>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
