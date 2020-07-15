using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalaryPorject.Business.Employees;
using SalaryProject.DataAccess.EmployeeClient;

namespace SalaryProject.Web
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

            // Registramos la dependencia del HttpClient referente a nuestra capa de datos EmployeeClient
            services.AddHttpClient<IEmployeeClient, EmployeeClient>();

            // Registramos la dependencia del dto para el tratamiento de la información recibida en la capa de datos
            services.AddTransient<IEmployee, Employee>();

            // .Net va a bloquear peticiones que esten fuera de su dominio o puerto, para ello instalamos el paquete Microsoft.AspNetCore.Cors y lo añadimos en el startup
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Añadimos los origenes permitidos de dominios externos para el proyecto de angular
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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