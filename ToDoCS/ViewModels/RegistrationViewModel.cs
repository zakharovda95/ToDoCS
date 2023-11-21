using System.ComponentModel.DataAnnotations;

namespace ToDoCS.ViewModels;

public record RegistrationViewModel
{
    [Required (ErrorMessage = "Обязательное поле")]
    public string Name { get; init; }
    
    [Required (ErrorMessage = "Обязательное поле")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
    public string Email { get; init; }
    
    [Required (ErrorMessage = "Обязательное поле")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Минимум 6, максимум 20 символов")]
    public string Password { get; init; }
    
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string PasswordRepeat { get; init; }
}