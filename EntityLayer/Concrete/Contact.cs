using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string ContactUserName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; } //konu
        public string ContactMesssage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }

    }
}
