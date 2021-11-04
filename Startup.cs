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
using Part_2_Lesson_8.DAl.Jobs;
using Part_2_Lesson_8.CPU.DBcpu;
using Part_2_Lesson_8.CPU.DTO;
using Part_2_Lesson_8.CPU.Repositry;
using Part_2_Lesson_8.Interfaces;
using Part_2_Lesson_8.RAM.DTO;
using Part_2_Lesson_8.RAM.Repository;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Part_2_Lesson_8.DAl.DTO;

namespace Part_2_Lesson_8
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
            services.AddSingleton<IJobFactory, SengeltonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //services.AddSingleton<CpuMetricsJobs>();
            //services.AddSingleton<RamMetricsJobs>();
            services.AddSingleton(new JobSheldure(jobType: typeof(CpuMetricsJobs), cronExpresion: "0/5 * * * * ?")); // запускать каждые 5 секунд
            services.AddSingleton(new JobSheldure(jobType: typeof(RamMetricsJobs), cronExpresion: "0/5 * * * * ?"));

            services.AddHttpClient();
            services.AddDbContext<CreatDb>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<CpuDto>, Repositroy<CpuDto>>();
            services.AddScoped<IRepository<RamDto>,RamRepository<RamDto>>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Part_2_Lesson_8", Version = "v2" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Part_2_Lesson_8 v2"));
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
