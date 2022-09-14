#nullable disable

using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;
using XpandIT.Challenge.DataLayer;
using XpandIT.Challenge.DataLayer.Providers;
using XpandIT.Challenge.Model.PhoneNumbers;

namespace XpandIT.Challenge.Services.PhoneNumbers
{
    public interface IPhoneNumberService
    {
        Task<IEnumerable<PhoneNumberType>> GetAvailablePhoneNumberTypesAsync();
    }

    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;

        public PhoneNumberService(
            IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<IEnumerable<PhoneNumberType>> GetAvailablePhoneNumberTypesAsync() =>
            (await _phoneNumberTypeRepository.GetAvailablePhoneNumberTypes())
                .Select(x => new PhoneNumberType(x.Id, x.Name, x.Description));
    }
}
