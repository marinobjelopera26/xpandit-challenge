#nullable disable

using XpandIT.Challenge.DataLayer.Providers;
using XpandIT.Challenge.Services.Contacts;
using XpandIT.Challenge.Services.PhoneNumbers;

namespace XpandIT.Challenge.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDbRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
            services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPhoneNumberService, PhoneNumberService>();
            services.AddTransient<IContactService, ContactService>();

            return services;
        }
    }
}
