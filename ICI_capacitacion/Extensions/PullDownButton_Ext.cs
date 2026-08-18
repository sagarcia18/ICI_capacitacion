using Autodesk.Revit.UI;
using System.Diagnostics;
using ICIRib = ICI_capacitacion.Utilities.RibbonUtils;

namespace ICI_capacitacion.Extensions
{
    public static class PullDownButton_Ext
    {
        #region BUTTON CREATION

        /// <summary>
        /// Adds a push button on a pulldown button.
        /// Method will be descrubed as in the hover menu
        /// </summary>
        /// <param name="pullDownButton">The button to add the button to (extended)</param>
        /// <param name="buttonName">The name of the button</param>
        /// <param name="className">The class name of the command</param>
        /// <returns>The created push button or null if creation failed</returns>
        /// 
        public static PushButton Ext_AddPushButton(this PulldownButton pullDownButton,
            string buttonName,
            string className)
        {
            if (pullDownButton is null)
            {
                Debug.WriteLine($"Cannot add push button '{buttonName}' to pulldown button.");
                return null;
            }

            var pushButtonData = ICIRib.NewPushButtonData(buttonName, className);

            if (pullDownButton.AddPushButton(pushButtonData) is PushButton pushButton)
            {
                return pushButton;
            }
            else
            {
                Debug.WriteLine($"Failed to add button '{buttonName}' to pulldown button '{pullDownButton.Name}'.");
                return null;
            }
        }

        #endregion

    }
}
