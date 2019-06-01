using System.Windows;
using System.Windows.Media;

namespace AmRoMessageDialog
{
    public class AmRoMessageBox
    {

        #region Properties

        #region Static Properties

        public static Window Owner { get; set; }

        #endregion

        public string Background { internal get; set; }
        public string TextColor { internal get; set; }
        public string IconColor { internal get; set; }
        public string WindowEffectColor { internal get; set; }
        public object EffectArea { internal get; set; }
        public string RippleEffectColor { internal get; set; }
        public string ClickEffectColor { internal get; set; }
        public FontFamily FontFamily { internal get; set; }
        public double EffectOpacity { internal get; set; }
        public double MessageFontSize { internal get; set; }
        public double CaptionFontSize { internal get; set; }
        public FlowDirection Direction { internal get; set; }
        public AmRoMessageBoxButtonsText ButtonsText { internal get; set; }
        public Window ParentWindow { internal get; set; }
        public bool ShowMessageWithEffect { internal get; set; }
        internal string Caption { get; set; }
        internal string Message { get; set; }
        internal AmRoMessageBoxButton MessageBoxButton { get; set; }
        internal AmRoMessageBoxIcon MessageBoxIcon { get; set; }
        internal bool ReverseContentDirection { get; set; }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Display message box dialog
        /// </summary>
        /// <returns>AmRoMessageBoxResult</returns>
        private AmRoMessageBoxResult DisplayMessageDialog()
        {
            var messageWindow = new WinMessageBox(ParentWindow)
            {
                WindowBackground = GetSolidBrush(Background),
                TextColor = GetSolidBrush(TextColor),
                IconColor = GetSolidBrush(IconColor),
                RippleEffectColor = GetSolidBrush(RippleEffectColor),
                ClickEffectColor = GetSolidBrush(ClickEffectColor),
                MessageFontSize = MessageFontSize,
                CaptionFontSize = CaptionFontSize,
                FontFamily = FontFamily,
                Message = Message,
                Caption = Caption,
                AmRoMessageBoxButton = MessageBoxButton,
                AmRoMessageBoxIcon = MessageBoxIcon,
                ReverseContentDirection = ReverseContentDirection,
                AmRoMessageBoxDirection = Direction,
                AmRoMessageBoxButtonsText = ButtonsText,
                ParentWindow = ParentWindow,
                ShowMessageWithEffect = ShowMessageWithEffect,
                WindowEffect = new AmRoMessageBoxWindowEffect
                {
                    Color = GetSolidBrush(WindowEffectColor),
                    EffectArea = EffectArea,
                    Opacity = EffectOpacity
                }
            };

            if (ParentWindow != null)
            {
                ParentWindow.Focus();
                ParentWindow.Activate();
            }

            messageWindow.ShowDialog();
            ResetOptions();

            return messageWindow.AmRoMessageBoxResult;
        }

        /// <summary>
        /// Reset message box options
        /// </summary>
        private void ResetOptions()
        {
            MessageBoxButton = default(AmRoMessageBoxButton);
            MessageBoxIcon = default(AmRoMessageBoxIcon);
            ReverseContentDirection = default(bool);
        }

