using System.ComponentModel.DataAnnotations;

namespace BlogApiCore.DataAccsessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
