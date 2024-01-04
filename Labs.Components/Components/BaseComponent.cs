using Microsoft.AspNetCore.Components;

namespace Labs.Components.Components;
public class BaseComponent : ComponentBase
{
    [Parameter]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? UserAttributes { get; set; }

    protected override void OnInitialized()
    {
        if (UserAttributes != null)
        {
            if (UserAttributes.TryGetValue("id", out var id))
            {
                Id = id.ToString() ?? Guid.NewGuid().ToString();
            }

            if (UserAttributes.TryGetValue("class", out var className))
            {
                Class += " " + className.ToString();
            }

            if (UserAttributes.TryGetValue("style", out var style))
            {
                Style += style.ToString();
            }
        }

        base.OnInitialized();
    }
}
