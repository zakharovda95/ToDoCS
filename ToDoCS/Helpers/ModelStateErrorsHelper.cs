using Microsoft.AspNetCore.Mvc.ModelBinding;
using ToDoCS.Models.System;

namespace ToDoCS.Helpers;

public static class ModelStateErrorsHelper
{
    public static ModelStateErrors GetErrors(ModelStateDictionary modelState)
    {
        return new ModelStateErrors
        {
            Errors = modelState.ToDictionary(
                entry => entry.Key, 
                entry => entry.Value!.Errors
                    .Select(el => el.ErrorMessage)
                    .ToList())
        };
    }
}