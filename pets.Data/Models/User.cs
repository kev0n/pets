using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pets.Data.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Длина логина должна быть не менее 4 и не более 30 символов", MinimumLength = 4)]
        [Required(ErrorMessage = "Не указано обязательное поле 'Логин'")]
        public string Username { get; set; }
        [StringLength(32, ErrorMessage = "Длина пароля должна быть не менее 4 и не более 32 символов", MinimumLength = 4)]
        [Required(ErrorMessage = "Не указано обязательное поле 'Пароль'")]
        public string Password { get; set; }
        public Role Role { get; set; } = Role.Regular;
    }

    public enum Role
    {
        Admin,
        Regular
    }
}
