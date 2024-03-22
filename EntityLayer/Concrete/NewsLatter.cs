using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class NewsLatter
    {
        [Key]
        public int MailID { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
