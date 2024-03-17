using Microsoft.EntityFrameworkCore;
using PiDataEmailApp.Business.Abstract;
using PiDataEmailApp.Business.Concrete;
using PiDataEmailApp.Business.Mapping;
using PiDataEmailApp.DataAccess.Abstract;
using PiDataEmailApp.DataAccess.Concrete;
using PiDataEmailApp.DataAccess.Concrete.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


   
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PiDataDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("NpgsqlConnection"));
});
//auto mapper
builder.Services.AddAutoMapper(typeof(MapProfile));

//dependency injection
builder.Services.AddScoped<IKisiDal, KisiDal>();
builder.Services.AddScoped<IEpostaAdresiDal, EpostaAdresiDal>();
builder.Services.AddScoped<IEpostaGonderimDal, EpostaGonderimDal>();
builder.Services.AddScoped<IKisiService, KisiManager>();
builder.Services.AddScoped<IEpostaAdresiService, EpostaAdresiManager>();
builder.Services.AddScoped<IEpostaGonderimService, EpostaGonderimManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
