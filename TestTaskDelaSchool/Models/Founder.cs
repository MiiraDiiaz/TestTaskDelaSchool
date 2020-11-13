using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskDelaSchool.Models
{
    /// <summary>
    /// Учредитель
    /// </summary>
    public class Founder
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано ИНН учредителя")]
        public string INN { get; set; }

        [Required(ErrorMessage = "Не ФИО учредителя")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
