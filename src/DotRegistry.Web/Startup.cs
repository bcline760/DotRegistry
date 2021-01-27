using System;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Autofac;
using Newtonsoft.Json.Linq;

using DotRegistry.Core;
using DotRegistry.Interface;
using DotRegistry.Service;

using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace DotRegistry.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            IsDevelopment = env.IsDevelopment();
            IConfigurationBuilder builder = null;

            if (IsDevelopment)
            {
                builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            }
            else
            {
                builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            }

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = "GitHub";
            }).AddCookie().AddOAuth("GitHub", gh =>
            {
                gh.ClientId = Environment.GetEnvironmentVariable(Constants.GitHubClientIdEnvName);
                gh.ClientSecret = Environment.GetEnvironmentVariable(Constants.GitHubClientSecretEnvName);
                gh.CallbackPath = new PathString("/github-oauth");
                gh.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                gh.TokenEndpoint = "https://github.com/login/oauth/access_token";
                gh.UserInformationEndpoint = "https://api.github.com/user";
                gh.Scope.Add("read:user");
                gh.Scope.Add("user:email");
                gh.Scope.Add("read:gpg_key");
                gh.Scope.Add("read:public_key");
                gh.SaveTokens = true;

                gh.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                gh.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                gh.ClaimActions.MapJsonKey("urn:github:login", "login");
                gh.ClaimActions.MapJsonKey("urn:github:url", "html_url");

                gh.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                      {
                          var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                          request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                          request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                          var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                          response.EnsureSuccessStatusCode();
                          var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                          context.RunClaimActions(json.RootElement);
                      }
                };
            });
            services.AddAuthorization(a =>
            {
                a.AddPolicy("ValidGitHubToken", p =>
                {
                    p.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme);
                    p.RequireAuthenticatedUser();
                });
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.Register(r => LogManager.GetLogger(typeof(Startup))).As<ILog>().SingleInstance();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            ModuleRegistration.Register(builder);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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

        public IConfiguration Configuration { get; }

        public bool IsDevelopment { get; }
    }
}
