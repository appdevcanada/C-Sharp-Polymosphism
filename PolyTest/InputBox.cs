////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	InputBox.cs
//
// summary:	Implements the input box class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolymorphismDrawingApp
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input box. </summary>
    ///
    /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class InputBox
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates and Displays an InputBox </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="title">        The title. </param>
        /// <param name="promptText">   The prompt text. </param>
        /// <param name="text">         [in,out] The text. </param>
        ///
        /// <returns>   A DialogResult. </returns>
        ///
        /// ### <param name="value">    [in,out] The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static DialogResult DoInputDialogBox(string title, string promptText, ref string text)
        {
            const int width = 396;
            const int height = 107;

            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = text;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            label.AutoSize = true;

            form.ClientSize = new Size(width, height);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            text = textBox.Text;
            return dialogResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the InputBox. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="title">        The title. </param>
        /// <param name="promptText">   The prompt text. </param>
        /// <param name="text">         [in,out] The text. </param>
        ///
        /// <returns>   A DialogResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DialogResult Show(string title, string promptText, ref string text)
        {
            return DoInputDialogBox(title, promptText, ref text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the InputBox. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="promptText">   The prompt text. </param>
        /// <param name="text">         [in,out] The text. </param>
        ///
        /// <returns>   A DialogResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DialogResult Show(string promptText, ref string text)
        {
            return DoInputDialogBox("Enter Information", promptText, ref text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the InputBox. </summary>
        ///
        /// <remarks>   Tony Davidson, 2018-03-28. </remarks>
        ///
        /// <param name="text"> [in,out] The text. </param>
        ///
        /// <returns>   A DialogResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static DialogResult Show( ref string text)
        {
            return DoInputDialogBox("Enter Information", "Enter:", ref text);
        }
    }
}
