using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace AmRoMessageDialog
{
    /// <summary>
    /// Interaction logic for WinMessageBox.xaml
    /// </summary>
    public partial class WinMessageBox
    {
        public WinMessageBox()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public WinMessageBox(Window owner) : this()
        {
            if (owner == null) return;
            Owner = owner;
            ParentWindow = owner;
        }

        private void WinMessageBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            Opacity = 0;
            SetMessageBoxContent();
            PrepareMessageBoxButtons();
            PrepareMessageBoxIcon();
            SetMessageBoxDirection();
            SetMessageContentDirection();
            SettingUpWindowAppearance();
            PrepareMessageWindow();
            Opacity = 1;
        }

        #region Properties

        #region Message Box Appearance

        public AmRoMessageBoxWindowEffect WindowEffect { get; set; }
        public SolidColorBrush WindowBackground { private get; set; }
        public SolidColorBrush TextColor { private get; set; }
        public SolidColorBrush IconColor { private get; set; }
        public SolidColorBrush RippleEffectColor { private get; set; }
        public SolidColorBrush ClickEffectColor { private get; set; }
        public new FontFamily FontFamily { private get; set; }
        public double MessageFontSize { private get; set; }
        public double CaptionFontSize { private get; set; }

        #endregion

        public AmRoMessageBoxResult AmRoMessageBoxResult { get; private set; }
        public AmRoMessageBoxButton AmRoMessageBoxButton { private get; set; }
        public AmRoMessageBoxIcon AmRoMessageBoxIcon { private get; set; }
        public FlowDirection AmRoMessageBoxDirection { private get; set; }
        public AmRoMessageBoxButtonsText AmRoMessageBoxButtonsText { private get; set; }
        public string Message { get; set; }
        public string Caption { get; set; }
        public bool ReverseContentDirection { get; set; }
        public Window ParentWindow { get; set; }
        public bool ShowMessageWithEffect { get; set; }

        #endregion

        #region UI Elements

        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBoxResult = AmRoMessageBoxResult.Ok;
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBoxResult = AmRoMessageBoxResult.Cancel;
            Close();
        }

        private void BtnYes_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBoxResult = AmRoMessageBoxResult.Yes;
            Close();
        }

        private void BtnNo_OnClick(object sender, RoutedEventArgs e)
        {
            AmRoMessageBoxResult = AmRoMessageBoxResult.No;
            Close();
        }

        private void RectWindowEffect_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (AmRoMessageBoxButton)
            {
                case AmRoMessageBoxButton.OkCancel:
                case AmRoMessageBoxButton.YesNoCancel:
                    AmRoMessageBoxResult = AmRoMessageBoxResult.Cancel;
                    break;
                case AmRoMessageBoxButton.YesNo:
                    AmRoMessageBoxResult = AmRoMessageBoxResult.No;
                    break;
                case AmRoMessageBoxButton.Ok:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Close();
        }

        #endregion

        #region My Methods

        private void SettingUpWindowAppearance()
        {
            Resources["BaseBackground"] = WindowBackground ?? WindowBackground;
            Resources["BaseIconColor"] = IconColor ?? IconColor;
            Resources["MaterialDesignFlatButtonRipple"] = RippleEffectColor ?? RippleEffectColor;
            Resources["MaterialDesignFlatButtonClick"] = ClickEffectColor ?? ClickEffectColor;
            Resources["BaseFontFamily"] = FontFamily ?? FontFamily;
            Resources["BaseCaptionFontSize"] = Math.Abs(CaptionFontSize) <= 0 ? 15 : CaptionFontSize;
            Resources["BaseMessageFontSize"] = Math.Abs(MessageFontSize) <= 0 ? 12 : MessageFontSize;

            if (WindowEffect != null)
            {
                Resources["BaseEffectColor"] = WindowEffect.Color ?? WindowEffect.Color;
                Resources["BaseEffectOpacity"] = Math.Abs(WindowEffect.Opacity) <= 0 ? 0.5 : WindowEffect.Opacity;
            }

            if (TextColor != null)
                Resources["BaseForeground"] = TextColor.Color;
        }

        private void PrepareMessageWindow()
        {
            if (ParentWindow == null 
                || !ShowMessageWithEffect 
                || ParentWindow.ActualWidth <= CardMain.ActualWidth + 200 
                || ParentWindow.ActualHeight <= CardMain.ActualHeight + 200)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                return;
            }

            var effectArea = WindowEffect.EffectArea as FrameworkElement;
            if (effectArea == null) return;

            WindowStartupLocation = WindowStartupLocation.Manual;
            RectWindowEffect.Visibility = Visibility.Visible;

            if (ParentWindow.WindowState == WindowState.Maximized)
            {
                Top = 0;
                Left = 0;
                Width = SystemParameters.WorkArea.Width;
                Height = SystemParameters.WorkArea.Height;
            }
            else
            {
                Top = ParentWindow.Top;
                Left = ParentWindow.Left;
                Width = ParentWindow.ActualWidth;
                Height = ParentWindow.ActualHeight;
            }

            if (effectArea is Window && ParentWindow.WindowState != WindowState.Maximized)
            {
                RectWindowEffect.Width = ParentWindow.ActualWidth;
                RectWindowEffect.Height = ParentWindow.ActualHeight;
                RectWindowEffect.Margin = new Thickness(7, 0, 7, 7);
            }
            else
            {
                RectWindowEffect.Width = effectArea.ActualWidth;
                RectWindowEffect.Height = effectArea.ActualHeight;
            }
        }

        private void SetMessageBoxContent()
        {
            if (string.IsNullOrEmpty(Caption))
            {
                RowCaption.Height = new GridLength(0);
                RowMessage.Height = new GridLength(3, GridUnitType.Star);
                TxtMessage.FontSize = LblCaption.FontSize;
                RectWindowEffect.MinHeight = 120;
                CardMain.MinHeight = 120;
            }
            else
            {
                RectWindowEffect.MinHeight = 140;
                CardMain.MinHeight = 140;
            }
            LblCaption.Content = Caption;
            TxtMessage.Text = Message;
        }

        private void SetMessageBoxDirection()
        {
            CardMain.FlowDirection = AmRoMessageBoxDirection;
        }

        private void SetMessageContentDirection()
        {

            if (AmRoMessageBoxDirection == FlowDirection.LeftToRight)
            {
                SpMessage.HorizontalAlignment = HorizontalAlignment.Left;
                SpMessage.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                SpMessage.HorizontalAlignment = HorizontalAlignment.Left;
                SpMessage.FlowDirection = FlowDirection.RightToLeft;
            }

            if (!ReverseContentDirection) return;

            SpMessage.HorizontalAlignment = SpMessage.HorizontalAlignment == HorizontalAlignment.Left ?
                HorizontalAlignment.Right : HorizontalAlignment.Left;

            SpMessage.FlowDirection = SpMessage.FlowDirection == FlowDirection.RightToLeft ?
                FlowDirection.LeftToRight : FlowDirection.RightToLeft;
        }

        private void PrepareMessageBoxIcon()
        {
            switch (AmRoMessageBoxIcon)
            {
                case AmRoMessageBoxIcon.None:
                    MessageBoxIcon.Visibility = Visibility.Collapsed;
                    break;
                case AmRoMessageBoxIcon.Warring:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.Alert;
                    break;
                case AmRoMessageBoxIcon.Error:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.CloseCircle;
                    break;
                case AmRoMessageBoxIcon.Success:
                    MessageBoxIcon.Visibility = Visibility.Visible;
                    MessageBoxIcon.Kind = PackIconKind.CheckCircle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PrepareMessageBoxButtons()
        {
            switch (AmRoMessageBoxButton)
            {
                case AmRoMessageBoxButton.Ok:
                    BtnOk.Visibility = Visibility.Visible;
                    break;
                case AmRoMessageBoxButton.YesNo:
                    BtnYes.Visibility = Visibility.Visible;
                    BtnNo.Visibility = Visibility.Visible;
                    break;
                case AmRoMessageBoxButton.OkCancel:
                    BtnOk.Visibility = Visibility.Visible;
                    BtnCancel.Visibility = Visibility.Visible;
                    break;
                case AmRoMessageBoxButton.YesNoCancel:
                    BtnYes.Visibility = Visibility.Visible;
                    BtnNo.Visibility = Visibility.Visible;
                    BtnCancel.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            SetButtonsText();
        }

        private void SetButtonsText()
        {
            if (AmRoMessageBoxButtonsText == null) return;
            BtnOk.Content = AmRoMessageBoxButtonsText.Ok ?? "Ok";
            BtnCancel.Content = AmRoMessageBoxButtonsText.Cancel ?? "Cancel";
            BtnYes.Content = AmRoMessageBoxButtonsText.Yes ?? "Yes";
            BtnNo.Content = AmRoMessageBoxButtonsText.No ?? "No";
        }

        #endregion 
    }
}
