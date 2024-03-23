using Infrastructure.Enums;

namespace Web.Models;

/// <summary> Модель макету сторінки. Містить у собі властивості, 
/// які можна отримати на будь якій сторінці сайту. </summary>
public class LayoutModel
{
    public eLanguages Language { get; set; }
}
