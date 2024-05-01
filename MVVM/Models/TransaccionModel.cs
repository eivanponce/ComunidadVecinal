using ComunidadVecinal.Helpers;
using Humanizer;
using PropertyChanged;

namespace ComunidadVecinal.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TransaccionModel : TableData
    {

        public string Descripcion { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool EsIngreso { get; set; } = true;

        public string FechaModificada
        {
            get
            {

                return Fecha.Humanize();
            }
        }

    }
}
