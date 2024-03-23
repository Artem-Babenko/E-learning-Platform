using Infrastructure.Attributes;
using Infrastructure.Translate;

namespace Infrastructure.Enums;

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
