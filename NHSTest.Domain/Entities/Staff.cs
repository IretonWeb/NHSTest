
using System.ComponentModel.DataAnnotations;

namespace NHSTest.Domain.Entities
{
    public class Staff
    {
        public Staff()
        {
            
        }

        public Staff(string? firstName, string? surname)
        {
           
            FirstName = firstName;
            Surname = surname;
           
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string? Surname { get; set; }

        public virtual ICollection<Requirements>? Requirements { get; set; }
    }
}
