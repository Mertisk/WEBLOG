using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
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
            services.AddDbContext<Context>();//video 123 RegisterUserController için 
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireDigit = true;                    // Parola en az bir rakam içermelidir
                //options.Password.RequiredLength = 6;                     // Parola en az 6 karakter uzunluðunda olmalýdýr
                //options.Password.RequireNonAlphanumeric = false;         // Parola özel karakter içermek zorunda deðildir
                //options.Password.RequireUppercase = true;                // Parola en az bir büyük harf içermelidir
                //options.Password.RequireLowercase = true;                // Parola en az bir küçük harf içermelidir
            })

                .AddEntityFrameworkStores<Context>();//video 123 RegisterUserController için 
            //45-47".VÝDEO(session ,config,addmvc eklemeleri)
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

            //404 hatalari için oluþturulan kod yapýsý
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //video46
            app.UseSession();
            //useAuthenticaton yaptýgýndan claim'li iþlemler ve useridentity eklediginden  app.UseSession ile beraber her actioný açýyor

            //vide48 UseAuthentication sayesinde diðer actionlarda açýlýyor
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
