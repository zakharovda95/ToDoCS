namespace ToDoCS.Models.System;

public record CustomResult
{
    public bool Success { get; init; }
    public string? Message { get; init; }
}