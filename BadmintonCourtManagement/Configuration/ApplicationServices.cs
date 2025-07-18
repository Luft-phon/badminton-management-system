using BadmintonCourtManagement.Application.Interface;
using BadmintonCourtManagement.Application.Service;
using BadmintonCourtManagement.Application.UseCase;
using BadmintonCourtManagement.Application.Utils;
using BadmintonCourtManagement.Domain.Interface;
using BadmintonCourtManagement.Infrastructure.Repository;

namespace BadmintonCourtManagement.Configuration
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<ICustomerService, CustomerService>();
            //builder.Services.AddScoped<ApplicationDbContext>();
            services.AddScoped<CustomerUseCase>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<BookingUseCase>();
            services.AddScoped<BookingValidation>();
            services.AddScoped<ICourtService, CourtService>();
            services.AddScoped<CourtUseCase>();
            services.AddScoped<ICourtRepo, CourtRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserUseCase>();
            services.AddScoped<TokenValidation>();
            services.AddScoped<ITokenRepo, TokenRepo>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<EmailValidation>();
            services.AddScoped<IBookingRepo, BookingRepo>();
            return services;
        }
    }
}
