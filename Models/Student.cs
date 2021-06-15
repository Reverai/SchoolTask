using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Student
    {
        public Student()
        {
            Journals = new HashSet<Journal>();
        }

        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Фамилия")]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Имя")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Отчетсво")]
        [StringLength(20)]
        public string Patronymic { get; set; }
        [DisplayName("Класс")]
        public int FormId { get; set; }

        [ForeignKey(nameof(FormId))]
        [DisplayName("Класс")]
        [InverseProperty("Students")]
        public virtual Form Form { get; set; }
        [InverseProperty(nameof(Journal.Student))]
        public virtual ICollection<Journal> Journals { get; set; }
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {Patronymic}";
            }
        }
    }
}
