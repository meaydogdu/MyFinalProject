using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolver.AutoFac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);



//Alternatif mimariler
//Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject --> IoC Containers 
//AOP - Bir metodun onunde arkasinda hata verdiginde calisan kodlari icerir. Autofac AOP iceriyor
//builder.Services.AddSingleton<IproductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();
//services.AddScoped  arastir
//services.AddTransient  arastir
//.net IoC container yerine Autofac kullanmamizin nedeni AOP ozelligini kullanmak istememizdir

//Add Autofac Containder
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder=> {
           builder.RegisterModule(new AutofacBusinessModule());
       });


// Add services to the container.

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
