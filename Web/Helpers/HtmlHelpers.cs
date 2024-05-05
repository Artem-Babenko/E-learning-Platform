using Infrastructure.Enums;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Helpers;

public static class HtmlHelpers
{
    /// <summary>Creates simple drop down list with languages.</summary>
    /// <returns>Html select element.</returns>
    public static IHtmlContent LanguageSelectList<TModel>(
        this IHtmlHelper<TModel> htmlHelper,
        eLanguages selectedLanguage)
    {
        var languages = Enum.GetValues(typeof(eLanguages))
            .Cast<eLanguages>()
            .Select(language => new SelectListItem()
            {
                Text = language.GetDescription(),
                Value = language.ToString(),
                Selected = language == selectedLanguage
            });

        return htmlHelper.DropDownList(
            "LanguageSelect", 
            languages, 
            new { @class = "site-language-select" }
        );
    }
}
