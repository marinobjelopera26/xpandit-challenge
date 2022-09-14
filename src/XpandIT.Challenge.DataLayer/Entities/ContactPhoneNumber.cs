using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpandIT.Challenge.DataLayer.Entities
{
    public class ContactPhoneNumber
    {
        public int ContactId { get; set; }
        public int PhoneNumberId { get; set; }

        public Contact? Contact { get; set; }
        public PhoneNumber? PhoneNumber { get; set; }
    }
}
