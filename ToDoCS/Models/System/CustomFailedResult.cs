namespace ToDoCS.Models.System;

public record CustomFailedResult : CustomResult
{
    public ModelStateErrors? Errors { get; init; }
};