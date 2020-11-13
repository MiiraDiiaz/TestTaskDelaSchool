using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestTaskDelaSchool.Models;

namespace TestTaskDelaSchool.ViewModel
{
    public class UserFounderVM
    {
        public int Id { get; set; }

        [Display(Name = "Введите ИНН компании")]
        public string INNCompany { get; set; }

        [Display(Name = "Введите название компании")]
        public string NameCompane { get; set; }

        public DateTime CreatedAtCompany { get; set; }

        public DateTime UpdatedAtCompany { get; set; }

        [Display(Name = "Введите тип компании")]
        public TypeOfCompany TypeOfCompany { get; set; }

        public List<Founder> Founders { get; set; }

        [Display(Name = "Введите ИНН учредителя")]
        public string INNFounder { get; set; }

        [Display(Name = "Введите ФИО Уредителя")]
        public string NameFounder { get; set; }       
        public DateTime CreatedAtFounder { get; set; }
        public DateTime UpdatedAtFounder { get; set; }

    }
}
