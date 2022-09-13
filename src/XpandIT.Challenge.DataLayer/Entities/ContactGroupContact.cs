namespace XpandIT.Challenge.DataLayer.Entities
{
    public class ContactGroupContact
    {
        public int ContactGroupId { get; set; }
        public int ContactId { get; set; }

        public ContactGroup? ContactGroup { get; set; }
        public Contact? Contact { get; set; }
    }
}
