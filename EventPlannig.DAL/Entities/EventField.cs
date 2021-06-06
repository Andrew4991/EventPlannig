using EventPlannig.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EventPlannig.DAL.Entities
{
    public class EventField : IBaseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя поля не можен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина имени поля должна быть от 3 до 50 символов")]
        [Display(Name = "Имя поля")]
        public string FieldName { get; set; }

        [Required(ErrorMessage = "Значение поля не можен быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина значения поля должна быть от 3 до 50 символов")]
        [Display(Name = "Значение")]
        public string FieldValue { get; set; }

        public int? EventId { get; set; }

        public Event Event { get; set; }
    }
}
