using ComunidadVecinal.Helpers;
using Humanizer;
using PropertyChanged;

namespace ComunidadVecinal.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TurnosModel 
    {
        public string Semana { get; set; } = string.Empty;
        public string Piso { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Color Color { get; set; } = Color.FromArgb("D5F5E3");

        public string FechaInicioModificada
        {
            get
            {
                return FechaInicio.Humanize();
            }
        }
        public string FechaFinModificada
        {
            get
            {
                return FechaFin.Humanize();
            }
        }

    }
}
