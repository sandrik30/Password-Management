namespace PasswordManager.UI.Services;

public sealed class ThemeService
{
    public string CurrentTheme { get; private set; } = "dark";

    public void SetTheme(string theme)
    {
        if (theme != "dark" && theme != "light")
            throw new ArgumentException("Unknown theme", nameof(theme));

        CurrentTheme = theme;
    }
}
