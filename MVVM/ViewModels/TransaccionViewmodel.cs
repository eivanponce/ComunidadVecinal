using ComunidadVecinal.MVVM.Models;

namespace ComunidadVecinal.MVVM.ViewModels
{
    public class TransaccionViewmodel
    {

        public TransaccionModel Transaccion { get; set; } = new TransaccionModel();

        public string GuardarTransaccion()
        {
            App.TransaccionRepository.SaveItem(Transaccion);
            return App.TransaccionRepository.StatusMessage;
        }


    }
}
