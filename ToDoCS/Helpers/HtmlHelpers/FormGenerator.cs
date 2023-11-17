using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ToDoCS.Data.Enums;

namespace ToDoCS.Helpers.HtmlHelpers;

public static class FormGenerator
{
    public static IHtmlContent GenerateForm(ActionsNamesEnum action, ControllersNamesEnum controller, string method)
    {
        var form = new TagBuilder("form");
        form.Attributes.Add("method", method);
        form.Attributes.Add("action", $"{controller}/{action}");

        form.InnerHtml.AppendHtml(UIGenerator.GetInputGroup(id: "global-form-input-name", label: "Логин", placeholder: "Введите логин"));
        form.InnerHtml.AppendHtml(UIGenerator.GetInputGroup(id: "global-form-input-password", label: "Пароль", placeholder: "Введите пароль"));
        
        if (controller == ControllersNamesEnum.Registration && action == ActionsNamesEnum.Index)
        {
            form.InnerHtml.AppendHtml(UIGenerator.GetInputGroup(id: "global-form-input-password-repeat", label: "Повтор пароля", placeholder: "Повторите пароль"));
            form.InnerHtml.AppendHtml(UIGenerator.GetInputGroup(id: "global-form-input-email", label: "Email", placeholder: "Введите email"));
        }

        var buttonText = controller == ControllersNamesEnum.Registration ? "Зарегистрироваться" : "Войти";

        form.InnerHtml.AppendHtml(UIGenerator.GetButton(buttonText));

        return form;
    }
}