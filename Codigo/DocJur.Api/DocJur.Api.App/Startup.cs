using DocJur.Api.App.Database;
using DocJur.Api.App.Repository;
using DocJur.Api.App.Repository.Impl;
using DocJur.Api.App.Services;
using DocJur.Api.App.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace DocJur.Api.App
{
    /// <summary>
    /// Handlers the service initiation.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Contains the key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Contains a selection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            // Database
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(ConfigurationManager.AppSettings["database.connectionString"]));

            // Controller
            services.AddControllers();

            //Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddTransient<IDocumentTypeFieldRepository, DocumentTypeFieldRepository>();

            //Service
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDocumentTypeService, DocumentTypeService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IDocumentTypeFieldService, DocumentTypeFieldService>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints => endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"));

            using IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            DatabaseContext context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            context.Database.EnsureCreated();
        }
    }
}
