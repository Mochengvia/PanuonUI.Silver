using Panuon.UI.Silver.Components;
using Panuon.UI.Silver.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Panuon.UI.Silver
{
    public static class MessageBoxX
    {
        #region Ctor
        static MessageBoxX()
        {
            Configurations = new MessageBoxXConfigurations();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Open a message box .
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        public static MessageBoxResult Show(string messageBoxText)
        {
            return CallMessageBox(null, messageBoxText, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText)
        {
            return CallMessageBox(owner, messageBoxText, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption)
        {
            return CallMessageBox(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK);
        }
   
        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button)
        {
            return CallMessageBox(null, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxIcon icon)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxIcon icon)
        {
            return CallMessageBox(owner, messageBoxText, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK);
        }


        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, DefaultButton.YesOK);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, defaultButton);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, defaultButton);
        }

        #endregion

        #region Property
        public static Dispatcher Dispatcher { get; set; } = Application.Current?.Dispatcher;

        public static MessageBoxXConfigurations Configurations { get; }
        #endregion

        #region Function
        private static MessageBoxResult CallMessageBox(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton)
        {
            var func = new Func<MessageBoxResult>(() =>
            {
                var ownerX = owner as WindowX;
                if(Configurations.InteractOwnerMask && ownerX != null)
                {
                    ownerX.IsMaskVisible = true;
                }
                var msgBox = new Components.MessageBoxX(messageBoxText, caption, button, icon, defaultButton, Configurations.ButtonArrangement, Configurations.IsEscEnabled, owner, Configurations.YesButton, Configurations.NoButton, Configurations.CancelButton, Configurations.OKButton);
                msgBox.ShowDialog();
                if (Configurations.InteractOwnerMask && ownerX != null)
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
