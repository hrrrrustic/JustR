using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JustR.FriendService.Repository;
using JustR.FriendService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;

namespace JustR.FriendService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ED95043C - 3295 - 4FF5 - 8C49 - B50A25291F10
            //BD37646C - E088 - 4960 - 9FAF - 3D809226C595
            services.AddControllers();
            services.AddScoped<Compiler, SqlServerCompiler>();
            services.AddScoped<IFriendRepository, DummyFriendRepository>();
            services.AddScoped<IFriendService, Service.DummyFriendService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("JustR.FriendService", new OpenApiInfo
                {
                    Title = "JustR API",
                    Version = "0.1.0"
                });
                String xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                String xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/JustR.FriendService/swagger.json", "JustR.FriendService");
            });
        }
    }
}
