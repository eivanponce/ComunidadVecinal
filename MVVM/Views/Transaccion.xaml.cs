using ComunidadVecinal.MVVM.ViewModels;

namespace ComunidadVecinal.MVVM.Views;

public partial class Transaccion : ContentPage
{
	public Transaccion(TransaccionViewmodel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void guardar_Clicked(object sender, EventArgs e)
    {
        var viewModel = (TransaccionViewmodel)BindingContext;

        if (string.IsNullOrEmpty(viewModel.Transaccion.Descripcion))
        {
            await DisplayAlert("Info", "Falta por rellenar la Descripción", "Cerrar");
            return;
        }
        if (viewModel.Transaccion.Cantidad <= 0)
        {
            await DisplayAlert("Info", "La cantidad debe ser mayor a 0", "Cerrar");
            return;
        }

        var mensaje = viewModel.GuardarTransaccion();
        if (!string.IsNullOrEmpty(mensaje)) await DisplayAlert("Error", "Vuelva a intentarlo más tarde", "Cerrar");
        else await Navigation.PopAsync();
    }

    private async void cancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}