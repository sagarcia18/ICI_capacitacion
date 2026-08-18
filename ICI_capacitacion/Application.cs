using ICI_capacitacion.Commands;
using Autodesk.Revit.UI;
using ICIRib = ICI_capacitacion.Utilities.RibbonUtils;
using ICI_capacitacion.Extensions;
using Autodesk.Revit.UI.Events;
using ICI_capacitacion.General;

namespace ICI_capacitacion
{
    public class Application : IExternalApplication
    {

        #region Properties
        // Make a private uiCtlApp
        private static UIControlledApplication _uiCtlApp;
        #endregion
        #region On startup method
        public Result OnStartup(UIControlledApplication uiCtlApp)
        {

            #region Globals registration
            // Store _iCtlApp, register on idling
            _uiCtlApp = uiCtlApp;
            try
            {
                _uiCtlApp.Idling += RegisterUiApp;
            }
            catch
            {
                Globals.UiApp = null;
                Globals.UsernameRevit = null;
            }
            // Registering globals
            Globals.RegisterProperties(uiCtlApp);
            Globals.RegisterTooltips("ICI_capacitacion.Resources.Files.Tooltips");
            #endregion

            #region Ribbon setup
            //Add ribbon tab 
            uiCtlApp.AddRibbonTab(Globals.AddinName);

            //Create panel
            var panelGeneral = uiCtlApp.AddRibbonPanel(Globals.AddinName, "General");

            //Add button
            var buttonTest = panelGeneral.Ext_AddPushButton( "test", "ICI_capacitacion.Cmds_General.Cmd_Button");

            // Add pulldownbutton to panel
            var pulldownTest = panelGeneral.Ext_AddPulldownButton("Test Pulldown","ICI_capacitacion.Cmds_PullDown");

            // Add buttons to pulldown
                pulldownTest.Ext_AddPushButton("Button 1", "ICI_capacitacion.Cmds_PullDown.Cmd_1Button");
                pulldownTest.Ext_AddPushButton("Button 2", "ICI_capacitacion.Cmds_PullDown.Cmd_2Button");
                pulldownTest.Ext_AddPushButton("Button 3", "ICI_capacitacion.Cmds_PullDown.Cmd_3Button");

            // Create data objects in the stack
            var stack1Data = ICIRib.NewPulldownButtonData("Stack1", "ICI_capacitacion.Cmds_Stack1");
            var stack2Data = ICIRib.NewPulldownButtonData("Stack2", "ICI_capacitacion.Cmds_Stack2");
            var stack3Data = ICIRib.NewPulldownButtonData("Stack3", "ICI_capacitacion.Cmds_Stack3");
             
            var stack = panelGeneral.AddStackedItems(stack1Data, stack2Data, stack3Data); // The function retrieves a list of ribbons
            var pulldownStack1 = stack[0] as PulldownButton;
            var pulldownStack2 = stack[1] as PulldownButton;
            var pulldownStack3 = stack[2] as PulldownButton;

            pulldownStack1.Ext_AddPushButton("Button", "ICI_capacitacion.Cmds_Stack1.Cmd_Button");
            pulldownStack2.Ext_AddPushButton("Button", "ICI_capacitacion.Cmds_Stack2.Cmd_Button");
            pulldownStack3.Ext_AddPushButton("Button", "ICI_capacitacion.Cmds_Stack3.Cmd_Button");

            #endregion
            return Result.Succeeded;
        }

        #endregion
        #region OnShutdown Method

        public Result OnShutdown(UIControlledApplication uiCtlApp)
        {
            return Result.Succeeded;
        }

        #endregion
        // On idling, register UiApp/username
        private static void RegisterUiApp(object sender, IdlingEventArgs e)
        {
            _uiCtlApp.Idling -= RegisterUiApp;

            if (sender is UIApplication uiApp)
            {
                Globals.UiApp = uiApp;
                Globals.UsernameRevit = uiApp.Application.Username;
            }
        }

    }
}