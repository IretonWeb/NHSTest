using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NHSTest.Domain.Entities
{
    public class Requirements
    {
        public Requirements()
        {
            
        }

        public Requirements( string? title, string? description,  Staff? staff)
        {
            Title = title;
            Description = description;
            Status = "New";
            DateCreated = DateTime.Now;
            Staff = staff;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Status { get; set; }
     
        public DateTime DateCreated { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff? Staff { get; set; }

        public void Close()
        {
            Status = "Closed";
        }
    }
}
