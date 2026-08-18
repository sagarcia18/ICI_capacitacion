using Autodesk.Revit.UI;
using ICI_capacitacion.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICIRib = ICI_capacitacion.Utilities.RibbonUtils;

namespace ICI_capacitacion.Extensions
{
    public static class RibbonPanel_Ext
    {
        #region BUTTON CREATION

        /// <summary>
        /// Adds a push button to the specified ribbon panel.
        /// Method will be descrubed as in the hover menu
        /// </summary>
        /// <param name="panel">The ribbon panel to add the button to (extended)</param>
        /// <param name="buttonName">The name of the button</param>
        /// <param name="className">The class name of the command</param>
        /// <returns>The created push button or null if creation failed</returns>
        /// 
        public static PushButton Ext_AddPushButton(this RibbonPanel panel,
            string buttonName,
            string className)
        {
            if (panel is null)
            {
                Debug.WriteLine($"Ribbon panel is null. Cannot add button '{buttonName}'.");
                return null;
            }

            var pushButtonData = ICIRib.NewPushButtonData(buttonName, className);

            if (panel.AddItem(pushButtonData) is PushButton pushButton)
            {
                return pushButton;
            }
            else
            {
                Debug.WriteLine($"Failed to add button '{buttonName}' to panel '{panel.Name}'.");
                return null;
            }
        }

        /// <summary>
        /// Adds a pulldown button to the specified ribbon panel.
        /// </summary>
        /// <param name="panel">The ribbon panel to add the button to (extended)</param>
        /// <param name="buttonName">The name of the button</param>
        /// <param name="className">The class name of the command</param>
        /// <returns>The created pulldown button or null if creation failed</returns>
        public static PulldownButton Ext_AddPulldownButton(this RibbonPanel panel,
            string buttonName,
            string className)
        {
            if (panel is null)
            {
                Debug.WriteLine($"Ribbon panel is null. Cannot add pulldown button '{buttonName}'.");
                return null;
            }
            var pulldownButtonData = ICIRib.NewPulldownButtonData(buttonName, className);
            if (panel.AddItem(pulldownButtonData) is PulldownButton pulldownButton)
            {
                return pulldownButton;
            }
            else
            {
                Debug.WriteLine($"Failed to add pulldown button '{buttonName}' to panel '{panel.Name}'.");
                return null;
            }
        }
        #endregion

    }
}
