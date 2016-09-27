using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Contact()
        {
        }
        public Contact (string name, string phone, int contactId = 0)
        {
            ContactId = contactId;
            Name = name;
            Phone = phone;
        }
    }
}
