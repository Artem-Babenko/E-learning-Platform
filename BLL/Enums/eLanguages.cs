
using Translate;
using BLL.Attributes;
namespace BLL.Enums;

/// <summary> Перелік мов доступних на сайті. </summary>
public enum eLanguages
{
    [Description(nameof(TranslateResources.UA))]
    UK,
    [Description(nameof(TranslateResources.ENG))]
    EN,
    [Description(nameof(TranslateResources.RU))]
    RU
}
