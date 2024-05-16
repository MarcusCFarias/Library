using Library.Application.Services.Implementations;
using Library.Application.Services.Interfaces;
using Library.Domain.Interfaces.Repositories;
using Library.Infrastructure.Persistence;
using Library.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Library.Application.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.API.Configuration
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookValidator>());

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookLoanService, BookLoanService>();

            return services;
        }

        public static IServiceCollection AddAuthetication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Secret").Value))

                });


            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IRepositoryBook, RepositoryBook>();
            services.AddScoped<IRepositoryBookLoan, RepositoryBookLoan>();

            return services;
        }
    }
}
