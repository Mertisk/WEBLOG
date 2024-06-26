using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreDemo
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
            //45-47".V�DEO(session ,config,addmvc eklemeleri)
            services.AddSession();
            services.AddControllersWithViews();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });
            //video 47
            services.AddMvc();
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }
                );



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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //404 hatalari i�in olu�turulan kod yap�s�
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //video46
            app.UseSession();
            //useAuthenticaton yapt�g�ndan claim'li i�lemler ve useridentity eklediginden  app.UseSession ile beraber her action� a��yor

            //vide48 UseAuthentication sayesinde di�er actionlarda a��l�yor
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                 name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );




                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
