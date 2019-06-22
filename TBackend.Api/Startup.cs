using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBackend.Repository;
using TBackend.Repository.context;
using TBackend.Repository.implementation;
using TBackend.Service;
using TBackend.Service.implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TBackend.Api
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
            // services.AddE
                        services.AddMvc().AddJsonOptions(options => {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

            services.AddDbContext<ApplicationDbContext>(options =>
     options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPlayerRepository, PlayerRepository> ();
            services.AddTransient<IPlayerService, PlayerService> ();

            services.AddTransient<ITournamentRepository, TournamentRepository> ();
            services.AddTransient<ITournamentService, TournamentService> ();

            services.AddTransient<ITeamRepository, TeamRepository> ();
            services.AddTransient<ITeamService, TeamService> ();

            services.AddTransient<IStatisticsRepository, StatisticsRepository> ();
            services.AddTransient<IStatisticsService, StatisticsService> ();

            services.AddTransient<IModeRepository, ModeRepository> ();
            services.AddTransient<IModeService, ModeService> ();

             services.AddTransient<IMatchRepository, MatchRepository> ();
            services.AddTransient<IMatchService, MatchService> ();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(swagger =>
            {
                var contact = new Contact() { Name = SwaggerConfiguration.ContactName, Url = SwaggerConfiguration.ContactUrl };
                swagger.SwaggerDoc(SwaggerConfiguration.DocNameV1,
                    new Info
                    {
                        Title = SwaggerConfiguration.DocInfoTitle,
                        Version = SwaggerConfiguration.DocInfoVersion,
                        Description = SwaggerConfiguration.DocInfoDescription,
                        Contact = contact
                    }
                );
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                    builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Todos");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
