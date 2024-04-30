using PropertyChanged;

namespace ComunidadVecinal.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TurnoLimpiezaViewModel
    {
        public DateTime primerTurno = new DateTime(2024, 03, 25);
        List<string> ordenLimpieza = new List<string>
        {
            "Portal 2 - Bajo A",
            "Portal 2 - Bajo B",
            "Portal 2 - 1º A",
            "Portal 2 - 1º B",
            "Portal 2 - 2º A",
            "Portal 2 - 2º B",

            "Portal 1 - Bajo B",
            "Portal 1 - Bajo C",
            "Portal 1 - 1º A",
            "Portal 1 - 1º B",
            "Portal 1 - 1º C",
            "Portal 1 - 2º A",
            "Portal 1 - 2º B",
            "Portal 1 - 2º C"
        };

        public string SemanaPasada { get; set; } = string.Empty;
        public string SemanaActual { get; set; } = string.Empty;
        public string SemanaSiguiente { get; set; } = string.Empty;


        public TurnoLimpiezaViewModel()
        {
            
            TimeSpan timeDifference = DateTime.Now.Date - primerTurno.Date;

            // Calcular el número de semanas transcurridas redondeando hacia abajo
            int semanasPasadas = (int)Math.Floor(timeDifference.TotalDays / 7.0);

            int ciclosPasados = (int)Math.Truncate(((decimal)semanasPasadas / ordenLimpieza.Count));
            int calculoPosicionActual = semanasPasadas - (ciclosPasados * ordenLimpieza.Count);
            int calculoPosicionPasada = (calculoPosicionActual == 1) ? ordenLimpieza.Count : calculoPosicionActual -1;
            int calculoPosicionSiguiente = (calculoPosicionActual == ordenLimpieza.Count) ? 1: calculoPosicionActual +1;

            SemanaActual = ordenLimpieza[calculoPosicionActual];
            SemanaPasada = ordenLimpieza[calculoPosicionPasada];
            SemanaSiguiente = ordenLimpieza[calculoPosicionSiguiente];
        }
    }
}
