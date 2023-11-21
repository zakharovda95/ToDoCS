using System.ComponentModel.DataAnnotations;

namespace ToDoCS.ViewModels;

public record LoginViewModel
{
    [Required (ErrorMessage = "Обязательное поле")]
    public string Name { get; init; }
    
    [Required (ErrorMessage = "Обязательное поле")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Минимум 6, максимум 20 символов")]
    public string Password { get; init; }
}