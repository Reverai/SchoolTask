using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    [Table("Journal")]
    public partial class Journal
    {
        [Key]
        public int JournalId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Оценка")]
        public int Mark { get; set; }
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Дата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime MarkDate { get; set; }

        [ForeignKey(nameof(StudentId))]
        [DisplayName("Ученик")]
        [InverseProperty("Journals")]
        public virtual Student Student { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [DisplayName("Предмет")]
        [InverseProperty("Journals")]
        public virtual Subject Subject { get; set; }
    }
}
