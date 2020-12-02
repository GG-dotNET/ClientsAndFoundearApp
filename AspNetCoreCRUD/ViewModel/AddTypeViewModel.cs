using AspNetCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCRUD.ViewModel
{
    public class AddTypeViewModel
    {
        [Required(ErrorMessage = "Не указан ИНН")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Количество цифр должо быть 12")]
        [Display(Name = "ИНН")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Не указано наименование")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 70 символов")]
        [Display(Name = "Наименование")]
        public string CompanyName { get; set; }

        [Display(Name = "Тип")]
        public CompanyType Type { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]
        public DateTime DateAdd { get; set; } = DateTime.Now.Date;

        [Display(Name = "Дата обновления")]
        [DataType(DataType.Date)]
        public DateTime DateUpdate { get; set; } = DateTime.Now.Date;

        [Display(Name = "Учредитель")]
        public ICollection<Founder> Founders { get; set; }

        public List<SelectListItem> ClientTypes { get; set; }

        public AddTypeViewModel()
        {
            ClientTypes = new List<SelectListItem>();

            ClientTypes.Add(new SelectListItem
            {
                Value = ((int)CompanyType.LegalEntity).ToString(),
                Text = CompanyType.LegalEntity.ToString()
            });

            ClientTypes.Add(new SelectListItem
            {
                Value = ((int)CompanyType.Entrepreneur).ToString(),
                Text = CompanyType.Entrepreneur.ToString()
            });
        }
    }
}
