using Translate;
using BLL.Attributes;
using System.Reflection;

namespace BLL.Extensions;

/// <summary> Розширення на атрибути. </summary>
public static class AttrExtensions
{
    /// <summary> Метод отримання значення атрибута <see cref="Description"/>. 
    /// Якщо це значення значення має переклад, буде повернено
    /// переклад з <see cref="TranslateResources"/>. </summary>
    /// <returns>Текстовий опис властивості або поля.</returns>
    public static string GetDescription<T>(this T type)
    {
        FieldInfo? fieldInfo = type?.GetType().GetField(type.ToString() ?? "");

        Description? descriptionAttr = (Description?)fieldInfo?
            .GetCustomAttribute(typeof(Description));
        var text = descriptionAttr?.Text;

        var translateProperties = typeof(TranslateResources)
            .GetProperties(BindingFlags.Static | BindingFlags.Public).ToList();

        var property = translateProperties.FirstOrDefault(p => p.Name == text);

        return property != null
            ? property.GetValue(null)?.ToString() ?? "No translate"
            : text ?? "null description";
    }
}
