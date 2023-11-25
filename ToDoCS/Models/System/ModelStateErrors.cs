using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ToDoCS.Models.System;

public record ModelStateErrors
{
    public Dictionary<string, List<string>>? Errors { get; init; }
};