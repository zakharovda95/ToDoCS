namespace ToDoCS.Models.System;

public record CustomSuccessResult<T> : CustomResult
{
    public T? Data { get; init; }
};