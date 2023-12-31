using System.ComponentModel.DataAnnotations;

namespace WebApplication3
{
    public class PhoneRecord
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
    }
}