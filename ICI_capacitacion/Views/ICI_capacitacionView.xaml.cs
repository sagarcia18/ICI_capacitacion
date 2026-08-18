using ICI_capacitacion.ViewModels;

namespace ICI_capacitacion.Views
{
    public sealed partial class ICI_capacitacionView
    {
        public ICI_capacitacionView(ICI_capacitacionViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}