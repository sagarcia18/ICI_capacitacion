using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICI_capacitacion.Extensions
{
    public static class UIControlledApplication_Ext
    {
        /// <summary>
        /// Attempts to add a ribbon tab to the application.
        /// </summary>
        /// <param name="uiCtlApp">The UIControlledApplication instance (extended) .</param>
        /// <param name="tabName">The name of the tab to add.</param>
        /// <returns>The result of the operation.</returns>
        //Method to add a ribbon tab, with exception handling for existing tabs

        public static Result AddRibbonTab(this UIControlledApplication uiCtlApp, string tabName)
        {
            try
            {
                uiCtlApp.CreateRibbonTab(tabName);
                return Result.Succeeded;

            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // The tab already exists, so we can ignore this exception
                Debug.WriteLine($"Ribbon tab '{tabName}' already exists."); // Log the exception message for debugging purposes
                return Result.Failed;
            }

        }

        /// <summary>
        /// Attempts to add a ribbon panel to a specified tab. Returns null if the panel already exists.
        /// </summary>
        /// <param name="uiCtlApp">The UIControlledApplication instance (extended).</param>
        /// <param name="tabName">The name of the tab to which to add the panel.</param>
        /// <param name="panelName">The name of the panel to add.</param>
        /// <returns>The created ribbon panel if successful, otherwise null.</returns>

        public static RibbonPanel AddRibbonPanel(this UIControlledApplication uiCtlApp, string tabName, string panelName)
        {
            try
            {
                return uiCtlApp.CreateRibbonPanel(tabName, panelName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
                // The panel already exists, so we can ignore this exception
                Debug.WriteLine($"Ribbon panel '{panelName}' already exists in tab '{tabName}'."); // Log the exception message for debugging purposes
                return null; // Return null to indicate that the panel was not created, taking advantage of the fact that a RibbonPanel is nullable
            }
        }

        /// <summary>
        /// Attempts to get a ribbon panel by name from a specified tab. Returns null if not found.
        /// </summary>
        /// <param name="uiCtlApp">The UIControlledApplication instance (extended).</param>
        /// <param name="tabName">The name of the tab containing the panel.</param>
        /// <param name="panelName">The name of the panel to retrieve.</param>
        /// <returns>The ribbon panel if found, otherwise null.</returns>

        public static RibbonPanel GetRibbonPanel(this UIControlledApplication uiCtlApp, string tabName, string panelName)
        {
            var ribbonPanels = uiCtlApp.GetRibbonPanels(tabName);
            foreach (var panel in ribbonPanels)
            {
                if (panel.Name == panelName)
                {
                    return panel;
                }
            }
            return null; // Return null if the panel is not found
        }
    }
}
