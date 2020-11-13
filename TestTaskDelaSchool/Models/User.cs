using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TestTaskDelaSchool.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано ИНН организации")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Не указано имя организации")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [Required(ErrorMessage = "Не указан тип организации")]
        public TypeOfCompany TypeOfCompany { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Founder> Founders { get; set; }
    }
}
