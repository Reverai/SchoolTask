using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Form
    {
        public Form()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int FormId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Номер класса")]
        [StringLength(20)]
        public string FormNumber { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Название класса")]
        [StringLength(20)]
        public string FormName { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Учитель")]
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [DisplayName("Учитель")]
        [InverseProperty("Forms")]
        public virtual Teacher Teacher { get; set; }
        [InverseProperty(nameof(Student.Form))]
        public virtual ICollection<Student> Students { get; set; }

        // Создано, чтобы выводить полное название в полях других таблиц
        public string FullName
        {
            get
            {
                return $"{FormNumber} {FormName}";
            }
        }
    }
}
