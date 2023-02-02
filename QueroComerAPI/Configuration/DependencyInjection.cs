using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QueroComer.Data;
using QueroComer.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QueroComer.Profiles;
using QueroComer.Services;
using QueroComer.Entidades.Interfaces;
using QueroComer.Entidades.Entidades;
using QueroComer.DTO.Produto; 
using QueroComer.DTO.Produto.Validator;
using QueroComer.DTO.User;
using QueroComer.DTO.User.Validator;
using QueroComer.DTO.Restaurante.Validator;
using QueroComer.DTO.Endereco.Validator;
using QueroComer.DTO.Endereco;
using QueroComer.DTO.Restaurante;
using QueroComer.DTO.Pedido;
using QueroComer.DTO.Pedido.Validator;
using QueroComer.Entidades.Entidades.Validator;
using QueroComer.DTO.PedidoProduto;
using QueroComer.DTO.PedidoProduto.Validator;

namespace QueroComer.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "QueroComerAPI",
                    Version = "v1",
                    Description = "Uma Web Api feita em .NET Core para o App Quero Comer",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = $@"JWT Authorization header using the Bearer scheme.
                         Enter 'Bearer'[space] and then your token in the text input below.
                         Example: \Bearer 12345abcdef\",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });

                c.IncludeXmlComments(string.Format(@"{0}\QueroComerAPI.XML",
                 System.AppDomain.CurrentDomain.BaseDirectory));
            });
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            //AutoMapper
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            }).CreateMapper());
            return services;
        }
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services, IConfiguration configuration)
        {
            //EntityFrameworkCore
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DB"));
            });
            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Dependency Injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoProdutoRepository, PedidoProdutoRepository>();
            

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IRestauranteService, RestauranteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPedidoProdutoService, PedidoProdutoService>();
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            //Fluent Validation
            services.AddScoped<IValidator<CreateEnderecoDTO>, CreateEnderecoDTOValidator>();
            services.AddScoped<IValidator<CreateUserDTO>, CreateUserDTOValidator>();
            services.AddScoped<IValidator<Login>, LoginValidator>();
            services.AddScoped<IValidator<CreateRestauranteDTO>, CreateRestauranteDTOValidator>();
            services.AddScoped<IValidator<CreateProdutoDTO>, CreateProdutoDTOValidator>();
            services.AddScoped<IValidator<CreatePedidoDTO>, CreatePedidoDTOValidator>();
            services.AddScoped<IValidator<CreatePedidoProdutoDTO>, CreatePedidoProdutoDTOValidator>();
            services.AddScoped<IValidator<ReadCategoriaRestauranteDTO>, ReadCategoriaRestauranteDTOValidator>();
            services.AddScoped<IValidator<UpdatePedidoDTO>, UpdatePedidoDTOValidator>();
            services.AddScoped<IValidator<UpdatePedidoProdutoDTO>, UpdatePedidoProdutoDTOValidator>();

            return services;
        }
        public static IServiceCollection AddIdentityCore(this IServiceCollection services)
        {
            //Identity
            services.AddIdentityCore<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                //SignIn Options
                //options.SignIn.RequireConfirmedAccount = true;
                //options.SignIn.RequireConfirmedEmail = true;

                //User Options
                options.User.RequireUniqueEmail = true;
            });

            return services;
        }
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //JWT
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            return services;
        }
    }
}