        /// <summary>
        /// Convert hexadecimal color to SolidColorBrush
        /// </summary>
        /// <param name="hexColor">Hexadecimal color</param>
        /// <returns>SolidColorBrush</returns>
        private static SolidColorBrush GetSolidBrush(string hexColor)
        {
            if (string.IsNullOrEmpty(hexColor))
                return null;
            try
            {
                return (SolidColorBrush)new BrushConverter().ConvertFrom(hexColor);
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region Static Message Box Methods

        /// <summary>
        /// Display message - static mode
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public static AmRoMessageBoxResult ShowDialog(string message, bool reverseContentDirection = false)
        {
            var messageWindow = new WinMessageBox(Owner ?? Owner)
            {
                Message = message,
                ReverseContentDirection = reverseContentDirection
            };
            messageWindow.ShowDialog();
            return messageWindow.AmRoMessageBoxResult;
        }

        /// <summary>
        /// Display message with a caption - static mode
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public static AmRoMessageBoxResult ShowDialog(string message, string caption,
            bool reverseContentDirection = false)
        {
            var messageWindow = new WinMessageBox(Owner ?? Owner)
            {
                Message = message,
                Caption = caption,
                ReverseContentDirection = reverseContentDirection
            };
            messageWindow.ShowDialog();
            return messageWindow.AmRoMessageBoxResult;
        }

        /// <summary>
        /// Display message with a caption and custom buttons - static mode
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public static AmRoMessageBoxResult ShowDialog(string message, string caption,
            AmRoMessageBoxButton messageBoxButton, bool reverseContentDirection = false)
        {
            var messageWindow = new WinMessageBox(Owner ?? Owner)
            {
                Message = message,
                Caption = caption,
                AmRoMessageBoxButton = messageBoxButton,
                ReverseContentDirection = reverseContentDirection
            };
            messageWindow.ShowDialog();
            return messageWindow.AmRoMessageBoxResult;
        }

        /// <summary>
        /// Display message with a caption, custom buttons and custom icon - static mode
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="messageBoxIcon">Message box icon</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public static AmRoMessageBoxResult ShowDialog(string message, string caption,
            AmRoMessageBoxButton messageBoxButton, AmRoMessageBoxIcon messageBoxIcon,
            bool reverseContentDirection = false)
        {
            var messageWindow = new WinMessageBox(Owner ?? Owner)
            {
                Message = message,
                Caption = caption,
                AmRoMessageBoxButton = messageBoxButton,
                AmRoMessageBoxIcon = messageBoxIcon,
                ReverseContentDirection = reverseContentDirection
            };
            messageWindow.ShowDialog();
            return messageWindow.AmRoMessageBoxResult;
        }

        /// <summary>
        /// Display message with a caption, custom buttons and custom icon - static mode
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="messageBoxIcon">Message box icon</param>
        /// <param name="dircetion">Specify message box direction</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public static AmRoMessageBoxResult ShowDialog(string message, string caption,
            AmRoMessageBoxButton messageBoxButton, AmRoMessageBoxIcon messageBoxIcon, FlowDirection dircetion,
            bool reverseContentDirection = false)
        {
            var messageWindow = new WinMessageBox(Owner ?? Owner)
            {
                Message = message,
                Caption = caption,
                AmRoMessageBoxButton = messageBoxButton,
                AmRoMessageBoxIcon = messageBoxIcon,
                AmRoMessageBoxDirection = dircetion,
                ReverseContentDirection = reverseContentDirection
            };
            messageWindow.ShowDialog();
            return messageWindow.AmRoMessageBoxResult;
        }
        #endregion

        #region Non-Static Message Box Methods

        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public AmRoMessageBoxResult Show(string message, bool reverseContentDirection = false)
        {
            Message = message;
            Caption = null;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public AmRoMessageBoxResult Show(string message, string caption,
            bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption and custom buttons
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public AmRoMessageBoxResult Show(string message, string caption,
            AmRoMessageBoxButton messageBoxButton, bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            MessageBoxButton = messageBoxButton;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }

        /// <summary>
        /// Display message with a caption, custom buttons, custom icon in RTL languages
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="caption">Message box caption</param>
        /// <param name="messageBoxButton">Message box buttons</param>
        /// <param name="messageBoxIcon">Message box icon</param>
        /// <param name="reverseContentDirection">Reverse message content direction</param>
        /// <returns>AmRoMessageBoxResult</returns>
        public AmRoMessageBoxResult Show(string message, string caption,
            AmRoMessageBoxButton messageBoxButton, AmRoMessageBoxIcon messageBoxIcon,
            bool reverseContentDirection = false)
        {
            Message = message;
            Caption = caption;
            MessageBoxButton = messageBoxButton;
            MessageBoxIcon = messageBoxIcon;
            ReverseContentDirection = reverseContentDirection;
            return DisplayMessageDialog();
        }
        #endregion

        #endregion
    }
}
