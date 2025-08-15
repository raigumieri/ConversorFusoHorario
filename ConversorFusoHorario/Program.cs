using System;
using System.Collections.Generic;
using ConversorFusoHorario;

// Conversor de Fuso Horário
IConversorHora conversor = new ConversorHora();

// Lista para armazenar os compromissos
List<IAgendaEntrada> compromissos = new List<IAgendaEntrada>();

// Fuso horário do Brasil como padrão de cadastro
string fusoBrasil = "E. South America Standard Time";

// Loop principal do programa
while (true)
{
    // Menu Principal
    Console.WriteLine("\n--- Agenda com Conversor de Fuso Horário ---");
    Console.WriteLine("1. Cadastrar compromisso (Brasil)");
    Console.WriteLine("2. Converter compromissos");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha: ");
    string opcao = Console.ReadLine();

    // Opção de Sair
    if (opcao == "0") break;

    switch (opcao)
    {
        // ================================
        // |OPÇÃO 1: CADASTRAR COMPROMISSO|
        // ================================
        case "1":
            Console.Write("Digite a data e hora (ex: 2025-08-14 15:30): ");

            // Validando a entrada de data e hora
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataHoraLocal))
            {
                Console.WriteLine("Data e hora inválidas. Tente novamente.");
                break;
            }

            // Lê o título do compromisso
            Console.Write("Digite o título do compromisso: ");
            string titulo = Console.ReadLine();

            // Adiciona o compromisso na lista
            compromissos.Add(new AgendaEntrada(dataHoraLocal, titulo, conversor));
            Console.WriteLine("Compromisso adicionado!");
            break;

        // =================================
        // |OPÇÃO 2: CONVERTER COMPROMISSOS|
        // =================================
        case "2":
            // Verifica se existe pelo menos um compromisso cadastrado
            if (compromissos.Count == 0)
            {
                Console.WriteLine("Nenhum compromisso cadastrado ainda.");
                break;
            }

            // Exibe todos os compromissos cadastrados
            Console.WriteLine("\nCompromissos salvos:");
            for (int i = 0; i < compromissos.Count; i++)
            {
                DateTime dataBrasil = conversor.ConverterParaFusoHorario(compromissos[i].DataHora, fusoBrasil);
                Console.WriteLine($"{i + 1}. {dataBrasil:dd/MM/yyyy HH:mm} - {compromissos[i].Titulo}");
            }

            // Usuário escolhe o compromisso que deseja converter
            Console.Write("\nDigite o número do compromisso que deseja converter (ou 0 para voltar): ");
            if (!int.TryParse(Console.ReadLine(), out int escolhaComp) || escolhaComp < 0 || escolhaComp > compromissos.Count)
            {
                Console.WriteLine("Opção inválida.");
                break;
            }

            // Volta para o Menu Principal
            if (escolhaComp == 0) break; 

            var compromissoSelecionado = compromissos[escolhaComp - 1];

            // Exibe as opções de fusos horários para conversão
            Console.WriteLine("\nEscolha o fuso horário para conversão:");
            Console.WriteLine("1. UTC");
            Console.WriteLine("2. GMT Standard Time");
            Console.WriteLine("3. Tokyo Standard Time");
            Console.WriteLine("0. Voltar");
            Console.Write("Escolha: ");
            string fusoOpcao = Console.ReadLine();

            // Define o fuso horário de destino com base na opção escolhida
            string fusoDestino = fusoOpcao switch
            {
                "1" => "UTC",
                "2" => "GMT Standard Time",
                "3" => "Tokyo Standard Time",
                "0" => null,
                _ => null
            };

            if (fusoDestino == null)
            {
                Console.WriteLine("Voltando ao menu principal...");
                break;
            }

            // Converte o compromisso selecionado para o fuso horário escolhido e exibe o resultado
            DateTime convertido = conversor.ConverterParaFusoHorario(compromissoSelecionado.DataHora, fusoDestino);
            Console.WriteLine($"\nResultado:");
            Console.WriteLine($"{convertido:dd/MM/yyyy HH:mm} ({fusoDestino}) - {compromissoSelecionado.Titulo}");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
