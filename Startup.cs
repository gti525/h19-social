using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Helpers;
using System.Text;
using ASPNETCoreHeroku.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ASPNETCoreHeroku
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
			services.AddCors();
			services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientDAL, ClientDAL>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketDAL, TicketDAL>();
            services.AddScoped<IFriendRequestService, FriendRequestService>();
            services.AddScoped<IFriendRequestDAL, FriendRequestDAL>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;

            //Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v4", new Info { Title = "API Réseau social", Description = "Plate forme API destinée à fournir des données" });

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"ASPNETCoreHeroku.xml";
                c.IncludeXmlComments(xmlPath);
            }
                );

            
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

			app.UseCors(builder =>
				builder.WithOrigins("http://localhost:8080").AllowAnyHeader());


			//app.UseHttpsRedirection();
   //         app.UseStaticFiles();
   //         app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseSwagger()
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "Core API");
            });
        }
    }
}
