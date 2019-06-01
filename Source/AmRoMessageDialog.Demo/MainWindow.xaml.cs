using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace AmRoMessageDialog.Demo
{
    /// <inheritdoc cref="MainWindow" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _messageBox = new AmRoMessageBox
            {
                Background = "#333",
                TextColor = "#fff",
                RippleEffectColor = "#000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true,
                EffectArea = this,
                ParentWindow = this,
                IconColor = "#3399ff",
                CaptionFontSize = 16,
                MessageFontSize = 14
            };
        }

        private readonly AmRoMessageBox _messageBox;

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void BtnStaticMessageBox1_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBox.ShowDialog("This is a sample message");
        }

        private void BtnStaticMessageBox2_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBox.ShowDialog("This is a sample message", "Sample Caption");
        }

        private void BtnStaticMessageBox3_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBox.ShowDialog("This is a sample message", "Sample Caption", AmRoMessageBoxButton.YesNo);
        }

        private void BtnStaticMessageBox4_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBox.ShowDialog("This is a sample message", "Sample Caption",
                AmRoMessageBoxButton.OkCancel, AmRoMessageBoxIcon.Success);
        }

        private void BtnNonStaticMessageBox1_OnClick(object sender, RoutedEventArgs e)
        {
            _messageBox.Show("This is a sample message");
        }

        private void BtnNonStaticMessageBox2_OnClick(object sender, RoutedEventArgs e)
        {
            _messageBox.Show("This is a sample message", "Sample Caption");
        }

        private void BtnNonStaticMessageBox3_OnClick(object sender, RoutedEventArgs e)
        {
            _messageBox.Show("This is a sample message", "Sample Caption", AmRoMessageBoxButton.YesNo);
        }

        private void BtnNonStaticMessageBox4_OnClick(object sender, RoutedEventArgs e)
        {
            _messageBox.Show("This is a sample message", "Sample Caption",
                AmRoMessageBoxButton.OkCancel, AmRoMessageBoxIcon.Success);
        }
    }
}
