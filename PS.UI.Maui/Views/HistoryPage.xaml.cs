using PS.Core.Models;
using PS.UI.Maui.ViewModels;

namespace PS.UI.Maui.Views;

public partial class HistoryPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HistoryViewModel _viewModel;

    private string _usuarioId = "Id-01";

    public HistoryPage(IServiceProvider serviceProvider, HistoryViewModel viewModel)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Cargar mascotas del usuario
        var mascotas = await _viewModel.GetByIdUsuario(_usuarioId);
        cvHistorial.ItemsSource = mascotas;
    }

    private async void btnVerDetalle_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var mascota = button?.CommandParameter as MascotaModel;

        if (mascota != null)
        {
            var nextPage = _serviceProvider.GetRequiredService<DetailReadPage>();
            nextPage.CargarMascota(mascota);
            await Navigation.PushAsync(nextPage);
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var mascota = button?.CommandParameter as MascotaModel;

        if (mascota != null)
        {
            bool confirm = await DisplayAlert("Confirmar", "¿Deseas eliminar esta mascota?", "Sí", "No");

            if (confirm)
            {
                var resultado = await _viewModel.EliminarMascotaAsync(mascota);

                if (resultado == 1)
                {
                    var listaActual = (List<MascotaModel>)cvHistorial.ItemsSource;
                    listaActual.Remove(mascota);
                    cvHistorial.ItemsSource = null;
                    cvHistorial.ItemsSource = listaActual;

                    await DisplayAlert("Eliminado", "Mascota eliminada correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo eliminar la mascota", "OK");
                }
            }
        }
    }

}