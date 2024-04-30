using ComunidadVecinal.MVVM.ViewModels;

namespace ComunidadVecinal.MVVM.Views;

public partial class TurnoLimpieza : ContentPage
{


	public TurnoLimpieza(TurnoLimpiezaViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}