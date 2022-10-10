using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OtoSoft.Plant.Business.Abstract;
using OtoSoft.Plant.Business.Concrete;
using OtoSoft.Plant.Business.Infrastructure.AutoMapper;
using OtoSoft.Plant.DataAccess.Abstract;
using OtoSoft.Plant.DataAccess.Concrete;
using OtoSoft.Plant.DataAccess.Concrete.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IHerbDal, HerbDal>();
builder.Services.AddScoped<IComplaintDal, ComplaintDal>();
builder.Services.AddTransient<IComplaintService, ComplaintManager>();
builder.Services.AddTransient<IHerbService, HerbManager>();
builder.Services.AddDbContext<HerbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Herb}/{action=Index}/{id?}"
    );
});
app.UseEndpoints(endpoint =>
{

    endpoint.MapControllerRoute(name: "Home", pattern: "{controller=home}/{action=Index}/{Id?}");

});

app.Run();
