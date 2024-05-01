using SQLite;

namespace ComunidadVecinal.Settings
{
    public static class Constantes
    {
        private const string DBFileName = "ComunidadVecinalbbdd.db3";

        public const SQLiteOpenFlags Flags =
             SQLiteOpenFlags.ReadWrite |
             SQLiteOpenFlags.Create |
             SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                return Path
                     .Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
