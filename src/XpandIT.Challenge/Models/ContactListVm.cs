namespace XpandIT.Challenge.Models
{
    public class ContactListVm
    {
        public IEnumerable<ContactListItem> Items { get; set; } = new List<ContactListItem>();
    }

    public class ContactListItem
    {
        public int Id { get; private set; }
        public byte[]? Image { get; set; }
        public string Name =>
            $"{_firstName} {_lastName}";

        public string Initials =>
            $"{_firstName[0]}{_lastName[0]}";

        private readonly string _firstName;
        private readonly string _lastName;

        public string EmailAddress { get; set; }
        public string Address { get; set; }

        public ContactListItem(
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
    }
}
