using WellsFargo.EmployeeManagement.BusinessObjects.Interfaces;
using WellsFargo.EmployeeManagement.RepositoryLayer;
using WellsFargo.EmployeeManagement.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoginRepository, LoginRepositary>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeManager, EmployeeService>();
builder.Services.AddScoped<ILoginManager, LoginService>();
builder.Services.AddScoped<IPaymentDetailRepository, PaymentDetailRepository>();
builder.Services.AddScoped<IPaymentDetailService, PaymentDetailService>();
builder.Services.AddScoped<IStudentDetailsService, StudentDetailsService>();
builder.Services.AddScoped<IStudentDetailsRepository, StudentDetailsRepository>();
builder.Services.AddTransient<IAceService, AceService>();
builder.Services.AddTransient<IAceRepository, AceRepository>();
builder.Services.AddSingleton<ErrorLogRepository>(); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();
app.Run();
