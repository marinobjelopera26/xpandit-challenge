using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XpandIT.Challenge.DataLayer;
using XpandIT.Challenge.DataLayer.Seeders;

namespace XpandIT.Challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("XpandIT") 
                ?? throw new InvalidOperationException("Connection string 'XpandIT' not found.");

            builder.Services.AddDbContext<XpandITDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<XpandITDbContext>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            EnsureDatabaseCreated(app);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }

        public static void EnsureDatabaseCreated(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<XpandITDbContext>();
            dbContext.Database.EnsureCreated();

            DbInitializer.Initialize(dbContext);
        }
    }
}