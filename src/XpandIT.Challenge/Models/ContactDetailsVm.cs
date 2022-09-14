namespace XpandIT.Challenge.Models
{
    public class ContactDetailsVm
    {
        public int Id { get; private set; }
        public byte[]? Image { get; private set; }
        public string Name =>
            $"{_firstName} {_lastName}";

        public string Initials =>
            $"{_firstName[0]}{_lastName[0]}";

        private readonly string _firstName;
        private readonly string _lastName;

        public string EmailAddress { get; private set; }
        public string Address { get; private set; }

        public IEnumerable<ContactDetailsPhoneNumber> PhoneNumbers { get; set; } = 
            new List<ContactDetailsPhoneNumber>();

        public ContactDetailsVm(
            int id,
            byte[]? image,
            string firstName,
            string lastName,
            string emailAddress,
            string address)
        {
            Id = id;
            Image = image;
            _firstName = firstName;
            _lastName = lastName;
            EmailAddress = emailAddress;
            Address = address;
        }

        public record struct ContactDetailsPhoneNumber(string Type, string Value);
    }
}
