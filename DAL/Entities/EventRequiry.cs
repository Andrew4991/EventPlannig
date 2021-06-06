using EventPlannig.DAL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlannig.DAL.Entities
{
    public class EventRequiry : IBaseEntity
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        [Required(ErrorMessage = "Ваше имя не можен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 50 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ваш email не можен быть пустым")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool IsApproved { get; set; }

        public Guid Key { get; set; }
    }
}
