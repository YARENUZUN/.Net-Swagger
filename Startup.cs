using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
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
            
            services.AddControllers();
            services.AddMvc();
            services.AddSingleton<IHotelService, HotelManager>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "All Hotel API Project";
                    doc.Info.Version = "1.0.13";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Yaren Uzun",
                        Email="yarenuzun.1999@gmail.com",
                        Url="Https://github.com/YARENUZUN"
                    };
                    
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
            
        }
    }
}
