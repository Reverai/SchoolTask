using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace School.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Forms = new HashSet<Form>();
        }

        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Фамилия")]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Имя")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [InverseProperty(nameof(Form.Teacher))]
        public virtual ICollection<Form> Forms { get; set; }

        // Создано, чтобы выводить полное имя в полях других таблиц
        public string FullName
        {
            get
            {
                return $"{Surname} {Name} {Patronymic}";
            }
        }
    }
}
