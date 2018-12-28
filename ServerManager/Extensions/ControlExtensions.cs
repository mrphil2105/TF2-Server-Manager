using System;
using System.Text;
using System.Windows.Forms;

namespace ServerManager.Extensions
{
    public static class ControlExtensions
    {
        public static void ShowMessage(this Control control, string message, string title, bool async = true)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            var action = new Action(() => MessageBox.Show(control, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information));

            if (async)
            {
                BeginInvoke(control, action);
                return;
            }

            action();
        }

        public static void ShowError(this Control control, string message, string title, bool async = true)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            var action = new Action(() => MessageBox.Show(control, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error));

            if (async)
            {
                BeginInvoke(control, action);
                return;
            }

            action();
        }

        public static DialogResult ShowQuestion(this Control control, string message, string title, bool cancel = false)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return MessageBox.Show(control, message, title, cancel ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static void Invoke(this Control control, Action action)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
                return;
            }

            action();
        }

        public static IAsyncResult BeginInvoke(this Control control, Action action)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return control.BeginInvoke(action);
        }

        public static string ToPascalSpacedString<TEnum>(this TEnum value) where TEnum : Enum
        {
            var builder = new StringBuilder(value.ToString());
            int lastUpperIndex = -1;

            for (int i = 0; i < builder.Length; i++)
            {
                if (char.IsUpper(builder[i]))
                {
                    if (lastUpperIndex != -1)
                    {
                        builder.Insert(i++, ' ');
                    }

                    lastUpperIndex = i;
                }
            }

            return builder.ToString();
        }
    }
}
