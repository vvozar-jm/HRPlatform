using API.Mappings.Contracts;
using API.Mappings.Mappers;
using Core.Repositories;
using Core.Services;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;

namespace API
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
            // repositories
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();

            // services
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ISkillService, SkillService>();

            // mappers
            services.AddScoped<ICandidateMapper, CandidateMapper>();
            services.AddScoped<ISkillMapper, SkillMapper>();

            services.AddDbContext<HrPlatformDbContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Data")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
