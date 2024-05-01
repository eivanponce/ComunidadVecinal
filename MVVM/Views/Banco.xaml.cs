using ComunidadVecinal.MVVM.ViewModels;
using System.Transactions;

namespace ComunidadVecinal.MVVM.Views;

public partial class Banco : ContentPage
{
	public Banco(BancoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void AddTransaccion_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"Transaccion");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = (BancoViewModel)BindingContext;
        viewModel.CargarTransacciones();
    }
}