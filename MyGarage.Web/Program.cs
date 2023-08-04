namespace MyGarage.Web
{
    using Microsoft.EntityFrameworkCore;

    using MyGarage.Services.Data.Interfaces;
    using Infrastructure.Extensions;
    using Infrastructure.ModelBinders;

    using Data.Models;
    using Data;


    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<MyGarageDbContext>(options =>
                options.UseSqlServer(connectionString));
             
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = 
                        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                    options.Password.RequireLowercase = 
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

                    options.Password.RequireUppercase = 
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");

                    options.Password.RequireNonAlphanumeric = 
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

                    options.Password.RequiredLength = 
                        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddEntityFrameworkStores<MyGarageDbContext>();

            //builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddApplicationServices(typeof(ICustomerService));

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                });

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}