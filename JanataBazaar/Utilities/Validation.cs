using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JanataBazaar.Utilities
{
    internal class Validation
    {
        #region 'Validation

        /// <summary>
        /// Converts Input to Title Case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToTitleCase(string input)
        {
            if (String.IsNullOrEmpty(input)) return String.Empty;
            //else
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        /// checks if the container with controls editted
        /// </summary>
        /// <param name="container"></param>
        /// <param name="Recurse">true -> if control has parent container else false </param>
        /// <returns>bool</returns>
        public static bool IsInEdit(Control controls, bool Recurse = false)
        {
            foreach (Control ctrol in controls.Controls)
            {
                if (ctrol is TextBox && ctrol.Text != "") return true;

                if (Recurse)
                {
                    if ((ctrol is TabPage || ctrol is Panel || ctrol is GroupBox) && IsInEdit(ctrol, Recurse))
                        return true;
                }
            }
            //else
            return false;
        }

        //todo: add the following function to winform_abstract 
        //todo: rewrite the code to fetch using foreach() txt's first and image later - use linq with lambdha
        /// <summary>
        /// checks if the container sent has any controls with no value
        /// </summary>
        /// <param name="container"></param>
        /// <param name="Recurse">true -> if control has parent container else false </param>
        /// <param name="ExceptionControl">it consists the name of control that has to be treated as an exception by default it has</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Control container, Boolean Recurse, List<string> ExceptionControl = null)
        {
            //todo: include error provider instead of messagebox
            if (ExceptionControl == null)
                ExceptionControl = new List<string>();

            foreach (Control ctrol in container.Controls)
            {
                if ((ctrol is TextBox || ctrol is RichTextBox) && string.IsNullOrEmpty(ctrol.Text) && !ExceptionControl.Contains(ctrol.Name))
                {
                    MessageBox.Show("Textbox " + ctrol.Name + " is Mandatory and cannot be empty.." + Environment.NewLine + "Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctrol.Focus();
                    return true;
                }
                if (ctrol is PictureBox && ((PictureBox)ctrol).Image == null && !ExceptionControl.Contains(ctrol.Name))
                {
                    MessageBox.Show(ctrol.Name + " Image is Mandatory and cannot be empty." + Environment.NewLine + "Please insert and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                if (ctrol is ComboBox && string.IsNullOrEmpty(((ComboBox)ctrol).Text) && !ExceptionControl.Contains(ctrol.Name))
                {
                    MessageBox.Show("ComboBox " + ctrol.Name + " is Mandatory and cannot be empty." + Environment.NewLine + "Please insert and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                if (Recurse)
                {
                    if ((ctrol is TabPage || ctrol is Panel || ctrol is GroupBox) && (!ExceptionControl.Contains(ctrol.Name))
                        && IsNullOrEmpty(ctrol, Recurse, ExceptionControl))
                        return true;
                }
            }
            return false;
        }

        #endregion 'Validation
    }
}