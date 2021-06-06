using EventPlannig.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlannig.DAL.Entities
{
    public class Event : IBaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя мереприятия не можен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени должна быть от 3 до 50 символов")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Заголовок мереприятия не можен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина заголовка должна быть от 3 до 50 символов")]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Дата мереприятия не можен быть пустым")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата начала")]
        public DateTime Date { get; set; }

        [Required]
        public ICollection<EventField> CustomFields { get; set; }

        public Event()
        {
            CustomFields = new List<EventField>();
        }
    }
}
