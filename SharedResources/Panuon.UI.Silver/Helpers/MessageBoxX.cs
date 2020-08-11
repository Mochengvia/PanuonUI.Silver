using Panuon.UI.Silver.Core;
using Panuon.UI.Silver.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public static class MessageBoxX
    {
        #region Fields
        #endregion

        #region Ctor
        static MessageBoxX()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Dispatcher used by default.
        /// </summary>
        public static Dispatcher Dispatcher { get; } = Application.Current?.Dispatcher;

        /// <summary>
        /// MessageBoxX settings.
        /// </summary>
        public static MessageBoxXSettings Settings { get; } = new MessageBoxXSettings();
        #endregion

        #region Methods
        /// <summary>
        /// Open a message box .
        /// </summary>
        /// <param name="text">Text to display.</param>
        public static MessageBoxResult Show(string text)
        {
            return CallMessageBox(null, text, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        public static MessageBoxResult Show(Window owner, string text)
        {
            return CallMessageBox(owner, text, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        public static MessageBoxResult Show(string text, string caption)
        {
            return CallMessageBox(null, text, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        public static MessageBoxResult Show(Window owner, string text, string caption)
        {
            return CallMessageBox(owner, text, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        public static MessageBoxResult Show(string text, string caption, MessageBoxButton button)
        {
            return CallMessageBox(null, text, caption, button, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        public static MessageBoxResult Show(Window owner, string text, string caption, MessageBoxButton button)
        {
            return CallMessageBox(owner, text, caption, button, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(string text, string caption, MessageBoxIcon icon)
        {
            return CallMessageBox(null, text, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(Window owner, string text, string caption, MessageBoxIcon icon)
        {
            return CallMessageBox(owner, text, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK);
        }


        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(string text, string caption, MessageBoxButton button, MessageBoxIcon icon)
        {
            return CallMessageBox(null, text, caption, button, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(Window owner, string text, string caption, MessageBoxButton button, MessageBoxIcon icon)
        {
            return CallMessageBox(owner, text, caption, button, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        public static MessageBoxResult Show(string text, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            return CallMessageBox(null, text, caption, button, icon, defaultButton);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="text">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        public static MessageBoxResult Show(Window owner, string text, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            return CallMessageBox(owner, text, caption, button, icon, defaultButton);
        }

        #endregion

        #region Event Handlers
        #endregion

        #region Functions
        private static MessageBoxResult CallMessageBox(Window owner, string text, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            var func = new Func<MessageBoxResult>(() =>
            {
                var ownerX = owner as WindowX;
                if (Settings.InteractOwnerMask && ownerX != null)
                {
                    ownerX.IsMaskVisible = true;
                }
                var msgBox = new Components.MessageBoxXWindow(text, caption, button, icon, defaultButton, owner, Settings);
                msgBox.ShowDialog();
                if (Settings.InteractOwnerMask && ownerX != null)
                {
                    ownerX.IsMaskVisible = false;
                }
                return msgBox.MessageBoxResult;
            });

            MessageBoxResult result = MessageBoxResult.OK;

            if (Dispatcher != null)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    result = func.Invoke();
                }));
            }
            else
            {
                result = func.Invoke();
            }

            return result;
        }

        #endregion
    }
}
