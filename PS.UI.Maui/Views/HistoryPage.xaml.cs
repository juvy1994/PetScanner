using PS.UI.Maui.ViewModels;

namespace PS.UI.Maui.Views;

public partial class HistoryPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HistoryViewModel _viewModel;

    public HistoryPage(IServiceProvider serviceProvider, HistoryViewModel viewModel)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _viewModel = viewModel;
    }

    private void btnVerDetalle_Clicked(object sender, EventArgs e)
    {
        this.gridDetalle0.IsVisible = true;
        this.gridDetalle1.IsVisible = true;
        this.gridDetalle2.IsVisible = true;
        this.gridDetalle3.IsVisible = true;
        this.gridDetalle4.IsVisible = true;
        this.btnMinimizar.IsVisible = true;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnMinimizar_Clicked(object sender, EventArgs e)
    {
        this.gridDetalle0.IsVisible = false;
        this.gridDetalle1.IsVisible = false;
        this.gridDetalle2.IsVisible = false;
        this.gridDetalle3.IsVisible = false;
        this.gridDetalle4.IsVisible = false;
        this.btnMinimizar.IsVisible = false;
    }
}