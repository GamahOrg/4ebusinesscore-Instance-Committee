using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Committees.API.Extension
{
    public static class ServiceExtension
    {
        public static void AddUnitOfWorkRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
        }

        public static void AddDiServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationLayer)));
            services.AddAutoMapper((typeof(ApplicationLayer)));
            services.AddHttpContextAccessor();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IResponseHelper, ResponseHelper>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddSingleton<ITokenService, TokenService>();
        }

        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCors",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });
        }

        public static void AddRateLimitings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(options =>
            {
                var rateLimitSection = configuration.GetSection("RateLimit");
                var permitLimit = rateLimitSection.GetValue<int>("PermitLimit");
                var queueLimit = rateLimitSection.GetValue<int>("QueueLimit");
                var windowSeconds = rateLimitSection.GetValue<int>("WindowSeconds");
                options.AddFixedWindowLimiter("FixedWindowPolicy", opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(windowSeconds);
                    opt.PermitLimit = permitLimit;
                    opt.QueueLimit = queueLimit;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = 429;
            });
        }

        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                options.EnableSensitiveDataLogging(true);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }


        public static void ApplyAutoMigration(this WebApplication app, IConfiguration configuration)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();

            if (!dbContext.AllMigrationsApplied())
            {
                dbContext.Migrate(); // apply migrations
            }

            var serviceProvider = scope.ServiceProvider;
            ContexSeed.SeedAll(dbContext, configuration); // seed data
        }



        public static void AddMapGrpcServices(this WebApplication app)
        {
        }
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning().AddApiExplorer(options =>
            {
                // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
            });
        }

        public static void AddCorss(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCors",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });
        }

        public static void ConfigureKestrels(this IWebHostBuilder webHost)
        {
            webHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 7168, o => o.Protocols = HttpProtocols.Http2);

                options.Listen(IPAddress.Any, 5222, o => o.Protocols = HttpProtocols.Http1);
            });
        }

        public static void AddAuthentications(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
          .AddJwtBearer("Bearer", options =>
          {
              // the name of your api resources   
              options.Audience = "UserManagementServer";
              /// identity server url                    
              options.Authority = configuration.GetValue<string>("IdentityUrl");
              options.RequireHttpsMetadata = false;
          });
        }

        public static void AddAuthorizations(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ResourceOwnerPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "4EMicroServices"); // Require scope associated with Resource Owner Password token
                });

                options.AddPolicy("ClientCredentialsPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "CPAggregatorAPI"); // Require scope associated with Client Credentials token
                });
            });
        }

        public static void AddSwaggerGens(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Committee APIs Reference",
                });

                c.AddSecurityDefinition(
                "token",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization
                }
                    );
                c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "token"
                                },
                            },
                            Array.Empty<string>()
                        }
                }
                    );
            });
        }
    }
}
