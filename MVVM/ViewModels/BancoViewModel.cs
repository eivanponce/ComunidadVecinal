using ComunidadVecinal.MVVM.Models;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace ComunidadVecinal.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BancoViewModel
    {
        public ObservableCollection<TransaccionModel> Transacciones { get; set; }
        public decimal Total { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public string NombreCompleto { get; set; }
        public BancoViewModel()
        {
            NombreCompleto = Preferences.Get("NombreCompleto", string.Empty);
            CargarTransacciones();
        }

        public void CargarTransacciones()
        {
            var transacciones = App.TransaccionRepository.GetItems().OrderByDescending(x => x.Fecha).ToList();
            Transacciones = new ObservableCollection<TransaccionModel>(transacciones);


            Ingresos = 0; Gastos = 0; decimal ingresosCuenta = 0; decimal gastosCuenta = 0;
            foreach (var item in transacciones)
            {
                if (item.EsIngreso)
                {
                    ingresosCuenta += item.Cantidad;

                    if (item.Fecha.Year == DateTime.Now.Year && item.Fecha.Month == DateTime.Now.Month) Ingresos += item.Cantidad;
                }
                else
                {
                    if (item.Fecha.Year == DateTime.Now.Year && item.Fecha.Month == DateTime.Now.Month) Gastos += item.Cantidad;

                    gastosCuenta += item.Cantidad;
                }
                Total = ingresosCuenta - gastosCuenta;
            }
        }
    }
}
