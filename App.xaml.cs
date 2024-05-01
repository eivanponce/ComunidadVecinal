using ComunidadVecinal.Helpers;
using ComunidadVecinal.MVVM.Models;
using ComunidadVecinal.MVVM.Views;

namespace ComunidadVecinal
{
    public partial class App : Application
    {
        public static BaseRepository<TransaccionModel> TransaccionRepository { get; private set; }

        public App(BaseRepository<TransaccionModel> _transaccionRepository)
        {
            InitializeComponent();
            TransaccionRepository = _transaccionRepository;
            RegistrarRutas();
            MainPage = new AppShell();
        }

        private void RegistrarRutas()
        {
            Routing.RegisterRoute("Transaccion", typeof(Transaccion));
        }
    }
}
