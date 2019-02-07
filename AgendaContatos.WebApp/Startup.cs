using AgendaContatos.Application;
using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;
using AgendaContatos.Domain.Services;
using AgendaContatos.Repository.Helpers;
using AgendaContatos.Repository.Repositories;
using AgendaContatos.WebApp.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.WebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            ConfigureDependencies(services);

            ConfigureMapper();            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }


            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


        }

        public void ConfigureDependencies(IServiceCollection service)
        {
            service.AddScoped<IContactRepository, ContactRepository>();

            service.AddScoped<IContactTypeRepository, ContactTypeRepository>();

            service.AddScoped<IMailRepository, MailRepository>();

            service.AddScoped<IPhoneRepository, PhoneRepository>();

            service.AddScoped<IMailService, MailService>();            

            service.AddScoped<IPhoneService, PhoneService>();

            service.AddScoped<IContactService, ContactService>();

            service.AddScoped<IContactTypeService, ContactTypeService>();

            service.AddScoped<IMailService, MailService>();

            service.AddScoped<IPhoneService, PhoneService>();

            service.AddScoped<IContactApplication, ContactApplication>();

            service.AddScoped<IContactTypeApplication, ContactTypeApplication>();

            service.AddScoped<IMailApplication, MailApplication>();

            service.AddScoped<IPhoneApplication, PhoneApplication>();

        }

        public void ConfigureMapper()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<ContactViewModel, Contact>().ConstructUsing(d => new Contact(d.ContactId, d.Name, d.Address, d.Company));
                c.CreateMap<ContactMailViewModel, ContactMail>().ConstructUsing(d => new ContactMail(d.ContactMailId,d.ContactId,d.ContactTypeId, d.Address));
                c.CreateMap<ContactPhoneViewModel, ContactPhone>().ConstructUsing(d => new ContactPhone(d.ContactId, d.ContactPhoneId, d.ContactTypeId, d.Number));
            });
        }
    }
}
