namespace XpandIT.Challenge.Model.Contacts
{
    public class Contact
    {
        public int? Id { get; private set; }
        public string? UserId { get; private set; }
        public byte[]? Image { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Address { get; private set; }

        public ICollection<ContactPhoneNumber> PhoneNumbers { get; set; } =
            new List<ContactPhoneNumber>();

        public Contact(int? id, byte[]? image, string firstName, string lastName, string emailAddress, string address)
        {
            Id = id;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Address = address;
        }

        public Contact(int? id, string userId, byte[]? image, string firstName, string lastName, string emailAddress, string address)
        {
            Id = id;
            UserId = userId;
            Image = image;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Address = address;
        }

        public void SetUserId(string userId) =>
            UserId = userId;
    }

    public class ContactPhoneNumber
    {
        public int TypeId { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }

        public ContactPhoneNumber(int typeId, string type, string value)
        {
            TypeId = typeId;
            Type = type;
            Value = value;
        }
    }
}