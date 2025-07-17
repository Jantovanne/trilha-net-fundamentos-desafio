using System.Text.RegularExpressions;



namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            //Cria um modelo padrão para comparar com os modelos de placas digitados.
            string placaPadrão = @"^([A-Z]{3}[0-9]{4}|[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2})$";

            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar: Ex:(AAA1234) ou (AAA1B23)");
                Console.WriteLine("-----------------------------------------");
                //Nessa variável, ela já padroniza a placa digitada para letra maiúscula.
                string placaDigitada = Console.ReadLine().ToUpper().Replace("-", "");


                if (veiculos.ContainsKey(placaDigitada))
                {
                    Console.WriteLine($"A placa {placaDigitada}, já foi cadastrada anteriormente. Tente novamente!!\n");
                    Console.WriteLine("---------------------------------------------------------------------------");
                    continue;
                }//Compara a placa digitada com o modelo padrão.
                else if (Regex.IsMatch(placaDigitada, placaPadrão))
                {
                    Console.WriteLine($"Placa cadastrada com sucesso!!\n" + "------------------------------");
                    DateTime horaEntrada = DateTime.Now;
                    Console.WriteLine($"Hora de entrada: {horaEntrada.ToString("HH:mm")}");
                    veiculos.Add(placaDigitada, horaEntrada);
                    break;

                }
                else
                {
                    Console.WriteLine("Modelo de placa inexistente. Por favor insira uma placa conforme o modelo mostrado no exemplo!!");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------");
                }
            }
        }

        public void RemoverVeiculo()
        {


            Console.WriteLine("Digite a placa do veículo para remover:\n");
            Console.WriteLine("--------------------------------------");
            string placaRemover = Console.ReadLine().ToUpper().Replace("-", "");

            // Verifica se o veículo existe
            if (veiculos.ContainsKey(placaRemover))
            {
                //Aqui é calculado o tempo que o veículo ficou estacionado e o valor que será cobrado.
                DateTime horaEntrada = veiculos[placaRemover];
                DateTime horaSaida = DateTime.Now;
                TimeSpan tempoEstacionado = horaSaida - horaEntrada;
                decimal valorTotal = 0;

                //Aqui é realizado o arredondamento das horas para o maior número iteiro.
                int horasCobradas = (int)Math.Ceiling(tempoEstacionado.TotalHours);

                Console.WriteLine($"Horário de entrada do veículo {placaRemover}: {horaEntrada.ToString("HH:mm")}\n");
                Console.WriteLine(" ---------------------------------------------\n");
                Console.WriteLine($"Horário de saída do veículo {placaRemover}: {horaSaida.ToString("HH:mm")}\n");
                Console.WriteLine(" -------------------------------------------\n");

                valorTotal = horasCobradas * precoPorHora + precoInicial;

                veiculos.Remove(placaRemover);
                Console.WriteLine($"O veículo {placaRemover} foi removido e o preço total foi de: R$ {valorTotal}");
                Console.WriteLine(" -------------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente!!");
                Console.WriteLine("-------------------------------------------------------------------------------------------\n");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Laço de repetição para exibir os veículos estacionados
                foreach (var veiculosEstacionados in veiculos)
                {
                    Console.WriteLine($"Placa do veículo: {veiculosEstacionados.Key} | Horário de entrada: {veiculosEstacionados.Value:HH:mm:ss}");

                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.\n");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
