using System.ComponentModel.DataAnnotations;

namespace XpandIT.Challenge.DataLayer.Entities
{
    public class CBK_PhoneNumberType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
