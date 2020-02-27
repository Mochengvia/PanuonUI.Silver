using Panuon.UI.Silver.Internal.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Panuon.UI.Silver
{
    public static class MessageBoxX
    {
        #region Ctor
        static MessageBoxX()
        {
            DefaultMessageBoxXConfigurations = new MessageBoxXConfigurations();
            MessageBoxXConfigurations = new Dictionary<string, MessageBoxXConfigurations>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="defaultButton">The default button. Buttons set as default will be highlighted.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>

        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(null, messageBoxText, caption, button, icon, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(null, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxIcon icon, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxIcon icon, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, icon, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, string caption, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(string messageBoxText, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(null, messageBoxText, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
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
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurations);
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
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="icon">Large icon displayed on the left side of the message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, icon, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="button">The group of buttons to display in the message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(owner, messageBoxText, caption, button, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="caption">The title of message box.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="messageBoxXConfigurations">Message box customization details. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            return CallMessageBox(owner, messageBoxText, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurations);
        }

        /// <summary>
        /// Open a message box and return the result selected by the user.
        /// </summary>
        /// <param name="owner">The owner of message box.</param>
        /// <param name="messageBoxText">Text to display.</param>
        /// <param name="messageBoxXConfigurationsKey">The key stored in the MessageBoxX.MessageBoxConfigurations static property. You can get the MessageBoxXConfigurations by the pre-defined key anywhere in the current AppDomain. If the value is null, the value of MessageBoxX.DefaultMessageBoxXConfigurations static property will be used instead.</param>
        public static MessageBoxResult Show(Window owner, string messageBoxText, string messageBoxXConfigurationsKey = null)
        {
            return CallMessageBox(owner, messageBoxText, null, MessageBoxButton.OK, MessageBoxIcon.None, DefaultButton.YesOK, messageBoxXConfigurationsKey);
        }
        #endregion

        #region Property
        public static MessageBoxXConfigurations DefaultMessageBoxXConfigurations { get; }

        public static IDictionary<string, MessageBoxXConfigurations> MessageBoxXConfigurations { get; }
        #endregion

        #region Function
        private static MessageBoxResult CallMessageBox(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            if (messageBoxXConfigurations == null)
            {
                messageBoxXConfigurations = DefaultMessageBoxXConfigurations;
            }
            return CallMsgBox(owner, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurations);
        }

        private static MessageBoxResult CallMessageBox(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, string messageBoxXConfigurationsKey)
        {
            var messageBoxXConfigurations = DefaultMessageBoxXConfigurations;

            if (!string.IsNullOrEmpty(messageBoxXConfigurationsKey))
            {
                if (!MessageBoxXConfigurations.ContainsKey(messageBoxXConfigurationsKey))
                {
                    throw new Exception($"Exception in MessageBoxX : key {messageBoxXConfigurationsKey} does not exist. Please use `MessageBoxX.MessageBoxXConfigurations[\"{messageBoxXConfigurationsKey}\"] = new MessageBoxXConfigurations();` to define.");
                }
                messageBoxXConfigurations = MessageBoxXConfigurations[messageBoxXConfigurationsKey];
            }
            return CallMsgBox(owner, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurations);
        }

        private static MessageBoxResult CallMsgBox(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxIcon icon, DefaultButton defaultButton, MessageBoxXConfigurations messageBoxXConfigurations)
        {
            var func = new Func<MessageBoxResult>(() =>
            {
                var msgBox = new MsgBox(owner, messageBoxText, caption, button, icon, defaultButton, messageBoxXConfigurations);
                msgBox.ShowDialog();
                return msgBox.MessageBoxResult;
            });

            MessageBoxResult result = MessageBoxResult.OK;

            if (Application.Current?.Dispatcher != null)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
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
