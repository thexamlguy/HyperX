using Avalonia.Controls;
using Avalonia.Threading;

namespace HyperX.DateTime.Avalonia
{
    public partial class DateTimeView : 
        UserControl
    {
        private readonly DispatcherTimer timer;

        public DateTimeView()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += OnTick;
            timer.Start();
        }

        private void OnTick(object? sender, EventArgs args)
        {
            if (DataContext is DateTimeViewModel viewModel)
            {
                viewModel.Value = DateTimeOffset.Now;
            }
        }
    }
}
