using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ICI_capacitacion.Forms
{
    public static class Custom
    {
        #region Message and variants
        /// <summary>
        /// Displays a message box with customizable title, message, buttons, and icon. Returns a FormResult object indicating the user's response.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="yesNo"></param>
        /// <param name="noCancel"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static FormResult Message(string title = null, string message = null,
            bool yesNo = false, bool noCancel = false, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            //Base form result object
            var FormResult = new FormResult(isValid: false);

            // Default values for title and message
            title ??= "Default title";
            message ??= "No message provided";
            // Catch the question icon
            if (yesNo && icon == MessageBoxIcon.None)
            { icon = MessageBoxIcon.Question; }


            //Set buttons
            var buttons = MessageBoxButtons.OKCancel;
            if (noCancel)
            {
                buttons = MessageBoxButtons.OK;
            }
            else if (yesNo)
            {
                buttons = MessageBoxButtons.YesNo;
            }

            //Run the form

            var dialogResult = MessageBox.Show(message, title, buttons, icon);

            // Process the result
            if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.OK)
            {
                FormResult.Validate();
            }

            //return the form result
            return FormResult;
        }
        /// <summary>
        /// Displays a message box indicating that a task has been completed successfully. Returns a FormResult object indicating the user's response.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Completed(String message)
        {
            Message(title: "task Completed",
               message: message,
                noCancel: true,
                icon: MessageBoxIcon.Information);

            return Result.Succeeded;
        }
        /// <summary>
        /// Displays a message box indicating that an error has occurred. Returns a FormResult object indicating the user's response.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Error(String message)
        {
            Message(title: "Error",
               message: message,
                noCancel: true,
                icon: MessageBoxIcon.Error);
            return Result.Cancelled;
        }
        /// <summary>
        /// Displays a message box indicating that a task has been cancelled. Returns a FormResult object indicating the user's response.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result Cancelled(String message)
        {
            Message(title: "task Completed",
               message: message,
                noCancel: true,
                icon: MessageBoxIcon.Warning);
            return Result.Cancelled;
        }

        #endregion

        public static FormResult SelectFromDropdown(List<string> keys, List<object> values,
            string title = null, string message = null, int defaultIndex = -1)
        {
            var formResult = new FormResult(isValid: false);

            // Set default values for title and message
            title ??= "Select an option";
            message ??= "Please select an option from the dropdown list.";

            //Process the form 
            using (var form = new Base.BaseDropdown(keys, values, title, message, defaultIndex))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    formResult.Validate(form.Tag as object);

                    return formResult;
                }
            }
            return formResult;
        }

        public static FormResult SelectFromDropdown(List<string> keys, List<object> values, bool notBasic,
           string title = null, string message = null, int defaultIndex = -1)
        {
            var formResult = new FormResult(isValid: false);

            // Set default values for title and message
            title ??= "Select an option";
            message ??= "Please select an option from the dropdown list.";

           
            //Process the form 
            if(notBasic)
            {
                using (var form = new Hanger.HangerSelection(keys, values, title, message, defaultIndex))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        formResult.Validate(form.Tag as object);
                        return formResult;
                    }   
                }
            }
            else
            {
                using (var form = new Hanger.HangerSelection(keys, values, title, message, defaultIndex))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        formResult.Validate(form.Tag as object);
                        return formResult;
                    }
                }
            }
            return formResult;
        }
    }

    #region FormResult class
    public class FormResult
    {
        //Form object properties 
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        // Form condition properties
        public bool Cancelled { get; set; }
        public bool Valid { get; set; }
        public bool Affirmative { get; set; } 
        //Constructor (default)
        public FormResult()
        {
            this.Object = null;
            this.Objects = new List<object>();
            this.Cancelled = true;
            this.Valid = false;
            this.Affirmative = false;
        }
        //Constructor (alternative)
        public FormResult(bool isValid)
        {
            this.Object = null;
            this.Objects = new List<object>();
            this.Cancelled = !isValid;
            this.Valid = isValid;
            this.Affirmative = isValid;
        }
        //Method
        public void Validate()
        {
            this.Cancelled = false;
            this.Valid = true;
            this.Affirmative = true;
        }

        public void Validate(object obj)
        {
            this.Validate();  
            this.Object = obj;
        }

        public void Validate(List<object> objs)
        {
            this.Validate();
            this.Objects = objs;
        }
    }

    #endregion
}
