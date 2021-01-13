using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Proyecto.Application.Mapper;
using Proyecto.Application.ServicesImplementation.Querys;
using Proyecto.Application.ServicesImplementation.Commands;
using Proyecto.Domain.Repository;
using Proyecto.Domain.Services.Querys;
using Proyecto.Infrastructure.Context;
using Proyecto.Infrastructure.RepositoryImplementation;
using Proyecto.Infrastructure.UnitOfWork;
using Proyecto.Domain.Services.Commands;
using Proyecto.Infrastructure.Context.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Proyecto.Api
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
            services.AddDbContext<ApplicationDbContext>(
                opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddDbContext<ApplicationSecurityDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationSecurityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IGrupoGraduadoRepository, GrupoGraduadoRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();

            services.AddTransient<UnitOfWork>();


            services.AddTransient<ICursoServiceQuery, CursoServiceQuery>();
            services.AddTransient<IGrupoGraduadoServiceQuery, GrupoGraduadoServiceQuery>();

            services.AddTransient<ICursoServiceCommand, CursoServiceCommand>();
            services.AddTransient<IGrupoGraduadoServiceCommand, GrupoGraduadoServiceCommand>();

            var mappingConfig = new MapperConfiguration(
                mc => { mc.AddProfile(new MappingProfile());}
            );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Proyecto API v1",
                    Description = "Servicio Rest Api para el Proyecto",
                    Contact = new OpenApiContact()
                    {
                        Name = "Jeiel Tarazona Lovera",
                        Email = "jeiel.disas@gmail.com",
                        Url = new Uri("https://github.com/JeielLovera/ProyectoSegundaEtapa")
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
                    ClockSkew = TimeSpan.Zero
                }
            );

            services.AddCors(options => { options.AddPolicy("All", builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*")); });

            services.AddControllers(
                config =>
                {
                    config.Conventions.Add(new ApiVersionConvention());
                }
            ).AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto API v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("All");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
