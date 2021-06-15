using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Journals = new HashSet<Journal>();
        }

        [Key]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Предмет")]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [InverseProperty(nameof(Journal.Subject))]
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
