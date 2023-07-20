using Avalonia;
using Avalonia.Controls;
using RoutedEventArgs = Avalonia.Interactivity.RoutedEventArgs;

class MainClass {
    public static void Main(string[] args) {
        AppBuilder
            .Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    public static void AppMain(Application app, string[] args) {
        // Application needs a theme to render window content
        app.Styles.Add(new Avalonia.Themes.Simple.SimpleTheme());
        app.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Default; // Default, Dark, Light

        // Create window
        var win = new Window();
        win.Title = "Avalonia no XAML";
        win.Width = 800;
        win.Height = 600;

        var grid = new Grid();
        win.Content = grid;

        grid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        grid.VerticalAlignment   = Avalonia.Layout.VerticalAlignment.Center;

        // Define grid rows
        { var tmp_rd = new RowDefinition();
          tmp_rd.Height = GridLength.Auto;
          grid.RowDefinitions.Add(tmp_rd); }

        { var tmp_rd = new RowDefinition();
          tmp_rd.Height = GridLength.Auto;
          grid.RowDefinitions.Add(tmp_rd); }

        var text = new Label();
        grid.Children.Add(text);
        text.SetValue(Avalonia.Controls.Grid.RowProperty, 0);

        text.Content = "Hello from C#!";
        text.FontSize = 64;
        text.Padding = new Thickness(0, 20);

        var btn = new Button();
        grid.Children.Add(btn);
        btn.SetValue(Avalonia.Controls.Grid.RowProperty, 1);

        btn.Content = "Click Me!";
        btn.FontSize = 48;
        btn.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        btn.Padding = new Thickness(50, 20);

        btn.Click += (object sender, RoutedEventArgs e) => {
            text.Content = "Clicked a button!";
        };

        win.Show();
        app.Run(win);
    }
}
