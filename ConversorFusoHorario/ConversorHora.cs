using System;

namespace ConversorFusoHorario
{
    public class ConversorHora : IConversorHora
    {
        public DateTime ConverterParaFusoHorario(DateTime dataHora, string idFusoDestino)
        {
            var destino = TimeZoneInfo.FindSystemTimeZoneById(idFusoDestino);
            return TimeZoneInfo.ConvertTime(dataHora, destino);
        }

        public string ObterFusoHorarioDaData(string dataHoraStr)
        {
            DateTime dataHora;
            if (DateTime.TryParse(dataHoraStr, out dataHora))
            {
                return TimeZoneInfo.Local.Id;
            }
            throw new FormatException("Data/hora inválida");
        }
    }
}
