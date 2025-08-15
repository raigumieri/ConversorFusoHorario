using System;

namespace ConversorFusoHorario
{
    public class AgendaEntrada : IAgendaEntrada
    {
        public DateTime DataHora { get; set; }
        public string Titulo { get; set; }

        private readonly IConversorHora conversor;

        public AgendaEntrada(DateTime dataHora, string titulo, IConversorHora conversor)
        {
            DataHora = dataHora;
            Titulo = titulo;
            this.conversor = conversor;
        }

        public void Imprimir(string? idFusoDestino = null)
        {
            DateTime dataExibir = string.IsNullOrEmpty(idFusoDestino) ? DataHora : conversor.ConverterParaFusoHorario(DataHora, idFusoDestino);
            Console.WriteLine($"{dataExibir:dd/MM/yyyy HH:mm} - {Titulo}");
        }

        public void ImprimirHora(string? idFusoDestino = null)
        {
            DateTime horaExibir = string.IsNullOrEmpty(idFusoDestino) ? DataHora : conversor.ConverterParaFusoHorario(DataHora, idFusoDestino);
            Console.WriteLine($"{horaExibir:HH:mm}");
        }

        public void ImprimirDia(string? idFusoDestino = null)
        {
            DateTime diaExibir = string.IsNullOrEmpty(idFusoDestino) ? DataHora : conversor.ConverterParaFusoHorario(DataHora, idFusoDestino);
            Console.WriteLine($"{diaExibir:dd/MM/yyyy}");
        }

        public void ImprimirDiaSemana(string? idFusoDestino = null)
        {
            DateTime diaSemanaExibir = string.IsNullOrEmpty(idFusoDestino) ? DataHora : conversor.ConverterParaFusoHorario(DataHora, idFusoDestino);
            Console.WriteLine($"{diaSemanaExibir:dddd}");
        }
    }
}
