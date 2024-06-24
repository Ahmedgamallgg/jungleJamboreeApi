using Infrastracture.Interfaces;
using Infrastracture.Intrfaces;
using Infrastracture.Reposatories;
using Infrastructure.Reposatories;
using Microsoft.AspNetCore.Mvc;
using Service.BirthdayService.Interface;
using Service.BirthdayService.Service;
using Service.BirthdayService.Service.Dtos;
using Service.CampService.Interface;
using Service.CampService.Service;
using Service.CampService.Service.Dtos;
using Service.ChildService.Interface;
using Service.ChildService.Services;
using Service.ChildService.Services.Dtos;
using Service.LocationService.Interface;
using Service.LocationService.Service;
using Service.LocationService.Service.Dto;
using Service.NewStaffService.Interface;
using Service.NewStaffService.Service;
using Service.NewStaffService.Service.Dtos;
using Service.OrderService.Interface;
using Service.OrderService.Service;
using Service.OrderService.Service.Dtos;
using Service.PaymentService.Interface;
using Service.PaymentService.Service;
using Service.TripsEventService.Interface;
using Service.TripsEventService.Service;
using Service.TripsEventService.Service.Dtos;
using Services.CasheService.Interface;
using Services.CasheService.Service;
using Services.TokenService.Interface;
using Services.TokenService.Services;
using Services.UserService;
using WebApi.HandelResponses;

namespace WebApi.Excetensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddControllers();



            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IChildService, ChildService>();
            services.AddScoped<IBirthdayService, BirthdayService>();
            services.AddScoped<ICampService, CampService>();
            services.AddScoped<INewStaffService, NewStaffService>();
            services.AddScoped<ITripsEventService, TripsEventService>();
            services.AddScoped<IlocationService, LocationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICasheService, CasheService>();








            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ChildProfile>();
                cfg.AddProfile<BirthdayProfile>();
                cfg.AddProfile<CampProfile>();
                cfg.AddProfile<NewStaffProfile>();
                cfg.AddProfile<EventsTripProfile>();
                cfg.AddProfile<LocationProfile>();
                cfg.AddProfile<OrderProfile>();
            });








            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState
                                              .Where(model => model.Value.Errors.Count > 0)
                                              .SelectMany(error => error.Value.Errors)
                                              .Select(error => error.ErrorMessage)
                                              .ToList();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);

                };
            });

            return services;
        }
    }
}
