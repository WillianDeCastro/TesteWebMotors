using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDesafioWebMotors.Domain.Interfaces.Services;
using ApiDesafioWebMotors.Domain.Services;
using ApiDesafioWebMotors.Infra.Data.Context;
using ApiDesafioWebMotors.Infra.Data.Interfaces.Repositories;
using ApiDesafioWebMotors.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiDesafioWebMotors
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebMotorsContext>(
          opt => opt.UseSqlServer(Configuration.GetConnectionString("Local"))
          );

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = "WebMotorsDoc", Version = "v1" });
            });

            services.AddScoped<IExternalWebMotorsRepository, ExternalWebMotorsRepository>();
            services.AddScoped<IExternalWebMotorsService, ExternalWebMotorsService>();
     
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebMotorsApi V1");
            });

            app.UseCors(c => c.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
