using System.ComponentModel.DataAnnotations;


namespace TestTaskDelaSchool.Models
{
    /// <summary>
    /// Тип организации
    /// </summary>
    public enum TypeOfCompany
    {
        [Display(Name = "Юридическое лицо")]
        legalEntity,

        [Display(Name = "Индивидуальный предприниматель")]
        individualУntrepreneur
    }
}
