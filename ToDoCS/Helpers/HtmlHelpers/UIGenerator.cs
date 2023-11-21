using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoCS.Data.Enums;

namespace ToDoCS.Helpers.HtmlHelpers;

public static class UIGenerator
{
    public static IHtmlContent GetInputGroup(
        string id, 
        string label,
        string name,
        string placeholder = "Введите текст", 
        string type = "text"
    )
    {
        var inputContainer = new TagBuilder("div");
        var inputTag = new TagBuilder("input");
        var labelTag = new TagBuilder("label");
        
        inputContainer.AddCssClass("global-input__container");
        
        inputTag.Attributes.Add("placeholder", placeholder);
        inputTag.Attributes.Add("type", type);
        inputTag.Attributes.Add("name", name);
        inputTag.Attributes.Add("id", id);
        inputTag.AddCssClass("global-input__input");
        
        labelTag.Attributes.Add("for", id);
        labelTag.InnerHtml.Append(label);
        labelTag.AddCssClass("global-input__label");

        inputContainer.InnerHtml.AppendHtml(labelTag);
        inputContainer.InnerHtml.AppendHtml(inputTag);
        return inputContainer;
    }

    public static IHtmlContent GetButton(
        string text, 
        string type = "submit", 
        UIButtonTypeEnum btnType = UIButtonTypeEnum.Primary, 
        UIButtonSizeEnum btnSize = UIButtonSizeEnum.Medium)
    {
        var buttonTag = new TagBuilder("button");
        buttonTag.Attributes.Add("type", type);
        buttonTag.AddCssClass("global-button");
        buttonTag.AddCssClass($"global-button__{btnType}-{btnSize}");
        buttonTag.InnerHtml.Append(text);
        return buttonTag;
    }
}