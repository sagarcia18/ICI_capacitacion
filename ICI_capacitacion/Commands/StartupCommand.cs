using Autodesk.Revit.Attributes;
using ICI_capacitacion.ViewModels;
using ICI_capacitacion.Views;
using Nice3point.Revit.Toolkit.External;

namespace ICI_capacitacion.Commands
{
    /// <summary>
    ///     External command entry point.
    /// </summary>
    [UsedImplicitly]
    [Transaction(TransactionMode.Manual)]
    public class StartupCommand : ExternalCommand
    {
        public override void Execute()
        {
            var viewModel = new ICI_capacitacionViewModel();
            var view = new ICI_capacitacionView(viewModel);
            view.ShowDialog();
        }
    }
}