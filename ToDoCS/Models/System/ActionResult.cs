namespace ToDoCS.Models.System;

public record ActionResult
{
    public bool Success { get; init; }
    public string? Message { get; init; }
};