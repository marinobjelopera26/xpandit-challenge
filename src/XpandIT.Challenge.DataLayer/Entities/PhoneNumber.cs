using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XpandIT.Challenge.DataLayer.Entities
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("NumberType")]
        public int Type { get; set; }
        public string? Value { get; set; }

        public CBK_PhoneNumberType? NumberType { get; set; }
        public ICollection<ContactPhoneNumber>? Contacts { get; set; }
    }
}
