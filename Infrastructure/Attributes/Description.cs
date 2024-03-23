namespace Infrastructure.Attributes;

/// <summary> Представляє опис властивості або поля. 
/// Призначений для відображення перекладу. </summary>
public class Description : Attribute
{
    public string? Text { get; set; }

    public Description(string text) => Text = text;
}
