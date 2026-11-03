using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PasswordManager.UI.Services;

namespace PasswordManager.Desktop;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    public App()
    {
        var services = new ServiceCollection();
        services.AddWpfBlazorWebView();
        services.AddSingleton<LanguageService>();
        services.AddSingleton<ThemeService>();
        Services = services.BuildServiceProvider();
    }
}
