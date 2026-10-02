namespace Pagin_Web_Zoonosis.Services
{
    public static class FechaHelper
    {
        private static readonly TimeZoneInfo Ar = Buscar();

        private static TimeZoneInfo Buscar()
        {
            try { return TimeZoneInfo.FindSystemTimeZoneById("America/Argentina/Buenos_Aires"); }
            catch { return TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time"); }
        }

        public static DateTime ALocal(DateTime utc) =>
            TimeZoneInfo.ConvertTimeFromUtc(DateTime.SpecifyKind(utc, DateTimeKind.Utc), Ar);
    }
}