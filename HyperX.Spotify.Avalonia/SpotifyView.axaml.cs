using Avalonia.Controls;

namespace HyperX.Spotify.Avalonia;

public partial class SpotifyView : UserControl
{
    public SpotifyView()
    {
        InitializeComponent();
        Test.Click += Test_Click;
    }

    private void Test_Click(object? sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        Test.Content = Guid.NewGuid();
    }
}
