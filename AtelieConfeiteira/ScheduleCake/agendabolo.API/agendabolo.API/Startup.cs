using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Agendabolo
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "Policy1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<Data.ApplicationDbContext>();


            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
            //    {
            //        builder.WithOrigins("http://localhost:3000");
            //    });
            //});

            DefineSerilog(services);
            services.AddSerilog(Log.Logger);


            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaBolo API", Version = "v1" });
            });

            

        }

        private void DefineSerilog(IServiceCollection services)
        {
            var outputTemplate = "[{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level}] {Message} {NewLine} {Exception}";
            var config = new LoggerConfiguration();
            config.WriteTo.Console(outputTemplate: outputTemplate);
            config.WriteTo.File(path: "logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: outputTemplate);
            config.MinimumLevel.Information();
            config.Enrich.FromLogContext();
            Log.Logger = config.CreateLogger();

            Log.Information("Serilog set configuration");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "agendabolo.API v1"));
            }

            

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "agendabolo.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors(MyAllowSpecificOrigins);


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
