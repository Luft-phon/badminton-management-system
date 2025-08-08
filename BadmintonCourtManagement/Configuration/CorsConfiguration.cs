using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BadmintonCourtManagement.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors(options =>             // đăng kí cấu hình CORS
            {
                options.AddPolicy("AllowReact", builder =>
                {
                    builder.WithOrigins("http://localhost:5173", "http://localhost:5174") // React call api from dev server
                           .AllowAnyHeader()                    // mọi loại header như Authorization, Content-type, api, method (GET, POST, ...)
                           .AllowAnyMethod()                    // dùng mọi loại như GET, POST, DELETE
                            .AllowCredentials();                // Nếu bạn dùng cookie/JWT
                });
            });

            return services;
        }

        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)  // giúp gọi hàm này trong Program.cs
        {
            return app.UseCors("AllowReact");
        }
    }
}
