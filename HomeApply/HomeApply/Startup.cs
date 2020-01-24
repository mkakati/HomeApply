using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HomeApply.Entities;
using HomeApply.Entities.DbContext;
using HomeApply.Service.Interfaces;
using HomeApply.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HomeApply
{
    public class Startup
    {
        string DefaultCorsPolicyUrl;
        string DefaultCorsPolicyName;
        string strValidIssuer = "Fiver.Security.Bearer";
        string strValidAudience = "Fiver.Security.Bearer";
        string strIssuerSigningKey = "fiver-secret-key";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("sqlconnection");
            //    services.AddDbContext<HomeApplyDbContext>(options =>
            //options.UseNpgsql(connectionString: Configuration.GetConnectionString("DefaultConnection"), defaultSchema: Configuration["AppSettings:DefaultSchema"])
            //);
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
    .AddEntityFrameworkStores<HomeApplyContext>()
    .AddDefaultTokenProviders();
            //services.AddAutoMapper();

            services.AddControllers();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMembershipInterface, MembershipService>();
            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            services.AddDbContext<HomeApplyContext>(item => item.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
