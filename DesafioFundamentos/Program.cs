﻿using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
Console.WriteLine("____________________________________________\n");
Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n"+ "____________________________________________\n" +
                  "Digite o preço inicial:\n"+ "----------------------" );                 
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:\n"  + "-----------------------------");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();   
    Console.WriteLine("Digite a sua opção:\n" + "------------------\n");
    Console.WriteLine("1 - Cadastrar veículo\n" + "---------------------");
    Console.WriteLine("2 - Remover veículo\n" + "------------------");
    Console.WriteLine("3 - Listar veículos\n"+ "-------------------");
    Console.WriteLine("4 - Encerrar\n"+"------------");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("________________\n\n"+"Opção inválida!!\n"+ "________________");
            break;
    }

    Console.WriteLine("Pressione Enter para continuar\n"+"----------------------------------");
    Console.ReadLine();
}
                   
Console.WriteLine("O programa se encerrou!!\n"+"----------------------");
