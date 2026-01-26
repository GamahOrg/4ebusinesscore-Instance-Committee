using _4EPlatform.PermissionsGroupingChecker;
using _4EPlatform.PremessionRegister;
using _4EPlatform_Committees.GrpClientsConfig;
using Committees.API.Extension;
using Committees.Application.Helpers.EmailService;

var builder = WebApplication.CreateBuilder(args);

try
{
    // Add services to the container.
    // Add unit of work & GRepo
    builder.Services.AddUnitOfWorkRepository();
    builder.Services.AddCorss();

    /*builder.Services.AddCorsConfig();*/
    builder.Services.AddDiServices();
    builder.Services.AddGrpc();
    builder.Services.AddGrpcReflection();
    builder.WebHost.ConfigureKestrels();


    builder.Services.AddVersioning();
    builder.Services.AddDbConfig(builder.Configuration);

    builder.Services.AddRateLimitings(builder.Configuration);
    builder.Host.UseSerilog((context, configuration) => configuration
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext().
            ReadFrom.Configuration(context.Configuration));

    builder.Services.AddAuthentications(builder.Configuration);
    builder.Services.AddAuthorizations();

    // Add grpc config to serviceCollection
    builder.Services.AddGrpc();
    //builder.Services.AddGrpcReflection();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    #region Swagger

    builder.Services.AddSwaggerGens();

    #endregion

    builder.Services.AddUserManagementGrpcClients(builder.Configuration["GrpcServiceSettings:UserManagementUrl"]);
    builder.Services.AddCPAggregatorGrpcClients(builder.Configuration["GrpcServiceSettings:CPAggregatorUrl"]);
    builder.Services.AddSingleton<ITokenService, TokenService>();
    builder.Services.AddScoped<IMailService, MailService>();
    builder.Services.AddScoped<PermissionsGroupingCheckerMiddleware, PermissionsGroupingCheckerMiddleware>();
    builder.Services.AddHostedService<AddPermissionsMiddleware>();


    builder.Services.AddControllers();
    builder.Services.AddFluentValidation();
    var app = builder.Build();
    app.MapGrpcService<CommitteeApprovalService>();
    app.MapGrpcService<CommitteeService>();
    app.MapGrpcService<MeetingService>();
    app.MapGrpcService<OutputService>();
    app.MapGrpcService<ProceedingService>();
    app.UseMiddleware<GlobalExceptionHandler>();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
        RequestPath = "/wwwroot"
    });
    app.ApplyAutoMigration(builder.Configuration);
    // Add GrpcServices
    app.AddMapGrpcServices();
    app.UseStaticFiles();
    app.UseCors("AllowCors");
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    //Add support to logging request with SERILOG
    app.UseSerilogRequestLogging();
    app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();

    app.Run();
}
catch (Exception ex)
{

    throw;
}