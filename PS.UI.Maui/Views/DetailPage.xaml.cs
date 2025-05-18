
using Microsoft.Extensions.DependencyInjection;
using PS.Core.Models;
using PS.UI.Maui.ViewModels;

namespace PS.UI.Maui.Views;

public partial class DetailPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DetailViewModel _viewModel;

    public DetailPage(IServiceProvider serviceProvider, DetailViewModel viewModel)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _viewModel = viewModel;
        _viewModel.MostrarAlerta = async (mensaje) =>
        {
            await DisplayAlert("Error", mensaje, "OK");
        };
    }

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        string mascotaId = "PET-SCAN" + Guid.NewGuid().ToString();
        string url = null;
        if (imgResultado.Source is UriImageSource uriImage)
        {
            url = uriImage.Uri.ToString();
        }

        try
        {
            var mascota = new MascotaModel
            {
                Id = mascotaId,
                Nombre = lblNombreRaza.Text,
                Especie = lblEspecie.Text,
                Origen = lblOrigen.Text,

                CaracteristicasFisicasTamano = lblTamanio.Text,
                CaracteristicasFisicasPeso = lblPeso.Text,
                CaracteristicasFisicasEsperanzaVida = lblEsperanzaVida.Text,
                CaracteristicasFisicasPelaje = lblPelaje.Text,

                AlimentacionTipoRecomendada = lblRecomendada.Text,
                AlimentacionPorciones = lblPorciones.Text,
                AlimentacionFrecuencia = lblFrecuencia.Text,

                CuidadosEspecialesEjercicio = lblEjercicio.Text,
                CuidadosEspecialesSocializacion = lblSocializacion.Text,

                UrlImage = url,
                RutaImagenLocal = _viewModel.rutaImagenLocal,
                UsuarioId = "Id-01",
                Estado = true,
                Sincronizado = false
            };
            await _viewModel.GuardarMascotaAsync(mascota);

            var enfermedades = cvEnfermedadesComunes.ItemsSource.Cast<EnfermedadComunModel>().ToList();

            foreach (var enf in enfermedades)
            {
                EnfermedadComunModel enfermedad = new EnfermedadComunModel
                {
                    Id = "ENF-"+Guid.NewGuid().ToString(),
                    Nombre = enf.Nombre,
                    Descripcion = enf.Descripcion,
                    Prevencion = enf.Prevencion,
                    MascotaId = mascota.Id,
                    Estado = true,
                    Sincronizado = false
                };
                await _viewModel.GuardarEnferdadComunAsync(enfermedad);
            }

            await DisplayAlert("Guardado", "Mascota guardada correctamente", "OK");

            var nextPage = _serviceProvider.GetRequiredService<HistoryPage>();
            await Navigation.PushAsync(nextPage);      
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurri� un error: {ex.Message}", "OK");
        }
    }

    private async void btnSearch_Clicked(object sender, EventArgs e)
    {

        var nextPage = _serviceProvider.GetRequiredService<LoadPage>();
        await Navigation.PushAsync(nextPage);
    }

    public void SetResultado(PetBreedInfoDto dto)
    {
        lblEspecie.Text = dto.especie;
        lblNombreRaza.Text = dto.nombre_raza;
        lblOrigen.Text = dto.origen;
        lblComportamiento.Text = dto.comportamiento;
        lblTamanio.Text = dto.caracteristicas_fisicas.tamano;
        lblPeso.Text = dto.caracteristicas_fisicas.peso;
        lblEsperanzaVida.Text = dto.caracteristicas_fisicas.esperanza_vida;
        lblPelaje.Text = dto.caracteristicas_fisicas.pelaje;
        lblRecomendada.Text = dto.alimentacion.tipo_recomendada;
        lblPorciones.Text = dto.alimentacion.porciones;
        lblFrecuencia.Text = dto.alimentacion.frecuencia;
        lblEjercicio.Text = dto.cuidados_especiales.ejercicio;
        lblSocializacion.Text = dto.cuidados_especiales.socializacion;
        var enfermedades = dto.enfermedades_comunes.Select(e => new EnfermedadComunModel
        {
            Nombre = e.nombre,
            Descripcion = e.descripcion,
            Prevencion = e.prevencion,
            Estado = true,
            Sincronizado = false
        }).ToList();

        cvEnfermedadesComunes.ItemsSource = enfermedades;
        imgResultado.Source = string.IsNullOrEmpty(dto.UrlImage) ? "imgvacia.png" : dto.UrlImage;
    }
}