using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tickets.Services;
using TicketsRepository;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using TicketsServices;

namespace Tickets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TicketsDatabaseSettings>(
                Configuration.GetSection(nameof(TicketsDatabaseSettings)));

            services.AddSingleton<ITicketsDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TicketsDatabaseSettings>>().Value);

            ServicesLayerInjection(services);
            RepositoriesLayerInjection(services);

            services.AddGrpc();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<TicketsService>().RequireCors("AllowAll");

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }

        private void ServicesLayerInjection(IServiceCollection services)
        {
            services.AddTransient<IManagementService, ManagementService>();
            services.AddTransient<IRequestService, RequestService>();
        }

        private void RepositoriesLayerInjection(IServiceCollection services)
        {
            services.AddTransient<ITicketsQueries, TicketsQueries>();

        }
    }
}
