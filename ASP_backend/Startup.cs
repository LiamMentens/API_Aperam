﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ASP_backend.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace ASP_backend
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

            
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            var appSettingsSection = Configuration.GetSection("AppSettings");

            // configure jwt authentication

            // configure DI for application services

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});

                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    {
                //        "Bearer",
                //        Enumerable.Empty<string>()
                //    },
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseMvc();

            DBInitializer.Initialize(context);

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP_backend API v1");
            });
        }
    }
}
