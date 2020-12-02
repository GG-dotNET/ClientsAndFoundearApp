using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCRUD.Models
{
    public class Founder
    {
        public int FounderID { get; set; }

        [Required(ErrorMessage = "Не указан ИНН")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Количество цифр должо быть 12")]
        [Display(Name = "ИНН")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Не указано ФИО")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 100 символов")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]
        public DateTime DateAdd { get; set; } = DateTime.Now.Date;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.Date)]
        public DateTime DateUpdate { get; set; } = DateTime.Now.Date;

        [Display(Name = "Компания")]
        public int? ClientID { get; set; }

        [Display(Name = "Компания")]
        public Client Client { get; set; }
    }
}
