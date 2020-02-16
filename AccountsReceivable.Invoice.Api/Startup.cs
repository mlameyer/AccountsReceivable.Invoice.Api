using AccountsReceivable.InvoiceOperations.Api.Interfaces.Database;
using AccountsReceivable.InvoiceOperations.Api.Interfaces.Managers;
using AccountsReceivable.InvoiceOperations.Api.Interfaces.Repositories;
using AccountsReceivable.InvoiceOperations.Api.Managers;
using AccountsReceivable.InvoiceOperations.Api.Models;
using AccountsReceivable.InvoiceOperations.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace AccountsReceivable.InvoiceOperations.Api
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
            // requires using Microsoft.Extensions.Options
            services.Configure<AccountsReceivableDatabase>(
                Configuration.GetSection(nameof(AccountsReceivableDatabase)));

            services.AddSingleton<IAccountsReceivableDatabase>(sp =>
                sp.GetRequiredService<IOptions<AccountsReceivableDatabase>>().Value);

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceManager, InvoiceManager>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AR Invoice Api", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AR Invoice Api V1");
            });

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
